# Déploiement de RHP_Portail (Windows, sans Docker ni IIS)

Architecture : **un seul processus Node.js** sert le frontend (fichiers
statiques du build Vite), l'API REST et les websockets — aucun IIS, aucun
proxy à configurer. Le processus tourne comme **service Windows** (via NSSM)
avec démarrage automatique et redémarrage en cas de plantage. **Node.js est
embarqué** à l'installation : rien à installer sur le serveur cible, hormis
SQL Server (déjà présent pour RHP_DeskTop) et — uniquement pour l'**impression
des états Crystal (PDF)** — le runtime SAP Crystal Reports pour .NET
Framework 64 bits (voir [Prérequis pour l'impression des états Crystal](#prérequis-pour-limpression-des-états-crystal-pdf)).

## Utilisation — 5 scripts, un clic chacun

| Action | Script | Ce qu'il fait |
|---|---|---|
| **Exporter** (poste de dev) | `Export-RHPPortail.ps1` | Compile le projet et génère le **package portable ZIP** (`deploy\dist\RHP_Portail_Portable_v*.zip`) à copier sur le serveur du client |
| **Installer** | `Install-RHPPortail.ps1` | Installe : fichiers dans `C:\RHP_Portail`, connexion SQL (testée), secrets JWT uniques, service Windows, pare-feu, vérification. Depuis les sources (compilation) **ou** depuis le package portable (dossier `app\`, sans compilation) |
| **Mettre à jour** | `Update-RHPPortail.ps1` | Remplace le programme **en conservant** configuration (`serverConfig.json`, `.env`), fichiers GED (`Uploads\`) et journaux — mêmes deux modes que l'installation |
| **Reconfigurer** | `Config-RHPPortail.ps1` | Modifie la connexion SQL et/ou le port HTTP **sans réinstaller** : valeurs actuelles proposées (Entrée = conserver, mot de passe inclus), connexion testée avant écriture, règle de pare-feu ajustée, service redémarré |
| **Désinstaller** | `Uninstall-RHPPortail.ps1` | Retire le service et le pare-feu, supprime le programme (`backend`, `frontend`, `runtime`, `nssm.exe`) en **conservant toujours** `Uploads\` et `logs\` |

Lancement : clic droit sur le script → *Exécuter avec PowerShell* (le script
demande lui-même l'élévation UAC), ou en console :

```powershell
powershell -ExecutionPolicy Bypass -File .\Install-RHPPortail.ps1
```

> **Prérequis sur le poste qui lance le script** : en mode **package
> portable**, AUCUN prérequis (Node.js est embarqué dans `app\runtime\`) —
> c'est le mode du **serveur du client**. En mode **sources** (poste de
> développement), les sources du projet (`rhpBE`, `rhpfe`) et Node.js + npm
> sont requis pour compiler. `Build-RHP.ps1` est une bibliothèque interne
> utilisée par les scripts d'export, d'installation et de mise à jour :
> ne pas l'exécuter directement.

## Déploiement chez le client (package portable ZIP)

Pour déployer sur un serveur **sans y copier les sources** (et sans y
installer Node.js) :

1. **Sur le poste de développement** : exécutez `Export-RHPPortail.ps1`.
   Il compile le projet et produit
   `deploy\dist\RHP_Portail_Portable_v<version>_<date>.zip`.
2. **Copiez le ZIP** sur le serveur du client (clé USB, partage, ...) et
   extrayez-le (*Extraire tout*).
3. **Sur le serveur du client** : exécutez `Install-RHPPortail.ps1` (ou
   `Update-RHPPortail.ps1` si le portail y est déjà installé). Le script
   détecte le dossier `app\` pré-compilé et saute la compilation — le
   déroulé est ensuite identique (questions SQL, service, pare-feu,
   vérification).

Le ZIP est totalement autonome : `app\` (backend compilé + node_modules de
production + frontend buildé + Node.js embarqué + NSSM), les quatre scripts
d'exploitation, `LISEZ-MOI.txt` (instructions client), `README.md` et
`iis-optionnel\`.

## Ce que fait l'installation, en détail

```
Serveur Windows
└── C:\RHP_Portail\
    ├── runtime\node.exe      <- Node.js embarqué (aucun prérequis)
    ├── backend\              <- rhpBE compilé + node_modules de prod
    │   ├── serverConfig.json <- connexion SQL (générée à l'install)
    │   ├── .env              <- secrets JWT, chemins, CORS (généré à l'install)
    │   ├── tools\CRExport\   <- crexport.exe : génération PDF des états Crystal
    │   └── tmp\              <- PDF temporaires (supprimés après envoi)
    ├── frontend\             <- build Vite (servi par le backend)
    ├── Uploads\              <- fichiers GED (À SAUVEGARDER)
    ├── logs\                 <- journaux du service
    └── nssm.exe              <- gestionnaire du service "RHP_Portail"
```

L'installateur demande interactivement :

- **Serveur SQL** : `.\SQL2019`, `SRVSQL\SQL2019` ou `SRVSQL,1433`
  (la connexion est **testée** avant de continuer) ;
- **base / utilisateur / mot de passe SQL** ;
- **port HTTP** d'écoute (défaut 3500) ;
- **URL du portail** telle que les utilisateurs la taperont — normalisée
  automatiquement (ajout de `http://` si oublié, avertissement si le port de
  l'URL diffère du port d'écoute).

Mode non interactif possible (automatisation) :

```powershell
.\Install-RHPPortail.ps1 -SqlServer "SRVSQL\SQL2019" -SqlDb RHP -SqlUser sa `
    -SqlPassword "secret" -Port 3500 -PortalUrl "http://srv-rh:3500" -NoPause
```

### Vérification après installation

- `http://<serveur>:<port>/health` → `{"status":"ok","db":"connected",...}`
- `http://<serveur>:<port>/` → la page de connexion du portail
- Journaux : `C:\RHP_Portail\logs\service.log` et `deploy\install-journal.txt`

## Changer la configuration SQL (serveur, base, identifiants, port)

Quand la configuration SQL Server change (nouveau serveur ou instance,
base renommée, mot de passe modifié...) ou pour changer le port HTTP :

1. **Sur le serveur**, exécutez `Config-RHPPortail.ps1` (clic droit →
   *Exécuter avec PowerShell*).
2. La configuration actuelle est affichée (sans le mot de passe) et chaque
   paramètre est redemandé **avec sa valeur actuelle par défaut** :
   `Entrée` = conserver, y compris le mot de passe (jamais affiché).
3. La nouvelle connexion est **testée avant toute écriture** : en cas
   d'échec ou d'interruption, l'ancienne configuration est conservée.
4. Le service `RHP_Portail` est **redémarré automatiquement** et
   `/health` est vérifié. Si le port a changé, la règle de pare-feu du
   nouveau port est créée (pensez alors à adapter `ALLOWED_ORIGINS` dans
   `.env` et à supprimer l'ancienne règle).

Équivalents manuels possibles (puis `Restart-Service RHP_Portail`) :
`C:\RHP_Portail\runtime\node.exe tools\init-config.js` depuis
`C:\RHP_Portail\backend`, ou les variables `SQL_SERVER`, `SQL_DB`,
`SQL_USER`, `SQL_PASSWORD`, `PORT` du `.env` qui **surchargent**
`serverConfig.json`.

## Prérequis côté SQL Server

- **TCP/IP activé** (SQL Server Configuration Manager → Protocoles → TCP/IP)
  et le **service SQL Server Browser** démarré si instance nommée
  (`SRV\SQL2019`). Recommandé : fixer un port TCP statique sur l'instance et
  utiliser la forme `SRV,1433`.
- **Authentification mixte** (SQL Server et Windows) activée — le portail se
  connecte en authentification SQL (`sa` ou un compte dédié).
- Les **migrations SQL** du portail (`rhpBE\sql\...`) doivent être appliquées
  à la base du client, comme pour toute mise à jour RHP.

## Prérequis pour l'impression des états Crystal (PDF)

L'impression des états (bulletins, attestations, notes de frais...) passe par
l'outil **`crexport.exe`**, embarqué dans le package
(`backend\tools\CRExport\`) et piloté par le backend : il charge le modèle
`.rpt` (dossier désigné par `Param_General.Lecteur_Digital_Mod_Edition` —
**ce chemin doit exister sur le serveur du portail**, lecteur local ou
partage accessible au service) et produit un PDF temporaire
(`backend\tmp\`, purgé après envoi).

Pour fonctionner, `crexport.exe` exige sur le serveur :

1. **.NET Framework 4.8** (présent d'office sur Windows Server 2016+ /
   Windows 10-11 à jour) ;
2. **le runtime SAP Crystal Reports pour .NET Framework, 32 bits** (version
   13.0.x — redistribuable `CRforVS` SP ≥ 33, MSI **x86**). Attention :
   `crexport.exe` est compilé **AnyCPU « 32 bits préféré »** (CorFlags
   `32BITPREF=1`) : même sur Windows 64 bits, il s'exécute en processus
   **32 bits** et charge le runtime Crystal 32 bits — le runtime 64 bits seul
   est inutilisable. L'installateur et l'updater vérifient sa présence
   (`...\SAP BusinessObjects Enterprise XI 4.0\win32_x86\crpe32.dll`) et
   affichent un avertissement s'il est absent ;
3. **un DSN système 32 bits** nommé comme `Param_General.ODBC_RHP` (par défaut
   `RHP`), pointant sur l'instance SQL du client (pilote « SQL Server »,
   `SQLSRV32.dll`). `crexport.exe` s'y connecte par
   `DataSourceConnections(0).SetConnection(odbc, db, ...)`. Attention : un
   **DSN utilisateur** (visible seulement dans la session qui l'a créé) ou un
   DSN système **64 bits** ne sont **pas vus** par un processus 32 bits —
   l'impression échoue alors avec « Impossible de démarrer la connexion » ou
   « Echec de la connexion à la base de données » dans
   `logs\service-err.log` alors que le Desktop fonctionne. Création par
   script (registre, vue **WOW6432Node**) :
   `HKLM\SOFTWARE\WOW6432Node\ODBC\ODBC.INI\<NomDSN>` (valeurs `Driver` =
   `C:\WINDOWS\system32\SQLSRV32.dll`, `Server`, `Database`) + valeur
   `<NomDSN>` = `SQL Server` sous
   `HKLM\SOFTWARE\WOW6432Node\ODBC\ODBC.INI\ODBC Data Sources`.

Sans ce runtime, la génération PDF échoue avec un message explicite (le
portail affiche la cause, et le détail est journalisé dans
`logs\service-err.log`).

## Accès depuis les autres postes du réseau

Le backend écoute sur toutes les interfaces réseau et le CORS accepte
**automatiquement toute origine identique à l'hôte demandé** : le portail est
immédiatement accessible par `http://<nom-du-serveur>:<port>` depuis les
autres postes, sans configuration. Pour un nom plus parlant (ex.
`http://portail:3500`), créez un alias DNS (CNAME) pointant sur le serveur —
aucune modification du portail n'est nécessaire.

## Sauvegardes à prévoir

| Élément | Chemin | Fréquence |
|---|---|---|
| Fichiers GED | `C:\RHP_Portail\Uploads\` | Quotidienne |
| Configuration | `C:\RHP_Portail\backend\serverConfig.json` + `.env` | Après chaque changement |
| Base SQL | base du client (inclut les métadonnées GED) | Selon politique existante |

## Variables d'environnement du backend (.env)

| Variable | Rôle | Défaut |
|---|---|---|
| `NODE_ENV` | `production` active le rate-limiting | — |
| `JWT_KEY`, `ACCESS_TOKEN_SECRET`, `REFRESH_TOKEN_SECRET` | Secrets JWT — **générés aléatoirement à l'install, uniques par installation** | — |
| `UPLOAD_PATH` | Dossier des fichiers GED | `Uploads` sous le backend |
| `STATIC_PATH` | Dossier du build frontend servi par le backend | `..\frontend` |
| `ALLOWED_ORIGINS` | Origines CORS **inter-origines** uniquement (frontend hébergé ailleurs, nom public derrière un proxy). **Inutile pour l'accès normal** : toute origine identique à l'hôte demandé est acceptée automatiquement | localhost (dev) |
| `RATE_LIMIT_MAX` | Requêtes max / IP / 15 min (production) | `200` — **l'installateur règle 5000** car les employés d'un site partagent souvent une IP |
| `TRUST_PROXY` | `1` si un proxy inverse (IIS/ARR) est devant | désactivé |
| `COOKIE_SECURE` | `true` si HTTPS (cookie `Secure` + `SameSite=None`) | `false` (HTTP intranet) |
| `PORT`, `SQL_SERVER`, `SQL_DB`, `SQL_USER`, `SQL_PASSWORD` | Surchargent `serverConfig.json` | — |

## Option : HTTPS via IIS en frontal

Le portail tourne en HTTP sur l'intranet. Si le client exige du HTTPS (ou le
port 443), IIS peut servir de reverse proxy devant le service Node :

1. Installer IIS + les modules **ARR** (Application Request Routing) et
   **URL Rewrite**, activer le proxy ARR et la fonctionnalité **WebSocket**.
2. Créer un site IIS avec le certificat HTTPS, y placer le fichier
   [`iis-optionnel/web.config`](iis-optionnel/web.config) (adapter le port).
3. Dans `.env` du backend : `TRUST_PROXY=1`, `COOKIE_SECURE=true`, et mettre
   l'URL `https://...` dans `ALLOWED_ORIGINS`. Redémarrer le service.

## Dépannage

| Symptôme | Piste |
|---|---|
| Le script « se ferme tout de suite » | Lancé sans droits admin, il se relève de lui-même (UAC) — acceptez. Sinon lisez `install-journal.txt` (dossier deploy\) : le message d'erreur y figure toujours |
| Le service ne démarre pas | `logs\service-err.log` ; tester à la main : `cd C:\RHP_Portail\backend && ..\runtime\node.exe dist\src\index.js` |
| `ECHEC connexion SQL` à l'install | TCP/IP activé ? SQL Browser démarré (instance nommée) ? Identifiants ? Pare-feu 1433 ? |
| Page blanche / erreur CORS dans le navigateur | Uniquement en accès **inter-origines** (proxy avec nom public différent) : ajouter l'URL publique à `ALLOWED_ORIGINS` (.env) et redémarrer le service. L'accès direct par le nom/IP du serveur est accepté automatiquement |
| 429 « Trop de requêtes » | Augmenter `RATE_LIMIT_MAX` dans .env (utilisateurs derrière une même IP/NAT) |
| Déconnexion toutes les 15 min | `COOKIE_SECURE=true` alors que le site est en HTTP → le cookie de rafraîchissement est rejeté ; passer à `false` ou mettre en place le HTTPS |
| `serverConfig.json introuvable...` dans les logs | Ne peut arriver que si le fichier a été supprimé ; le régénérer avec `Config-RHPPortail.ps1` (ou `C:\RHP_Portail\backend\tools\init-config.js` avec le node embarqué) |
| L'impression d'un état (PDF) échoue | Le message affiché indique la cause ; détails dans `logs\service-err.log` (`[REPORT]`). Vérifier dans l'ordre : 1) `C:\RHP_Portail\backend\tools\CRExport\crexport.exe` présent (sinon redéployer — les packages antérieurs ne l'embarquaient pas), 2) runtime SAP Crystal Reports pour .NET 64 bits installé (voir section prérequis ci-dessus), 3) le chemin `Param_General.Lecteur_Digital_Mod_Edition` existe **pour le service** et contient le `.rpt` — attention : un **lecteur réseau mappé** (ex. `R:\`) n'existe que dans la session utilisateur qui l'a monté, le service ne le voit pas ; renseigner le **chemin UNC** (`\\serveur\partage`, accessible en lecture par le compte du service — LocalSystem par défaut), 4) « Impossible de démarrer la connexion » / « Echec de la connexion à la base de données » dans le log = **DSN ODBC** (`Param_General.ODBC_RHP`, défaut `RHP`) absent en **DSN système 32 bits** sur le serveur (un DSN utilisateur ou un DSN système 64 bits est invisible pour `crexport.exe`, processus 32 bits — voir prérequis ci-dessus), 5) tester à la main : `cd C:\RHP_Portail\backend && tools\CRExport\crexport.exe -r "<chemin>\<etat>.rpt" -u <user> -pw <pwd> -o <odbc> -db <base> -f tmp\test.pdf -p "" -v ""` |
