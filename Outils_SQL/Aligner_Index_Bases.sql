/* ============================================================================
   Aligner_Index_Bases.sql
   ----------------------------------------------------------------------------
   Aligne les index d'une base CIBLE sur ceux d'une base REFERENCE.

   Perimetre : tables utilisateur presentes dans les DEUX bases, index rowstore
   (CLUSTERED / NONCLUSTERED), y compris cles primaires et contraintes UNIQUE.

   Actions :
     - index present uniquement dans la cible .............. supprime
     - index present des deux cotes mais defini differemment  recree comme la reference
     - index present uniquement dans la reference .......... cree dans la cible

   Securites :
     - mode simulation par defaut (@Executer = 0) : affiche le plan sans rien faire
     - verification des doublons avant toute creation d'index unique (statut DOUBLONS)
     - verification des cles etrangeres referencant une contrainte a supprimer
       (statut FK_REFERENCEE)
     - index ignores si la table est absente de la cible (statut TABLE_ABSENTE)
     - execution transactionnelle : tout ou rien

   Usage : renseigner @BaseReference / @BaseCible, executer en simulation,
           verifier le plan, puis passer @Executer = 1.
   Prerequis : droits DDL sur les deux bases ; meme instance SQL Server.
   ============================================================================ */
SET NOCOUNT ON;
SET XACT_ABORT ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;

DECLARE @BaseReference sysname = N'RHP';      -- base de reference (modele)
DECLARE @BaseCible     sysname = N'RHP_FH2';  -- base a aligner
DECLARE @Executer      bit     = 0;           -- 0 = simulation, 1 = applique

/* ------------------------- Validations initiales ------------------------- */
IF @BaseReference = @BaseCible
BEGIN
    RAISERROR(N'La base reference et la base cible doivent etre differentes.', 16, 1);
    RETURN;
END;
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = @BaseReference)
BEGIN
    RAISERROR(N'Base reference introuvable : %s', 16, 1, @BaseReference);
    RETURN;
END;
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = @BaseCible)
BEGIN
    RAISERROR(N'Base cible introuvable : %s', 16, 1, @BaseCible);
    RETURN;
END;

/* ------------------- Extraction des index des deux bases ------------------- */
IF OBJECT_ID('tempdb..#idx') IS NOT NULL DROP TABLE #idx;
CREATE TABLE #idx (
    src             char(1)       NOT NULL,             -- R = reference, F = cible
    object_id       int           NOT NULL,
    index_id        int           NOT NULL,
    schema_name     nvarchar(128) COLLATE DATABASE_DEFAULT NOT NULL,
    table_name      nvarchar(128) COLLATE DATABASE_DEFAULT NOT NULL,
    index_name      nvarchar(128) COLLATE DATABASE_DEFAULT NOT NULL,
    is_pk           bit           NOT NULL,
    is_uq_const     bit           NOT NULL,
    is_unique       bit           NOT NULL,
    idx_type        tinyint       NOT NULL,             -- 1 = CLUSTERED, 2 = NONCLUSTERED
    key_cols        nvarchar(max) COLLATE DATABASE_DEFAULT NOT NULL, -- [col] ASC/DESC, ...
    key_cols_plain  nvarchar(max) COLLATE DATABASE_DEFAULT NOT NULL, -- [col], ...
    inc_cols        nvarchar(max) COLLATE DATABASE_DEFAULT NOT NULL,
    filter_def      nvarchar(max) COLLATE DATABASE_DEFAULT NOT NULL,
    is_disabled     bit           NOT NULL
);

IF OBJECT_ID('tempdb..#tbl') IS NOT NULL DROP TABLE #tbl;
CREATE TABLE #tbl (
    src         char(1)       NOT NULL,
    schema_name nvarchar(128) COLLATE DATABASE_DEFAULT NOT NULL,
    table_name  nvarchar(128) COLLATE DATABASE_DEFAULT NOT NULL
);

DECLARE @sql nvarchar(max);
SET @sql = N'
INSERT INTO #idx
SELECT ''{SRC}'', i.object_id, i.index_id, s.name, t.name, i.name,
       i.is_primary_key, i.is_unique_constraint, i.is_unique, i.type,
       ISNULL(k.key_cols, N''''), ISNULL(kp.key_cols_plain, N''''),
       ISNULL(inc.inc_cols, N''''), ISNULL(i.filter_definition, N''''), i.is_disabled
FROM {DB}.sys.indexes i
JOIN {DB}.sys.tables  t ON t.object_id = i.object_id
JOIN {DB}.sys.schemas s ON s.schema_id = t.schema_id
OUTER APPLY (SELECT STUFF((SELECT '', '' + QUOTENAME(c.name) + CASE WHEN ic2.is_descending_key = 1 THEN '' DESC'' ELSE '' ASC'' END
             FROM {DB}.sys.index_columns ic2
             JOIN {DB}.sys.columns c ON c.object_id = ic2.object_id AND c.column_id = ic2.column_id
             WHERE ic2.object_id = i.object_id AND ic2.index_id = i.index_id AND ic2.is_included_column = 0
             ORDER BY ic2.key_ordinal
             FOR XML PATH('''')), 1, 2, '''') AS key_cols) k
OUTER APPLY (SELECT STUFF((SELECT '', '' + QUOTENAME(c.name)
             FROM {DB}.sys.index_columns ic2
             JOIN {DB}.sys.columns c ON c.object_id = ic2.object_id AND c.column_id = ic2.column_id
             WHERE ic2.object_id = i.object_id AND ic2.index_id = i.index_id AND ic2.is_included_column = 0
             ORDER BY ic2.key_ordinal
             FOR XML PATH('''')), 1, 2, '''') AS key_cols_plain) kp
OUTER APPLY (SELECT STUFF((SELECT '', '' + QUOTENAME(c.name)
             FROM {DB}.sys.index_columns ic2
             JOIN {DB}.sys.columns c ON c.object_id = ic2.object_id AND c.column_id = ic2.column_id
             WHERE ic2.object_id = i.object_id AND ic2.index_id = i.index_id AND ic2.is_included_column = 1
             ORDER BY ic2.index_column_id
             FOR XML PATH('''')), 1, 2, '''') AS inc_cols) inc
WHERE i.index_id > 0 AND i.is_hypothetical = 0 AND i.name IS NOT NULL
  AND t.is_ms_shipped = 0 AND i.type IN (1, 2);

INSERT INTO #tbl
SELECT ''{SRC}'', s.name, t.name
FROM {DB}.sys.tables t
JOIN {DB}.sys.schemas s ON s.schema_id = t.schema_id
WHERE t.is_ms_shipped = 0;';

DECLARE @r nvarchar(max) = REPLACE(REPLACE(@sql, N'{DB}', QUOTENAME(@BaseReference)), N'{SRC}', N'R');
DECLARE @f nvarchar(max) = REPLACE(REPLACE(@sql, N'{DB}', QUOTENAME(@BaseCible)),     N'{SRC}', N'F');
EXEC sp_executesql @r;
EXEC sp_executesql @f;

/* ------------------------------- Comparaison ------------------------------- */
IF OBJECT_ID('tempdb..#cmp') IS NOT NULL DROP TABLE #cmp;
WITH rr AS (SELECT * FROM #idx WHERE src = 'R'),
     ff AS (SELECT * FROM #idx WHERE src = 'F')
SELECT
    CASE WHEN rr.index_name IS NULL THEN N'SUPPRIMER'
         WHEN ff.index_name IS NULL THEN N'CREER'
         WHEN rr.idx_type <> ff.idx_type OR rr.is_unique <> ff.is_unique
           OR rr.key_cols <> ff.key_cols OR rr.inc_cols <> ff.inc_cols
           OR rr.filter_def <> ff.filter_def OR rr.is_disabled <> ff.is_disabled
              THEN N'RECREER'
         ELSE N'IDENTIQUE' END AS action,
    ISNULL(rr.schema_name, ff.schema_name) AS schema_name,
    ISNULL(rr.table_name,  ff.table_name)  AS table_name,
    ISNULL(rr.index_name,  ff.index_name)  AS index_name,
    -- cote reference (modele pour la creation)
    rr.is_pk        AS r_is_pk,        rr.is_uq_const AS r_is_uq_const,
    rr.is_unique    AS r_is_unique,    rr.idx_type    AS r_idx_type,
    rr.key_cols     AS r_key_cols,     rr.key_cols_plain AS r_key_cols_plain,
    rr.inc_cols     AS r_inc_cols,     rr.filter_def  AS r_filter_def,
    rr.is_disabled  AS r_is_disabled,
    -- cote cible (pour la suppression et les controles FK)
    ff.is_pk        AS f_is_pk,        ff.is_uq_const AS f_is_uq_const,
    ff.object_id    AS f_object_id,    ff.index_id    AS f_index_id
INTO #cmp
FROM rr
FULL OUTER JOIN ff
  ON ff.schema_name = rr.schema_name AND ff.table_name = rr.table_name AND ff.index_name = rr.index_name;

/* ------------------------- Construction du plan d'action ------------------------- */
IF OBJECT_ID('tempdb..#plan') IS NOT NULL DROP TABLE #plan;
CREATE TABLE #plan (
    ordre       int IDENTITY(1,1),
    phase       tinyint NOT NULL,       -- 1 = suppression, 2 = creation, 3 = desactivation
    action      nvarchar(20)  NOT NULL,
    schema_name nvarchar(128) NOT NULL,
    table_name  nvarchar(128) NOT NULL,
    index_name  nvarchar(128) NOT NULL,
    statut      nvarchar(20)  NOT NULL DEFAULT N'PRET',
    info        nvarchar(1000) NULL,
    commande    nvarchar(max) NULL
);

-- Phase 1 : suppressions (SUPPRIMER + RECREER), contraintes via ALTER TABLE
INSERT INTO #plan (phase, action, schema_name, table_name, index_name, commande)
SELECT 1, c.action, c.schema_name, c.table_name, c.index_name,
       CASE WHEN c.f_is_pk = 1 OR c.f_is_uq_const = 1
            THEN N'ALTER TABLE ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name)
               + N' DROP CONSTRAINT ' + QUOTENAME(c.index_name) + N';'
            ELSE N'DROP INDEX ' + QUOTENAME(c.index_name)
               + N' ON ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name) + N';'
       END
FROM #cmp c
WHERE c.action IN (N'SUPPRIMER', N'RECREER');

-- Phase 2 : creations (CREER + RECREER) d'apres la definition de la reference
INSERT INTO #plan (phase, action, schema_name, table_name, index_name, commande)
SELECT 2, c.action, c.schema_name, c.table_name, c.index_name,
       CASE WHEN c.r_is_pk = 1
            THEN N'ALTER TABLE ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name)
               + N' ADD CONSTRAINT ' + QUOTENAME(c.index_name) + N' PRIMARY KEY '
               + CASE c.r_idx_type WHEN 1 THEN N'CLUSTERED' ELSE N'NONCLUSTERED' END
               + N' (' + c.r_key_cols + N');'
            WHEN c.r_is_uq_const = 1
            THEN N'ALTER TABLE ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name)
               + N' ADD CONSTRAINT ' + QUOTENAME(c.index_name) + N' UNIQUE '
               + CASE c.r_idx_type WHEN 1 THEN N'CLUSTERED' ELSE N'NONCLUSTERED' END
               + N' (' + c.r_key_cols + N');'
            ELSE N'CREATE ' + CASE WHEN c.r_is_unique = 1 THEN N'UNIQUE ' ELSE N'' END
               + CASE c.r_idx_type WHEN 1 THEN N'CLUSTERED' ELSE N'NONCLUSTERED' END
               + N' INDEX ' + QUOTENAME(c.index_name)
               + N' ON ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name)
               + N' (' + c.r_key_cols + N')'
               + CASE WHEN c.r_inc_cols <> N'' THEN N' INCLUDE (' + c.r_inc_cols + N')' ELSE N'' END
               + CASE WHEN c.r_filter_def <> N'' THEN N' WHERE ' + c.r_filter_def ELSE N'' END
               + N';'
       END
FROM #cmp c
WHERE c.action IN (N'CREER', N'RECREER');

-- Phase 3 : desactivation si l'index de reference est desactive
INSERT INTO #plan (phase, action, schema_name, table_name, index_name, commande)
SELECT 3, c.action, c.schema_name, c.table_name, c.index_name,
       N'ALTER INDEX ' + QUOTENAME(c.index_name)
     + N' ON ' + QUOTENAME(c.schema_name) + N'.' + QUOTENAME(c.table_name) + N' DISABLE;'
FROM #cmp c
WHERE c.action IN (N'CREER', N'RECREER') AND c.r_is_disabled = 1;

/* -------------- Controle 1 : table absente de la cible (CREER) -------------- */
UPDATE p
SET p.statut = N'TABLE_ABSENTE',
    p.info = N'Table absente de la base cible : creation impossible.',
    p.commande = NULL
FROM #plan p
WHERE p.phase = 2
  AND NOT EXISTS (SELECT 1 FROM #tbl tb
                  WHERE tb.src = 'F' AND tb.schema_name = p.schema_name AND tb.table_name = p.table_name);

/* -------------- Controle 2 : FK referencant une contrainte a supprimer -------------- */
DECLARE @p_ordre int, @p_oid int, @p_iid int, @nb int, @chk nvarchar(max), @liste nvarchar(1000);

DECLARE cur_fk CURSOR LOCAL FAST_FORWARD FOR
    SELECT p.ordre, c.f_object_id, c.f_index_id
    FROM #plan p
    JOIN #cmp c ON c.schema_name = p.schema_name AND c.table_name = p.table_name AND c.index_name = p.index_name
    WHERE p.phase = 1 AND p.commande IS NOT NULL;
OPEN cur_fk;
FETCH NEXT FROM cur_fk INTO @p_ordre, @p_oid, @p_iid;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @chk = N'SELECT @nbOUT = COUNT(*) FROM ' + QUOTENAME(@BaseCible)
             + N'.sys.foreign_keys fk WHERE fk.referenced_object_id = @pOID AND fk.key_index_id = @pIID;';
    EXEC sp_executesql @chk, N'@pOID int, @pIID int, @nbOUT int OUTPUT', @p_oid, @p_iid, @nb OUTPUT;
    IF @nb > 0
    BEGIN
        SET @chk = N'SELECT @lOUT = STUFF((SELECT '', '' + OBJECT_NAME(fk.parent_object_id) + ''.'' + fk.name
                     FROM ' + QUOTENAME(@BaseCible) + N'.sys.foreign_keys fk
                     WHERE fk.referenced_object_id = @pOID AND fk.key_index_id = @pIID
                     FOR XML PATH('''')), 1, 2, '''');';
        EXEC sp_executesql @chk, N'@pOID int, @pIID int, @lOUT nvarchar(1000) OUTPUT', @p_oid, @p_iid, @liste OUTPUT;
        UPDATE #plan
        SET statut = N'FK_REFERENCEE',
            info = N'Contrainte/index reference par ' + CAST(@nb AS nvarchar(10)) + N' FK : ' + @liste,
            commande = NULL
        WHERE ordre = @p_ordre;
    END;
    FETCH NEXT FROM cur_fk INTO @p_ordre, @p_oid, @p_iid;
END;
CLOSE cur_fk; DEALLOCATE cur_fk;

/* -------------- Controle 3 : doublons avant creation d'index unique -------------- */
DECLARE @p_schema nvarchar(128), @p_table nvarchar(128), @p_keys nvarchar(max), @p_flt nvarchar(max);

DECLARE cur_dup CURSOR LOCAL FAST_FORWARD FOR
    SELECT p.ordre, p.schema_name, p.table_name, c.r_key_cols_plain, c.r_filter_def
    FROM #plan p
    JOIN #cmp c ON c.schema_name = p.schema_name AND c.table_name = p.table_name AND c.index_name = p.index_name
    WHERE p.phase = 2 AND p.commande IS NOT NULL AND c.r_is_unique = 1;
OPEN cur_dup;
FETCH NEXT FROM cur_dup INTO @p_ordre, @p_schema, @p_table, @p_keys, @p_flt;
WHILE @@FETCH_STATUS = 0
BEGIN
    SET @chk = N'SELECT @nbOUT = COUNT(*) FROM (SELECT 1 AS x FROM '
             + QUOTENAME(@BaseCible) + N'.' + QUOTENAME(@p_schema) + N'.' + QUOTENAME(@p_table)
             + N' WHERE ' + CASE WHEN @p_flt <> N'' THEN @p_flt ELSE N'1 = 1' END
             + N' GROUP BY ' + @p_keys + N' HAVING COUNT(*) > 1) AS d;';
    EXEC sp_executesql @chk, N'@nbOUT int OUTPUT', @nb OUTPUT;
    IF @nb > 0
        UPDATE #plan
        SET statut = N'DOUBLONS',
            info = CAST(@nb AS nvarchar(10)) + N' groupe(s) de doublons dans la cible : a purger avant creation.',
            commande = NULL
        WHERE ordre = @p_ordre;
    FETCH NEXT FROM cur_dup INTO @p_ordre, @p_schema, @p_table, @p_keys, @p_flt;
END;
CLOSE cur_dup; DEALLOCATE cur_dup;

-- Un RECREER dont la suppression est bloquee ne doit pas etre recree
UPDATE pc
SET pc.statut = N'BLOQUE', pc.info = N'Suppression prealable bloquee (voir phase 1).', pc.commande = NULL
FROM #plan pc
JOIN #plan ps ON ps.schema_name = pc.schema_name AND ps.table_name = pc.table_name AND ps.index_name = pc.index_name
WHERE pc.phase >= 2 AND ps.phase = 1 AND ps.commande IS NULL;

/* -------------------------------- Affichage du plan -------------------------------- */
SELECT p.ordre, p.phase, p.action, p.statut,
       p.schema_name, p.table_name, p.index_name, p.info, p.commande
FROM #plan p
ORDER BY p.phase, p.ordre;

SELECT p.action, p.statut, COUNT(*) AS nb
FROM #plan p
GROUP BY p.action, p.statut
ORDER BY p.action, p.statut;

DECLARE @nbExec int = (SELECT COUNT(*) FROM #plan WHERE commande IS NOT NULL);

IF @Executer = 0
BEGIN
    PRINT '*** SIMULATION : aucune modification appliquee. '
        + CAST(@nbExec AS nvarchar(10)) + N' commande(s) prete(s). Passez @Executer = 1 pour appliquer. ***';
    RETURN;
END;

/* ---------------------------------- Execution ---------------------------------- */
DECLARE @cmd nvarchar(max), @cmdExec nvarchar(max), @nbOk int = 0;
BEGIN TRY
    BEGIN TRANSACTION;
    DECLARE cur_exec CURSOR LOCAL FAST_FORWARD FOR
        SELECT commande FROM #plan WHERE commande IS NOT NULL ORDER BY phase, ordre;
    OPEN cur_exec;
    FETCH NEXT FROM cur_exec INTO @cmd;
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- les commandes sont en nom 2 parties : on force le contexte de la base cible
        SET @cmdExec = N'USE ' + QUOTENAME(@BaseCible) + N';' + NCHAR(13) + NCHAR(10) + @cmd;
        EXEC sp_executesql @cmdExec;
        SET @nbOk = @nbOk + 1;
        FETCH NEXT FROM cur_exec INTO @cmd;
    END;
    CLOSE cur_exec; DEALLOCATE cur_exec;
    COMMIT TRANSACTION;
    PRINT 'Alignement termine : ' + CAST(@nbOk AS nvarchar(10)) + N' commande(s) executee(s) avec succes.';
END TRY
BEGIN CATCH
    IF CURSOR_STATUS('local', 'cur_exec') >= 0
    BEGIN
        CLOSE cur_exec; DEALLOCATE cur_exec;
    END;
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'ERREUR - annulation de toutes les modifications : ' + ERROR_MESSAGE();
    PRINT N'Commande en echec : ' + ISNULL(@cmd, N'(aucune)');
    THROW;
END CATCH;
