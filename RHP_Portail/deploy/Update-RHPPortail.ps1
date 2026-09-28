<#
.SYNOPSIS
    Met à jour RHP_Portail : remplace le programme sur le serveur,
    EN CONSERVANT configuration et données.

    Deux modes de fonctionnement, détectés automatiquement :
    - PACKAGE PORTABLE : un dossier app\ pré-compilé accompagne ce script
      (serveur du client — AUCUNE compilation, Node.js NON requis) ;
    - POSTE DE DÉVELOPPEMENT : compilation DEPUIS LES SOURCES (rhpBE, rhpfe).

.DESCRIPTION
    1. Fichiers du programme : package portable (app\) ou compilation native
    2. Arrête le service "RHP_Portail"
    3. Remplace le programme (backend\dist, node_modules, tools, frontend,
       runtime, nssm) en CONSERVANT :
         - backend\serverConfig.json  (connexion SQL)
         - backend\.env               (secrets JWT, chemins, CORS)
         - Uploads\                   (fichiers GED)
         - logs\
    4. Redémarre le service et vérifie (/health)

    Prérequis sur le poste : AUCUN en mode package portable (Node.js est
    embarqué dans app\runtime\) ; Node.js + npm uniquement pour compiler
    depuis les sources (poste de développement).
    Se relance tout seul en administrateur (UAC) si besoin.

.EXAMPLE
    .\Update-RHPPortail.ps1
    .\Update-RHPPortail.ps1 -InstallDir "D:\RHP_Portail"
#>
[CmdletBinding()]
param(
    [string]$InstallDir  = "C:\RHP_Portail",
    [string]$ServiceName = "RHP_Portail",
    [switch]$NoPause
)

$ErrorActionPreference = "Stop"
$source = $PSScriptRoot

function Write-Etape([string]$msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }
function Pause-Fin([int]$code) {
    if (-not $NoPause) { Write-Host ""; Read-Host "Appuyez sur Entrée pour fermer cette fenêtre" }
    exit $code
}
function Stop-SiErreur([string]$msg) { Write-Host "`nERREUR : $msg" -ForegroundColor Red; Pause-Fin 1 }

# Élévation administrateur automatique (clic droit / double-clic)
$estAdmin = ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole]::Administrator)
if (-not $estAdmin) {
    Write-Host "Droits administrateur requis : relance du script avec élévation (UAC)..." -ForegroundColor Yellow
    $argList = @("-NoExit", "-NoProfile", "-ExecutionPolicy", "Bypass", "-File", "`"$PSCommandPath`"")
    foreach ($k in $PSBoundParameters.Keys) {
        $v = $PSBoundParameters[$k]
        if ($v -is [switch]) { if ($v) { $argList += "-$k" } }
        else { $argList += "-$k"; $argList += "`"$v`"" }
    }
    try { Start-Process powershell -Verb RunAs -ArgumentList ($argList -join " ") }
    catch { Write-Host "Elévation refusée. Relancez ce script en administrateur." -ForegroundColor Red; Read-Host "Appuyez sur Entrée pour fermer" }
    exit 0
}

try {
    Write-Etape "1/6 - Vérifications"
    if (-not (Test-Path "$InstallDir\backend\serverConfig.json")) { Stop-SiErreur "Installation existante introuvable dans $InstallDir. Utilisez Install-RHPPortail.ps1 pour une première installation." }
    $svc = Get-Service -Name $ServiceName -ErrorAction SilentlyContinue
    if (-not $svc) { Stop-SiErreur "Service '$ServiceName' introuvable." }
    # Impression des états Crystal : l'outil crexport.exe (embarqué dans le
    # package) est compilé AnyCPU « 32 bits préféré » (32BITPREF) : il exige le
    # runtime SAP Crystal Reports pour .NET Framework 32 bits sur le serveur —
    # avertissement non bloquant.
    $crRuntime = "C:\Program Files (x86)\SAP BusinessObjects\Crystal Reports for .NET Framework 4.0\Common\SAP BusinessObjects Enterprise XI 4.0\win32_x86\crpe32.dll"
    if (-not (Test-Path $crRuntime)) {
        Write-Host "`nATTENTION : le runtime SAP Crystal Reports pour .NET Framework (32 bits)" -ForegroundColor Yellow
        Write-Host "ne semble pas installé sur ce serveur. L'impression des états Crystal" -ForegroundColor Yellow
        Write-Host "(génération PDF) échouera tant qu'il n'aura pas été installé." -ForegroundColor Yellow
    }
    # Le DSN ODBC (Param_General.ODBC_RHP, par défaut « RHP ») doit exister en
    # DSN SYSTÈME 32 bits (WOW6432Node) : un DSN utilisateur ou un DSN système
    # 64 bits est invisible pour crexport.exe, processus 32 bits (échec
    # « Impossible de démarrer la connexion ») — avertissement non bloquant.
    $dsn32 = "HKLM:\SOFTWARE\WOW6432Node\ODBC\ODBC.INI\RHP"
    if (-not (Test-Path $dsn32)) {
        Write-Host "`nATTENTION : aucun DSN système 32 bits 'RHP' n'est défini sur ce serveur." -ForegroundColor Yellow
        Write-Host "L'impression des états Crystal échouera (« Impossible de démarrer la connexion »)." -ForegroundColor Yellow
        Write-Host "Créez un DSN SYSTÈME 32 bits (odbcad32.exe, %WINDIR%\SysWOW64) nommé comme" -ForegroundColor Yellow
        Write-Host "Param_General.ODBC_RHP (pilote 'SQL Server') — voir deploy\README.md." -ForegroundColor Yellow
    }

    # ---------------------------------------------------------------
    Write-Etape "2/6 - Préparation des fichiers du programme"
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

    # ---------------------------------------------------------------
    Write-Etape "3/6 - Arrêt du service"
    & "$InstallDir\nssm.exe" stop $ServiceName | Out-Null
    Start-Sleep -Seconds 5
    # Attendre la mort réelle du processus node de cette installation
    $attente = 0
    while ($attente -lt 40) {
        $vivants = Get-Process -Name node -ErrorAction SilentlyContinue |
                   Where-Object { $_.Path -and $_.Path.StartsWith($InstallDir) }
        if (-not $vivants) { break }
        Start-Sleep -Milliseconds 500
        $attente++
    }
    Write-Host "Service arrêté."

    # ---------------------------------------------------------------
    Write-Etape "4/6 - Sauvegarde de la configuration"
    $confBak = Join-Path $env:TEMP "rhp_conf_$(Get-Date -Format 'yyyyMMddHHmmss')"
    New-Item -ItemType Directory -Path $confBak -Force | Out-Null
    Copy-Item "$InstallDir\backend\serverConfig.json" $confBak
    Copy-Item "$InstallDir\backend\.env" $confBak
    Write-Host "Configuration sauvegardée dans $confBak"

    # ---------------------------------------------------------------
    Write-Etape "5/6 - Remplacement du programme (config et données conservées)"
    Remove-Item -Recurse -Force "$InstallDir\backend\dist"         -ErrorAction SilentlyContinue
    Remove-Item -Recurse -Force "$InstallDir\backend\node_modules" -ErrorAction SilentlyContinue
    Remove-Item -Recurse -Force "$InstallDir\backend\tools"        -ErrorAction SilentlyContinue
    Copy-Item -Recurse "$stage\backend\dist"         "$InstallDir\backend\dist"
    Copy-Item -Recurse "$stage\backend\node_modules" "$InstallDir\backend\node_modules"
    Copy-Item -Recurse "$stage\backend\tools"        "$InstallDir\backend\tools"
    Copy-Item "$stage\backend\package.json" "$InstallDir\backend\"
    # Sortie temporaire des PDF Crystal (conservée si présente, recréée sinon)
    New-Item -ItemType Directory -Path "$InstallDir\backend\tmp" -Force | Out-Null
    # Frontend : remplacement complet
    Remove-Item -Recurse -Force "$InstallDir\frontend" -ErrorAction SilentlyContinue
    Copy-Item -Recurse "$stage\frontend" "$InstallDir\frontend"
    # Runtime et NSSM
    Copy-Item "$stage\runtime\node.exe" "$InstallDir\runtime\node.exe" -Force
    Copy-Item "$stage\nssm.exe" "$InstallDir\nssm.exe" -Force
    # Restauration de la config (sécurité : ne jamais l'écraser)
    Copy-Item "$confBak\serverConfig.json" "$InstallDir\backend\serverConfig.json" -Force
    Copy-Item "$confBak\.env" "$InstallDir\backend\.env" -Force
    Write-Host "Programme remplacé ; configuration, Uploads\ et logs\ conservés."

    # ---------------------------------------------------------------
    Write-Etape "6/6 - Redémarrage et vérification"
    & "$InstallDir\nssm.exe" start $ServiceName | Out-Null
    $port = (Get-Content "$InstallDir\backend\serverConfig.json" | ConvertFrom-Json).port
    $ok = $false
    for ($i = 0; $i -lt 15; $i++) {
        Start-Sleep -Seconds 2
        try {
            $h = Invoke-RestMethod -Uri "http://localhost:$port/health" -TimeoutSec 5
            if ($h.status -eq "ok") { $ok = $true; break }
        } catch { }
    }
    if ($ok) {
        Write-Host "`nMISE A JOUR REUSSIE - le portail est de nouveau en ligne sur le port $port." -ForegroundColor Green
    } else {
        Write-Host "`nLe service redémarre mais /health ne répond pas encore." -ForegroundColor Yellow
        Write-Host "Vérifiez les journaux : $InstallDir\logs\"
    }
    Pause-Fin 0
}
catch {
    Stop-SiErreur $_.Exception.Message
}
