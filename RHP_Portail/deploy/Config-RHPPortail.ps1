<#
.SYNOPSIS
    Reconfigure RHP_Portail (connexion SQL Server, port HTTP) SANS
    réinstallation : les valeurs actuelles de serverConfig.json sont
    proposées par défaut (Entrée = conserver, mot de passe inclus), la
    nouvelle connexion est testée, puis le service Windows est redémarré.

.DESCRIPTION
    À utiliser quand la configuration SQL change : nouveau serveur ou
    instance, base renommée, identifiants / mot de passe modifiés — ou
    pour changer le port HTTP d'écoute du portail.

    1. Affiche la configuration actuelle (sans le mot de passe)
    2. Redemande chaque paramètre avec la valeur actuelle par défaut ;
       la connexion SQL est TESTÉE avant toute écriture — en cas d'échec
       ou d'abandon, la configuration précédente est conservée
       (backend\tools\init-config.js)
    3. Crée la règle de pare-feu du nouveau port si celui-ci a changé
    4. Redémarre le service "RHP_Portail" et vérifie /health
    5. Journalise tout dans config-journal.txt (dossier deploy\)

    Se relance tout seul en administrateur (UAC) si besoin.

.EXAMPLE
    # Interactif (questions/réponses) :
    .\Config-RHPPortail.ps1
#>
[CmdletBinding()]
param(
    [string]$InstallDir  = "C:\RHP_Portail",
    [string]$ServiceName = "RHP_Portail",
    [switch]$NoPause
)

$ErrorActionPreference = "Stop"

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
    Write-Host "Détails dans : $PSScriptRoot\config-journal.txt" -ForegroundColor Yellow
    Stop-Transcript | Out-Null
    Pause-Fin 1
}

# Journal de toute la reconfiguration (utile si la fenêtre se ferme)
try { Start-Transcript -Path "$PSScriptRoot\config-journal.txt" -Force | Out-Null } catch { }

try {
    Write-Host "=========================================" -ForegroundColor Cyan
    Write-Host " RECONFIGURATION DE RHP_PORTAIL" -ForegroundColor Cyan
    Write-Host "=========================================" -ForegroundColor Cyan

    # ---------------------------------------------------------------
    Write-Etape "1/4 - Vérifications et configuration actuelle"
    $backend    = Join-Path $InstallDir "backend"
    $configPath = Join-Path $backend "serverConfig.json"
    $nodeExe    = Join-Path $InstallDir "runtime\node.exe"
    if (-not (Test-Path $configPath)) { Stop-SiErreur "Installation existante introuvable dans $InstallDir (serverConfig.json absent). Utilisez Install-RHPPortail.ps1 pour une première installation." }
    if (-not (Test-Path $nodeExe))    { Stop-SiErreur "Node.js embarqué introuvable : $nodeExe. Installation incomplète ?" }
    if (-not (Test-Path "$backend\tools\init-config.js")) { Stop-SiErreur "Outil de configuration introuvable : $backend\tools\init-config.js. Mettez à jour l'installation (Update-RHPPortail.ps1)." }

    $cfg = Get-Content $configPath -Raw | ConvertFrom-Json
    $ancienPort = [int]$cfg.port
    Write-Host "  Serveur SQL     : $($cfg.server)"
    Write-Host "  Base de données : $($cfg.db)"
    Write-Host "  Utilisateur SQL : $($cfg.user)"
    Write-Host "  Port HTTP       : $ancienPort"
    Write-Host "  Mot de passe    : (non affiché — conservé si laissé vide)"

    # ---------------------------------------------------------------
    Write-Etape "2/4 - Nouvelle configuration (Entrée = conserver la valeur actuelle)"
    Write-Host "La connexion SQL est testée AVANT toute écriture : en cas d'échec" -ForegroundColor Yellow
    Write-Host "ou d'interruption (Ctrl+C), la configuration précédente est conservée." -ForegroundColor Yellow
    Push-Location $backend
    & $nodeExe tools\init-config.js
    $rc = $LASTEXITCODE
    Pop-Location
    if ($rc -ne 0) { Stop-SiErreur "Reconfiguration annulée ou connexion SQL impossible. La configuration PRÉCÉDENTE est conservée et le service n'a PAS été redémarré. Vérifiez : TCP/IP activé, service SQL Browser démarré (instance nommée), authentification mixte, identifiants." }

    $nouveauPort = [int](Get-Content $configPath -Raw | ConvertFrom-Json).port

    # ---------------------------------------------------------------
    Write-Etape "3/4 - Règle de pare-feu"
    if ($nouveauPort -ne $ancienPort) {
        $regle = Get-NetFirewallRule -DisplayName "RHP Portail (TCP $nouveauPort)" -ErrorAction SilentlyContinue
        if (-not $regle) {
            New-NetFirewallRule -DisplayName "RHP Portail (TCP $nouveauPort)" -Direction Inbound -Protocol TCP -LocalPort $nouveauPort -Action Allow | Out-Null
            Write-Host "Règle de pare-feu créée pour le nouveau port ($nouveauPort)."
        } else {
            Write-Host "Règle de pare-feu déjà présente pour le port $nouveauPort."
        }
        Write-Host "Le port a changé ($ancienPort -> $nouveauPort) :" -ForegroundColor Yellow
        Write-Host "  - l'ancienne règle 'RHP Portail (TCP $ancienPort)' peut être supprimée (Pare-feu Windows) ;" -ForegroundColor Yellow
        Write-Host "  - adaptez l'URL du portail dans $backend\.env (ALLOWED_ORIGINS) si elle mentionne l'ancien port." -ForegroundColor Yellow
    } else {
        Write-Host "Port inchangé ($ancienPort) : règle de pare-feu existante conservée."
    }

    # ---------------------------------------------------------------
    Write-Etape "4/4 - Redémarrage du service '$ServiceName'"
    $service = Get-Service -Name $ServiceName -ErrorAction SilentlyContinue
    if (-not $service) {
        Write-Host "Configuration écrite, mais le service '$ServiceName' est introuvable." -ForegroundColor Yellow
        Write-Host "La nouvelle configuration sera prise en compte au prochain démarrage du portail."
        Stop-Transcript | Out-Null
        Pause-Fin 0
    }
    & "$InstallDir\nssm.exe" restart $ServiceName | Out-Null
    $demarre = $false
    for ($i = 0; $i -lt 15; $i++) {
        Start-Sleep -Seconds 2
        if ((Get-Service -Name $ServiceName).Status -eq "Running") { $demarre = $true; break }
    }
    if (-not $demarre) {
        Write-Host "Le service ne redémarre pas. Journal :" -ForegroundColor Red
        Get-Content "$InstallDir\logs\service-err.log" -ErrorAction SilentlyContinue | Select-Object -Last 20
        Stop-SiErreur "Echec de redémarrage du service (voir logs ci-dessus et dans $InstallDir\logs\)."
    }

    # Vérification du portail sur le (nouveau) port
    $ok = $false
    for ($i = 0; $i -lt 10; $i++) {
        try {
            $h = Invoke-RestMethod -Uri "http://localhost:$nouveauPort/health" -TimeoutSec 5
            if ($h.status -eq "ok") { $ok = $true; break }
        } catch { Start-Sleep -Seconds 3 }
    }
    Write-Host ""
    if ($ok) {
        Write-Host "=========================================" -ForegroundColor Green
        Write-Host " RECONFIGURATION REUSSIE" -ForegroundColor Green
        Write-Host "=========================================" -ForegroundColor Green
        Write-Host " Santé du service : http://localhost:$nouveauPort/health"
        Write-Host " Le portail tourne avec la nouvelle configuration SQL."
    } else {
        Write-Host "Le service tourne mais /health ne répond pas encore." -ForegroundColor Yellow
        Write-Host "Vérifiez dans quelques instants : http://localhost:$nouveauPort/health"
        Write-Host "Journaux : $InstallDir\logs\service.log"
    }
    Stop-Transcript | Out-Null
    Pause-Fin 0
}
catch {
    Stop-SiErreur $_.Exception.Message
}
