<#
.SYNOPSIS
    Installe RHP_Portail puis installe le service Windows. Un seul clic suffit.

    Deux modes de fonctionnement, détectés automatiquement :
    - PACKAGE PORTABLE : un dossier app\ pré-compilé accompagne ce script
      (serveur du client — AUCUNE compilation, Node.js NON requis) ;
    - POSTE DE DÉVELOPPEMENT : compilation DEPUIS LES SOURCES (rhpBE, rhpfe).

.DESCRIPTION
    1. Fichiers du programme : package portable (app\) ou compilation native
    2. Prépare node_modules de production, node.exe embarqué et NSSM
    3. Demande les paramètres (SQL Server, port, URL) avec test de connexion
    4. Génère les secrets JWT (uniques à cette installation)
    5. Installe le service Windows "RHP_Portail" (démarrage automatique)
    6. Crée la règle de pare-feu et vérifie le fonctionnement (/health)
    7. Journalise tout dans install-journal.txt (dossier deploy\)
    8. En cas d'échec après création du service : rollback automatique

    Prérequis sur le poste : AUCUN en mode package portable (Node.js est
    embarqué dans app\runtime\) ; Node.js + npm uniquement pour compiler
    depuis les sources (poste de développement).

    Se relance tout seul en administrateur (UAC) si besoin.

.EXAMPLE
    # Interactif (questions/réponses) :
    .\Install-RHPPortail.ps1

    # Non interactif (automatisation) :
    .\Install-RHPPortail.ps1 -SqlServer "SRVSQL\SQL2019" -SqlDb RHP -SqlUser sa -SqlPassword "secret" -Port 3500 -PortalUrl "http://srv-rh:3500" -NoPause
#>
[CmdletBinding()]
param(
    [string]$InstallDir  = "C:\RHP_Portail",
    [int]$Port           = 3500,
    [string]$SqlServer   = "",
    [string]$SqlDb       = "RHP",
    [string]$SqlUser     = "sa",
    [string]$SqlPassword = "",
    [string]$PortalUrl   = "",
    [string]$ServiceName = "RHP_Portail",
    [switch]$NoPause
)

$ErrorActionPreference = "Stop"
$source = $PSScriptRoot   # dossier deploy\
$serviceInstalle = $false

# ---------------------------------------------------------------
# Élévation administrateur automatique (clic droit / double-clic)
# ---------------------------------------------------------------
$estAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $estAdmin) {
    Write-Host "Droits administrateur requis : relance du script avec élévation (UAC)..." -ForegroundColor Yellow
    $argList = @("-NoExit", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", "`"$PSCommandPath`"")
    foreach ($k in $PSBoundParameters.Keys) {
        $v = $PSBoundParameters[$k]
        if ($v -is [switch]) { if ($v) { $argList += "-$k" } }
        else { $argList += "-$k"; $argList += "`"$v`"" }
    }
    try {
        Start-Process powershell -Verb RunAs -ArgumentList ($argList -join " ")
    } catch {
        Write-Host "Elévation refusée. Relancez ce script dans une console PowerShell ADMINISTRATEUR." -ForegroundColor Red
        Read-Host "Appuyez sur Entrée pour fermer"
    }
    exit 0
}

function Write-Etape([string]$msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }

function Pause-Fin([int]$code) {
    if (-not $NoPause) {
        Write-Host ""
        Read-Host "Appuyez sur Entrée pour fermer cette fenêtre"
    }
    exit $code
}

function Stop-SiErreur([string]$msg) {
    Write-Host "`n=========================================" -ForegroundColor Red
    Write-Host " ERREUR : $msg" -ForegroundColor Red
    Write-Host "=========================================" -ForegroundColor Red
    # Rollback : si le service a été créé avant l'échec, on le retire pour
    # permettre une réinstallation propre après correction du problème.
    if ($serviceInstalle) {
        Write-Host "Nettoyage du service partiellement installé..." -ForegroundColor Yellow
        & "$InstallDir\nssm.exe" stop $ServiceName 2>$null | Out-Null
        & "$InstallDir\nssm.exe" remove $ServiceName confirm 2>$null | Out-Null
    }
    Write-Host "Détails dans : $PSScriptRoot\install-journal.txt" -ForegroundColor Yellow
    Stop-Transcript | Out-Null
    Pause-Fin 1
}

# Journal de toute l'installation (utile si la fenêtre se ferme)
try { Start-Transcript -Path "$PSScriptRoot\install-journal.txt" -Force | Out-Null } catch { }

try {
    Write-Host "=========================================" -ForegroundColor Cyan
    Write-Host " INSTALLATION DE RHP_PORTAIL" -ForegroundColor Cyan
    Write-Host "=========================================" -ForegroundColor Cyan

    # ---------------------------------------------------------------
    Write-Etape "1/9 - Vérifications"
    $serviceExistant = Get-Service -Name $ServiceName -ErrorAction SilentlyContinue
    if ($serviceExistant) { Stop-SiErreur "Le service '$ServiceName' existe déjà. Pour mettre à jour, utilisez Update-RHPPortail.ps1 ; pour réinstaller, lancez d'abord Uninstall-RHPPortail.ps1." }

    # ---------------------------------------------------------------
    Write-Etape "2/9 - Préparation des fichiers du programme"
    # Mode package portable : le dossier app\ pré-compilé accompagne le
    # script (serveur du client) — aucune compilation, Node.js non requis.
    # Sinon (poste de développement) : compilation depuis les sources.
    $stage = Join-Path $source "app"
    if (Test-Path "$stage\backend") {
        Write-Host "Package portable détecté : programme pré-compilé, aucune compilation nécessaire."
    } else {
        Write-Host "Compilation depuis les sources (poste de développement)..."
        . "$source\Build-RHP.ps1"
        $stage = Invoke-RHPBuild -DeployDir $source
    }
    foreach ($f in @("backend", "frontend", "runtime\node.exe", "nssm.exe")) {
        if (-not (Test-Path (Join-Path $stage $f))) { Stop-SiErreur "Fichier manquant : $f (source $stage)." }
    }

    # ---------------------------------------------------------------
    Write-Etape "3/9 - Paramètres de déploiement"
    if (-not $SqlServer) {
        $SqlServer = Read-Host "Serveur SQL (ex. .\SQL2019, SRVSQL\SQL2019 ou SRVSQL,1433)"
        if (-not $SqlServer) { $SqlServer = ".\SQL2019" }
    }
    $reponse = Read-Host "Base de données [$SqlDb]"
    if ($reponse) { $SqlDb = $reponse }
    $reponse = Read-Host "Utilisateur SQL [$SqlUser]"
    if ($reponse) { $SqlUser = $reponse }
    if (-not $SqlPassword) { $SqlPassword = Read-Host "Mot de passe SQL de '$SqlUser'" }
    $reponse = Read-Host "Port HTTP d'écoute du portail [$Port]"
    if ($reponse) { $Port = [int]$reponse }
    if (-not $PortalUrl) {
        Write-Host "`nURL par laquelle les utilisateurs accéderont au portail" -ForegroundColor Yellow
        Write-Host "(ex. http://srv-rh:$Port ou http://portail.monclient.local — plusieurs URL possibles, séparées par des virgules)"
        $PortalUrl = Read-Host "URL du portail [http://localhost:$Port]"
        if (-not $PortalUrl) { $PortalUrl = "http://localhost:$Port" }
    }
    # Normalisation : un Origin de navigateur comporte TOUJOURS le schéma
    # (http:// ou https://) ; sans lui, l'entrée CORS serait inopérante.
    $PortalUrl = ($PortalUrl -split "," | ForEach-Object {
        $u = $_.Trim()
        if ($u -and $u -notmatch '^https?://') { $u = "http://$u" }
        $u
    }) -join ","
    # Cohérence port d'écoute / port dans l'URL : un écart n'est légitime que
    # derrière un proxy inverse (IIS, nginx) — on avertit sans bloquer.
    $urlsAvecAutrePort = ($PortalUrl -split ",") | Where-Object {
        ($_ -match ':(\d+)$') -and ([int]$Matches[1] -ne $Port)
    }
    if ($urlsAvecAutrePort) {
        Write-Host "`nATTENTION : l'URL contient un port différent du port d'écoute ($Port)." -ForegroundColor Yellow
        Write-Host "  Cela n'est valide que si un proxy inverse écoute sur ce port et relaie vers le port $Port."
        Write-Host "  Sinon, les utilisateurs ne pourront pas joindre le portail par cette URL."
    }
    Write-Host ""
    Write-Host "  Dossier d'installation : $InstallDir"
    Write-Host "  Port HTTP              : $Port"
    Write-Host "  Serveur SQL            : $SqlServer"
    Write-Host "  Base de données        : $SqlDb"
    Write-Host "  URL(s) autorisée(s)    : $PortalUrl"

    # ---------------------------------------------------------------
    Write-Etape "4/9 - Copie des fichiers vers $InstallDir"
    New-Item -ItemType Directory -Path $InstallDir -Force | Out-Null
    foreach ($item in @("backend", "frontend", "runtime", "nssm.exe")) {
        Copy-Item -Recurse -Force (Join-Path $stage $item) -Destination $InstallDir
    }
    New-Item -ItemType Directory -Path "$InstallDir\Uploads" -Force | Out-Null
    New-Item -ItemType Directory -Path "$InstallDir\logs"   -Force | Out-Null

    # ---------------------------------------------------------------
    Write-Etape "5/9 - Configuration SQL Server (avec test de connexion)"
    $nodeExe = "$InstallDir\runtime\node.exe"
    Push-Location "$InstallDir\backend"
    & $nodeExe tools\init-config.js --server $SqlServer --db $SqlDb --user $SqlUser --pwd $SqlPassword --port $Port
    if ($LASTEXITCODE -ne 0) { Pop-Location; Stop-SiErreur "La connexion SQL Server a échoué. Vérifiez : TCP/IP activé dans SQL Server Configuration Manager, service SQL Browser démarré (instance nommée), authentification mixte, identifiants." }
    Pop-Location

    # ---------------------------------------------------------------
    Write-Etape "6/9 - Génération des secrets et du .env"
    function New-CleSecrete([int]$octets = 64) {
        $b = New-Object byte[] $octets
        [System.Security.Cryptography.RandomNumberGenerator]::Create().GetBytes($b)
        return ($b | ForEach-Object { $_.ToString("x2") }) -join ""
    }
    $cle1 = New-CleSecrete
    $cle2 = New-CleSecrete
    $envContenu = @"
NODE_ENV=production
JWT_KEY=$cle1
ACCESS_TOKEN_SECRET=$cle1
REFRESH_TOKEN_SECRET=$cle2
UPLOAD_PATH=$InstallDir\Uploads
STATIC_PATH=$InstallDir\frontend
ALLOWED_ORIGINS=$PortalUrl
RATE_LIMIT_MAX=5000
"@
    [System.IO.File]::WriteAllText("$InstallDir\backend\.env", $envContenu, [System.Text.UTF8Encoding]::new($false))
    Write-Host "Secrets JWT générés (uniques à cette installation)."

    # ---------------------------------------------------------------
    Write-Etape "7/9 - Installation du service Windows '$ServiceName'"
    $nssm = "$InstallDir\nssm.exe"
    & $nssm install $ServiceName "$InstallDir\runtime\node.exe" "dist\src\index.js" | Out-Null
    $serviceInstalle = $true
    & $nssm set $ServiceName AppDirectory "$InstallDir\backend" | Out-Null
    & $nssm set $ServiceName DisplayName "RHP Portail" | Out-Null
    & $nssm set $ServiceName Description "Portail collaborateur RHP (backend Node.js + frontend)" | Out-Null
    & $nssm set $ServiceName Start SERVICE_AUTO_START | Out-Null
    & $nssm set $ServiceName AppStdout "$InstallDir\logs\service.log" | Out-Null
    & $nssm set $ServiceName AppStderr "$InstallDir\logs\service-err.log" | Out-Null
    & $nssm set $ServiceName AppRotateFiles 1 | Out-Null
    & $nssm set $ServiceName AppRotateOnline 1 | Out-Null
    & $nssm set $ServiceName AppRotateBytes 10485760 | Out-Null
    # Redémarrage automatique en cas de plantage
    & $nssm set $ServiceName AppExit Default Restart | Out-Null
    & $nssm set $ServiceName AppRestartDelay 3000 | Out-Null
    Write-Host "Service installé (démarrage automatique + redémarrage sur plantage)."

    # ---------------------------------------------------------------
    Write-Etape "8/9 - Règle de pare-feu (TCP $Port) et démarrage"
    $regle = Get-NetFirewallRule -DisplayName "RHP Portail (TCP $Port)" -ErrorAction SilentlyContinue
    if (-not $regle) {
        New-NetFirewallRule -DisplayName "RHP Portail (TCP $Port)" -Direction Inbound -Protocol TCP -LocalPort $Port -Action Allow | Out-Null
        Write-Host "Règle de pare-feu créée."
    } else {
        Write-Host "Règle de pare-feu déjà présente."
    }
    & $nssm start $ServiceName | Out-Null
    $demarre = $false
    for ($i = 0; $i -lt 15; $i++) {
        Start-Sleep -Seconds 2
        $svc = Get-Service -Name $ServiceName
        if ($svc.Status -eq "Running") { $demarre = $true; break }
    }
    if (-not $demarre) {
        Write-Host "Le service ne démarre pas. Journal :" -ForegroundColor Red
        Get-Content "$InstallDir\logs\service-err.log" -ErrorAction SilentlyContinue | Select-Object -Last 20
        Stop-SiErreur "Echec de démarrage du service (voir logs ci-dessus et dans $InstallDir\logs\)."
    }

    # ---------------------------------------------------------------
    Write-Etape "9/9 - Vérification du portail"
    $ok = $false
    for ($i = 0; $i -lt 10; $i++) {
        try {
            $h = Invoke-RestMethod -Uri "http://localhost:$Port/health" -TimeoutSec 5
            if ($h.status -eq "ok") { $ok = $true; break }
        } catch { Start-Sleep -Seconds 3 }
    }
    Write-Host ""
    if ($ok) {
        Write-Host "=========================================" -ForegroundColor Green
        Write-Host " INSTALLATION REUSSIE" -ForegroundColor Green
        Write-Host "=========================================" -ForegroundColor Green
        Write-Host " Portail accessible sur : $PortalUrl"
        Write-Host " Santé du service       : http://localhost:$Port/health"
        Write-Host " Service Windows        : $ServiceName (démarrage automatique)"
        Write-Host " Journaux               : $InstallDir\logs\"
        Write-Host " Fichiers GED           : $InstallDir\Uploads\  <- A SAUVEGARDER"
    } else {
        Write-Host "Le service tourne mais /health ne répond pas encore." -ForegroundColor Yellow
        Write-Host "Vérifiez dans quelques instants : http://localhost:$Port/health"
        Write-Host "Journaux : $InstallDir\logs\service.log"
    }
    Stop-Transcript | Out-Null
    Pause-Fin 0
}
catch {
    Stop-SiErreur $_.Exception.Message
}
