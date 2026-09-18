<#
.SYNOPSIS
    Génère le PACKAGE PORTABLE de RHP_Portail : un ZIP autonome à copier sur
    le serveur du client pour y installer (ou mettre à jour) le portail SANS
    les sources et SANS Node.js — tout est pré-compilé et embarqué.

.DESCRIPTION
    1. Compile le frontend (rhpfe) et le backend (rhpBE) DEPUIS LES SOURCES
       (bibliothèque Build-RHP.ps1 — poste de développement uniquement)
    2. Assemble le package :
         app\                     <- programme complet pré-compilé
           backend\               <- rhpBE compilé + node_modules de prod + outils
           frontend\              <- build Vite
           runtime\node.exe       <- Node.js embarqué (aucun prérequis serveur)
           nssm.exe               <- gestionnaire de service Windows
         Install-RHPPortail.ps1   <- installation (détecte le mode portable)
         Update-RHPPortail.ps1    <- mise à jour (conserve config et données)
         Config-RHPPortail.ps1    <- reconfiguration SQL / port (redémarre le service)
         Uninstall-RHPPortail.ps1 <- désinstallation (conserve Uploads\ et logs\)
         LISEZ-MOI.txt            <- instructions pour le client
         README.md                <- documentation complète
         iis-optionnel\           <- config HTTPS facultative (reverse proxy IIS)
    3. Compresse le tout dans deploy\dist\RHP_Portail_Portable_v<version>_<date>.zip

    Côté serveur du client : extraire le ZIP, exécuter Install-RHPPortail.ps1
    (les scripts détectent le dossier app\ et sautent la compilation).

    Prérequis sur le poste qui lance CET export : les sources (rhpBE, rhpfe)
    et Node.js + npm. Aucune élévation administrateur n'est requise.

.EXAMPLE
    # Export standard (ZIP dans deploy\dist\) :
    .\Export-RHPPortail.ps1

    # Export vers un autre dossier, sans pause finale :
    .\Export-RHPPortail.ps1 -OutDir "D:\Livraisons" -NoPause
#>
[CmdletBinding()]
param(
    [string]$OutDir = "",
    [switch]$NoPause
)

$ErrorActionPreference = "Stop"
$source = $PSScriptRoot   # dossier deploy\

function Write-Etape([string]$msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }
function Pause-Fin([int]$code) {
    if (-not $NoPause) { Write-Host ""; Read-Host "Appuyez sur Entrée pour fermer cette fenêtre" }
    exit $code
}
function Stop-SiErreur([string]$msg) { Write-Host "`nERREUR : $msg" -ForegroundColor Red; Pause-Fin 1 }

try {
    Write-Host "=========================================" -ForegroundColor Cyan
    Write-Host " EXPORT DU PACKAGE PORTABLE RHP_PORTAIL" -ForegroundColor Cyan
    Write-Host "=========================================" -ForegroundColor Cyan

    # ---------------------------------------------------------------
    Write-Etape "1/4 - Compilation du projet (build natif depuis les sources)"
    . "$source\Build-RHP.ps1"
    $stage = Invoke-RHPBuild -DeployDir $source

    # ---------------------------------------------------------------
    Write-Etape "2/4 - Assemblage du package"
    $racine  = Split-Path $source -Parent          # RHP_Portail
    $version = (Get-Content "$racine\rhpBE\package.json" -Raw | ConvertFrom-Json).version
    $pkgName = "RHP_Portail_Portable_v{0}_{1}" -f $version, (Get-Date -Format "yyyyMMdd_HHmm")
    $pkgDir  = Join-Path $source ".cache\package\$pkgName"
    if (Test-Path $pkgDir) { Remove-Item -Recurse -Force $pkgDir }
    New-Item -ItemType Directory -Path $pkgDir -Force | Out-Null

    # app\ = programme complet pré-compilé (détecté par Install/Update)
    Copy-Item -Recurse $stage (Join-Path $pkgDir "app")
    # Scripts d'exploitation côté client + documentation
    foreach ($f in @("Install-RHPPortail.ps1", "Update-RHPPortail.ps1", "Config-RHPPortail.ps1", "Uninstall-RHPPortail.ps1", "LISEZ-MOI.txt", "README.md")) {
        Copy-Item (Join-Path $source $f) $pkgDir
    }
    if (Test-Path "$source\iis-optionnel") { Copy-Item -Recurse "$source\iis-optionnel" $pkgDir }

    # Contrôle d'intégrité : le package doit être autonome à 100 %
    foreach ($f in @("app\backend\dist", "app\backend\node_modules", "app\backend\tools\init-config.js",
                     "app\frontend\index.html", "app\runtime\node.exe", "app\nssm.exe",
                     "Install-RHPPortail.ps1", "Update-RHPPortail.ps1", "Config-RHPPortail.ps1", "Uninstall-RHPPortail.ps1", "LISEZ-MOI.txt")) {
        if (-not (Test-Path (Join-Path $pkgDir $f))) { Stop-SiErreur "Package incomplet : $f manquant." }
    }
    Write-Host "Package assemblé : $pkgName"

    # ---------------------------------------------------------------
    Write-Etape "3/4 - Compression du ZIP (plusieurs minutes possibles)"
    if (-not $OutDir) { $OutDir = Join-Path $source "dist" }
    New-Item -ItemType Directory -Path $OutDir -Force | Out-Null
    $zipPath = Join-Path $OutDir "$pkgName.zip"
    if (Test-Path $zipPath) { Remove-Item -Force $zipPath }
    Add-Type -AssemblyName System.IO.Compression
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    # includeBaseDirectory = $true : le ZIP contient le dossier racine du
    # package — « Extraire tout » produit un seul dossier propre.
    [System.IO.Compression.ZipFile]::CreateFromDirectory($pkgDir, $zipPath, [System.IO.Compression.CompressionLevel]::Optimal, $true)

    # ---------------------------------------------------------------
    Write-Etape "4/4 - Nettoyage et vérification"
    Remove-Item -Recurse -Force (Split-Path $pkgDir -Parent)   # .cache\package
    Add-Type -AssemblyName System.IO.Compression.FileSystem
    $entrees = [System.IO.Compression.ZipFile]::OpenRead($zipPath).Entries.Count
    $tailleMo = (Get-Item $zipPath).Length / 1MB

    Write-Host ""
    Write-Host "=========================================" -ForegroundColor Green
    Write-Host " PACKAGE PORTABLE PRET" -ForegroundColor Green
    Write-Host "=========================================" -ForegroundColor Green
    Write-Host (" Fichier   : {0}" -f $zipPath)
    Write-Host (" Taille    : {0:N0} Mo ({1} fichiers)" -f $tailleMo, $entrees)
    Write-Host ""
    Write-Host " Copiez ce ZIP sur le serveur du client, extrayez-le," -ForegroundColor Yellow
    Write-Host " puis lancez Install-RHPPortail.ps1 (aucune compilation," -ForegroundColor Yellow
    Write-Host " aucun prérequis : Node.js est embarqué)." -ForegroundColor Yellow
    Pause-Fin 0
}
catch {
    Stop-SiErreur $_.Exception.Message
}
