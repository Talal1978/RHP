# Examples

| Exemple | Contenu | Objectif |
|---|---|---|
| `01-frais-km-input.yaml` | Input canonique de la page FRAIS_KM | Reproduit le script officiel `002_SP_Designer_Exemple_FKM.sql` (+ critères de `003_...sql`) : sert d'oracle — la sortie générée ne doit en différer que cosmétiquement. |
| `02-teletravail/` | Package complet : `input.yaml`, `preflight.sql`, `deploy.sql`, `rollback.sql`, `manifest.md` | Exemple abouti de bout en bout : ENT + DET, zoom, champ calculé persisté, source métier, validations, workflow, droits. |

Mode d'emploi de l'exemple 02 sur une base de test :

```bash
sqlcmd -S .\SQL2019 -d RHP -i preflight.sql                 # tout KO = bloquant
sqlcmd -S .\SQL2019 -d RHP -i deploy.sql                    # dry-run (@DryRun=1)
# passer @DryRun a 0 dans deploy.sql, puis :
sqlcmd -S .\SQL2019 -d RHP -i deploy.sql                    # deploiement reel
sqlcmd -S .\SQL2019 -d RHP -i rollback.sql                  # dry-run rollback
```
