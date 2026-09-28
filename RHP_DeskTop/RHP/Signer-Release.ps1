#requires -Version 5.1
<#
.SYNOPSIS
    Signe RHP.exe avec le certificat de signature de code de l'éditeur (Authenticode).

.DESCRIPTION
    La signature Authenticode attache la confiance des antivirus et de Windows à
    l'identité de l'éditeur (certificat) plutôt qu'au hash de chaque exe : les
    nouvelles versions héritent de la réputation — fin des faux positifs à chaque
    déploiement client.

    L'horodatage RFC 3161 garantit que la signature reste valide après
    l'expiration du certificat.

    Prérequis (une seule fois) :
      1. Certificat « Code Signing » (OV) au nom de l'éditeur, installé dans le
         magasin Personnel du compte courant (double-clic sur le .pfx) ou
         accessible via l'outil du fournisseur (token / HSM cloud).
      2. signtool.exe du Windows SDK (déjà présent avec Visual Studio).

.EXAMPLE
    .\Signer-Release.ps1
    Signe bin\Release\RHP.exe (par défaut).

.EXAMPLE
    .\Signer-Release.ps1 -CheminExe "bin\Debug\RHP.exe"
    Signe un autre exe.

.NOTES
    Après signature, vérifier dans l'Explorateur : clic droit sur RHP.exe >
    Propriétés > onglet « Signatures numériques » > « Metafay.solutions ».
#>
param(
    [string]$CheminExe = (Join-Path $PSScriptRoot "bin\Release\RHP.exe"),
    [string]$Editeur = "Metafay.solutions",
    [string]$Description = "RHP",
    [string]$Horodatage = "http://timestamp.digicert.com"
)

$ErrorActionPreference = "Stop"

# ---- 1. Localiser signtool.exe (dernière version du Windows Kits, x64) -------
$kits = "C:\Program Files (x86)\Windows Kits\10\bin"
$signtool = Get-ChildItem $kits -Recurse -Filter "signtool.exe" -ErrorAction SilentlyContinue |
            Where-Object { $_.FullName -match '\\x64\\' } |
            Sort-Object FullName -Descending |
            Select-Object -First 1 -ExpandProperty FullName
if (-not $signtool) {
    Write-Error "signtool.exe introuvable. Installez le Windows SDK (composant « Windows 10/11 SDK » de Visual Studio)."
}
Write-Host "signtool : $signtool" -ForegroundColor DarkGray

# ---- 2. Vérifier le certificat de signature de code ---------------------------
$cert = Get-ChildItem Cert:\CurrentUser\My |
        Where-Object { $_.Subject -like "*$Editeur*" -and $_.HasPrivateKey } |
        Sort-Object NotAfter -Descending |
        Select-Object -First 1
if (-not $cert) {
    Write-Error ("Aucun certificat avec clé privée trouvé pour « $Editeur » dans Cert:\CurrentUser\My.`n" +
                 "Importez d'abord le certificat de signature de code (double-clic sur le .pfx > magasin Personnel).")
}
Write-Host "Certificat : $($cert.Subject)" -ForegroundColor DarkGray
Write-Host ("Validité   : {0:dd/MM/yyyy} -> {1:dd/MM/yyyy}" -f $cert.NotBefore, $cert.NotAfter) -ForegroundColor DarkGray
if ($cert.NotAfter -lt (Get-Date)) {
    Write-Warning "Le certificat est EXPIRÉ : les fichiers déjà signés restent valides (horodatage), mais renouvelez-le pour signer à nouveau."
}

# ---- 3. Vérifier le fichier cible ---------------------------------------------
if (-not (Test-Path -LiteralPath $CheminExe)) {
    Write-Error "Fichier introuvable : $CheminExe"
}

# ---- 4. Signature (SHA-256 + horodatage RFC 3161) ------------------------------
Write-Host "Signature de $CheminExe ..." -ForegroundColor Cyan
& $signtool sign /fd sha256 /td sha256 /tr $Horodatage /n $Editeur /d $Description /v "$CheminExe"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Échec de la signature (signtool code $LASTEXITCODE). Vérifiez le certificat et l'accès à l'horodatage ($Horodatage)."
}

# ---- 5. Vérification ------------------------------------------------------------
& $signtool verify /pa "$CheminExe" | Out-Null
if ($LASTEXITCODE -ne 0) {
    Write-Error "La vérification de la signature a échoué."
}
Write-Host "OK : $CheminExe est signé « $Editeur » (signature vérifiée)." -ForegroundColor Green
Write-Host "Contrôle visuel : clic droit sur le fichier > Propriétés > Signatures numériques." -ForegroundColor DarkGray
