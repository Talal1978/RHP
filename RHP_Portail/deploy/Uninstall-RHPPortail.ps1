<#
.SYNOPSIS
    Désinstalle RHP_Portail du serveur.

.DESCRIPTION
    1. Arrête le service ET ATTEND la fin effective du processus Node
       (le pool SQL et les sockets peuvent mettre plusieurs secondes à se
       fermer ; arrêter proprement évite tout processus résiduel)
    2. Supprime le service Windows et la règle de pare-feu
    3. Supprime le PROGRAMME (backend\, frontend\, runtime\, nssm.exe —
       réinstallable depuis le package) mais CONSERVE TOUJOURS les données :
       Uploads\ (fichiers GED) et logs\ ne sont jamais touchés.

    Protection par construction : suppression d'une liste EXPLICITE de
    dossiers, jamais de suppression récursive de la racine d'installation.
    L'effacement définitif des données reste une opération MANUELLE, à
    n'effectuer qu'après sauvegarde.

    Se relance tout seul en administrateur (UAC) si besoin.

.EXAMPLE
    .\Uninstall-RHPPortail.ps1
#>
[CmdletBinding()]
param(
    [string]$InstallDir  = "C:\RHP_Portail",
    [string]$ServiceName = "RHP_Portail",
    [switch]$NoPause
)

$ErrorActionPreference = "Stop"

function Write-Etape([string]$msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }
function Pause-Fin([int]$code) {
    if (-not $NoPause) { Write-Host ""; Read-Host "Appuyez sur Entrée pour fermer cette fenêtre" }
    exit $code
}

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

Write-Etape "1/3 - Arrêt du service '$ServiceName' et attente de la fin du processus"
$nssm = "$InstallDir\nssm.exe"
$servicePresent = [bool](Get-Service -Name $ServiceName -ErrorAction SilentlyContinue)
if ($servicePresent) {
    if (Test-Path $nssm) {
        & $nssm stop $ServiceName | Out-Null
    } else {
        Stop-Service -Name $ServiceName -Force -ErrorAction SilentlyContinue
    }
    # Attendre la mort RÉELLE du processus node de cette installation
    # (fermeture du pool SQL et des sockets).
    $attente = 0
    while ($attente -lt 40) {
        $vivants = Get-Process -Name node -ErrorAction SilentlyContinue |
                   Where-Object { $_.Path -and $_.Path.StartsWith($InstallDir) }
        if (-not $vivants) { break }
        Start-Sleep -Milliseconds 500
        $attente++
    }
    # Filet de sécurité : tuer tout node résiduel de CETTE installation
    Get-Process -Name node -ErrorAction SilentlyContinue |
        Where-Object { $_.Path -and $_.Path.StartsWith($InstallDir) } |
        Stop-Process -Force -ErrorAction SilentlyContinue
    Write-Host "Processus arrêté."
} else {
    Write-Host "Service déjà absent."
}

Write-Etape "2/3 - Suppression du service et de la règle de pare-feu"
if ($servicePresent) {
    if (Test-Path $nssm) {
        & $nssm remove $ServiceName confirm | Out-Null
    } else {
        sc.exe delete $ServiceName | Out-Null
    }
    Write-Host "Service supprimé."
}
Get-NetFirewallRule -DisplayName "RHP Portail (TCP *)" -ErrorAction SilentlyContinue |
    Remove-NetFirewallRule
Write-Host "Règle(s) de pare-feu supprimée(s)."

Write-Etape "3/3 - Suppression du PROGRAMME (les données sont TOUJOURS conservées)"
# Règle : on supprime le programme (réinstallable depuis le package), on
# conserve les données et les journaux. Protection PAR CONSTRUCTION : liste
# explicite d'éléments à supprimer — JAMAIS de suppression récursive de la
# racine, donc Uploads\ (GED, données métier) ne peut pas être touché,
# même par accident.
$elementsProgramme = @("backend", "frontend", "runtime", "nssm.exe")
foreach ($e in $elementsProgramme) {
    $chemin = Join-Path $InstallDir $e
    if (Test-Path $chemin) {
        Remove-Item -Recurse -Force $chemin -ErrorAction SilentlyContinue
        if (Test-Path $chemin) {
            Write-Host "  - $e : suppression partielle (fichiers verrouillés)" -ForegroundColor Yellow
        } else {
            Write-Host "  - $e : supprimé"
        }
    }
}
Write-Host ""
Write-Host "CONSERVÉS (jamais supprimés par ce script) :" -ForegroundColor Green
foreach ($e in @("Uploads", "logs")) {
    if (Test-Path (Join-Path $InstallDir $e)) { Write-Host "  - $e\" -ForegroundColor Green }
}
Write-Host ""
Write-Host "  Uploads\ = fichiers GED (DONNÉES MÉTIER — à sauvegarder)"
Write-Host "  logs\    = journaux du service"
Write-Host ""
Write-Host "Pour réinstaller : lancez Install-RHPPortail.ps1 (vos Uploads seront retrouvés)."
Write-Host "Pour effacer définitivement les données : suppression MANUELLE de $InstallDir après sauvegarde."

Write-Host "`nDésinstallation terminée." -ForegroundColor Green
Pause-Fin 0
