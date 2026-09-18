<#
.SYNOPSIS
    Build-RHP.ps1 — NE PAS EXÉCUTER DIRECTEMENT.

.DESCRIPTION
    Bibliothèque de build utilisée par Install-RHPPortail.ps1 et
    Update-RHPPortail.ps1. Compile le frontend et le backend DEPUIS LES
    SOURCES (rhpfe, rhpBE) et prépare le dossier intermédiaire (staging) :

        deploy\.cache\stage\
          backend\    <- rhpBE compilé + node_modules de PRODUCTION + outils
          frontend\   <- build Vite
          runtime\    <- node.exe embarqué (aucun prérequis sur le serveur)
          nssm.exe    <- gestionnaire de service Windows

    Prérequis sur le poste qui lance le build : Node.js + npm (poste de
    développement). Le serveur cible, lui, n'a besoin de rien.
#>

function Invoke-RHPBuild {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)][string]$DeployDir
    )

    $ErrorActionPreference = "Stop"
    $racine = Split-Path $DeployDir -Parent          # RHP_Portail
    $rhpBE  = Join-Path $racine "rhpBE"
    $rhpfe  = Join-Path $racine "rhpfe"
    $stage  = Join-Path $DeployDir ".cache\stage"

    function Write-Etape([string]$msg) { Write-Host "`n=== $msg ===" -ForegroundColor Cyan }

    # ---------------------------------------------------------------
    Write-Etape "BUILD 1/5 - Vérifications (sources, Node.js, npm)"
    if (-not (Test-Path "$rhpBE\package.json")) { throw "Sources backend introuvables : $rhpBE`nLancez ce script depuis le dossier deploy\ du projet RHP_Portail." }
    if (-not (Test-Path "$rhpfe\package.json")) { throw "Sources frontend introuvables : $rhpfe`nLancez ce script depuis le dossier deploy\ du projet RHP_Portail." }
    if (-not (Get-Command node -ErrorAction SilentlyContinue)) { throw "Node.js introuvable : il est requis pour compiler (poste de développement)." }
    if (-not (Get-Command npm -ErrorAction SilentlyContinue))  { throw "npm introuvable : il est requis pour compiler (poste de développement)." }
    $nodeVersion = (node --version).TrimStart('v')
    Write-Host "Sources : $racine"
    Write-Host "Node.js : v$nodeVersion"

    # ---------------------------------------------------------------
    Write-Etape "BUILD 2/5 - Compilation du frontend (rhpfe)"
    Push-Location $rhpfe
    npm run build | Out-Host   # Out-Host : affiche sans polluer le pipeline de retour
    if ($LASTEXITCODE -ne 0) { Pop-Location; throw "Echec de la compilation du frontend." }
    Pop-Location

    # ---------------------------------------------------------------
    Write-Etape "BUILD 3/5 - Compilation du backend (rhpBE)"
    Push-Location $rhpBE
    npm run build | Out-Host
    if ($LASTEXITCODE -ne 0) { Pop-Location; throw "Echec de la compilation du backend." }
    Pop-Location

    # ---------------------------------------------------------------
    Write-Etape "BUILD 4/5 - node_modules de production + staging"
    if (Test-Path $stage) { Remove-Item -Recurse -Force $stage }
    New-Item -ItemType Directory -Path "$stage\backend\tools" -Force | Out-Null
    New-Item -ItemType Directory -Path "$stage\frontend" -Force | Out-Null
    New-Item -ItemType Directory -Path "$stage\runtime" -Force | Out-Null
    Copy-Item -Recurse "$rhpBE\dist" "$stage\backend\dist"
    Copy-Item "$rhpBE\package.json" "$stage\backend\"
    Copy-Item "$rhpBE\package-lock.json" "$stage\backend\"
    Copy-Item "$rhpBE\tools\init-config.js" "$stage\backend\tools\"
    Push-Location "$stage\backend"
    npm ci --omit=dev | Out-Host
    if ($LASTEXITCODE -ne 0) { Pop-Location; throw "Echec de npm ci --omit=dev (dépendances de production)." }
    Pop-Location
    Copy-Item -Recurse "$rhpfe\dist\*" "$stage\frontend\"

    # ---------------------------------------------------------------
    Write-Etape "BUILD 5/5 - Runtime Node embarqué + NSSM"
    $nodeExe = "$stage\runtime\node.exe"
    $nodeCache = Join-Path $DeployDir ".cache\node-$nodeVersion-win-x64.exe"
    if (Test-Path $nodeCache) {
        Copy-Item $nodeCache $nodeExe -Force
        Write-Host "node.exe repris du cache local."
    } else {
        $nodeUrl = "https://nodejs.org/dist/v$nodeVersion/win-x64/node.exe"
        Write-Host "Téléchargement : $nodeUrl"
        New-Item -ItemType Directory -Path (Split-Path $nodeCache -Parent) -Force | Out-Null
        $null = Invoke-WebRequest -Uri $nodeUrl -OutFile $nodeCache -UseBasicParsing
        Copy-Item $nodeCache $nodeExe -Force
    }

    $nssmExe = "$stage\nssm.exe"
    $nssmLocal = Join-Path $DeployDir "nssm.exe"
    if (Test-Path $nssmLocal) {
        Copy-Item $nssmLocal $nssmExe -Force
        Write-Host "nssm.exe repris du cache local (deploy\nssm.exe)."
    } else {
        # nssm.cc étant parfois indisponible, on essaie plusieurs sources
        $sources = @(
            "https://nssm.cc/release/nssm-2.24.zip",
            "https://community.chocolatey.org/api/v2/package/NSSM/2.24.101.20180116"
        )
        $telecharge = $false
        foreach ($url in $sources) {
            try {
                Write-Host "Téléchargement : $url"
                $zipTmp = "$env:TEMP\nssm_dl.zip"
                $null = Invoke-WebRequest -Uri $url -OutFile $zipTmp -UseBasicParsing -TimeoutSec 60
                if (Test-Path "$env:TEMP\nssm_dl") { Remove-Item -Recurse -Force "$env:TEMP\nssm_dl" }
                Expand-Archive -Path $zipTmp -DestinationPath "$env:TEMP\nssm_dl" -Force
                $zipInterne = Get-ChildItem -Recurse "$env:TEMP\nssm_dl" -Filter "nssm-*.zip" | Select-Object -First 1
                if ($zipInterne) { Expand-Archive -Path $zipInterne.FullName -DestinationPath "$env:TEMP\nssm_dl" -Force }
                $exe = Get-ChildItem -Recurse "$env:TEMP\nssm_dl" -Filter "nssm.exe" |
                       Where-Object { $_.FullName -match 'win64' } | Select-Object -First 1
                if ($exe) {
                    Copy-Item $exe.FullName $nssmExe
                    Copy-Item $exe.FullName $nssmLocal   # cache pour la prochaine fois
                    $telecharge = $true
                    break
                }
            } catch {
                Write-Host "  -> échec ($($_.Exception.Message)), source suivante..." -ForegroundColor Yellow
            }
        }
        if (-not $telecharge) {
            throw "NSSM introuvable : téléchargez nssm.exe (win64) depuis https://nssm.cc et placez-le dans deploy\, puis relancez."
        }
    }

    Write-Host "`nStaging prêt : $stage" -ForegroundColor Green
    return $stage
}
