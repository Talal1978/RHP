/* ============================================================================
   RHP - Module SP_ : propagation au changement (Copier_Vers)
   ----------------------------------------------------------------------------
   Controle_Designer_Champ.Copier_Vers : code du champ d'entête CIBLE recevant
   la valeur du champ source à chaque changement de celui-ci, quand la cible
   est vide ou inférieure à la nouvelle valeur (comparaison intelligente :
   nombres, puis dates, puis texte). Ex. : Dat_Deb_Conge.Copier_Vers =
   'Dat_Fin_Conge' -> si la date de fin est vide ou antérieure à la nouvelle
   date de début, elle prend la date de début. La cible reste ensuite
   modifiable (confort de saisie, jamais un verrou).
   Règles (verrouillées dans Saving du Designer et dans l'import JSON) :
     - source et cible sont des champs de l'entête (ENT) ;
     - la cible existe, est distincte de la source, reste saisissable
       (Etat 'S', jamais CALCULE / SOURCE / GED) ;
     - pas de référence mutuelle directe (A->B et B->A).
   Au même lot : la liaison d'un champ à une colonne TECHNIQUE (Dat_Crea,
   Created_By, Dat_Modif, Modified_By, Statut, id_Societe) est assainie —
   lecture seule forcée (valeurs gérées par le serveur), libellé et type de
   contrôle proposés — hors Num_Doc (convention verrouillée inchangée) et
   hors RV / RowId (identifiants internes du moteur, non affichables).
   Idempotent : ré-exécutable sans erreur.
   ============================================================================ */

SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF COL_LENGTH('dbo.Controle_Designer_Champ', 'Copier_Vers') IS NULL
    ALTER TABLE dbo.Controle_Designer_Champ
        ADD Copier_Vers nvarchar(100) NULL;   -- Cod_Champ de la cible (nvarchar(100))

COMMIT TRANSACTION;
GO

SELECT 'Controle_Designer_Champ.Copier_Vers' AS Colonne,
       CASE WHEN COL_LENGTH('dbo.Controle_Designer_Champ','Copier_Vers') IS NULL THEN 'KO' ELSE 'OK' END AS Etat;
GO
