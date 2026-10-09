# Signe RHP.exe avec le certificat dev "RHP Dev Code Signing (Metafy.solutions)".
# Volontairement HORS du .vbproj : une commande PowerShell dans le PostBuildEvent
# a fait mettre RHP.vbproj en quarantaine par Kaspersky le 04/10/2026.
# Usage : apres un build, executer ce script manuellement si une signature est
# necessaire (poste de dev). Sans effet si le certificat est absent.
$ErrorActionPreference = 'Stop'
$cert = Get-ChildItem Cert:\CurrentUser\My -CodeSigningCert |
        Where-Object Subject -like '*RHP Dev Code Signing*' |
        Sort-Object NotAfter -Descending | Select-Object -First 1
if (-not $cert) {
    Write-Host 'Certificat dev RHP introuvable dans Cert:\CurrentUser\My' -ForegroundColor Red
    exit 1
}
$targets = @(
    "$PSScriptRoot\..\RHP\bin\Debug\RHP.exe",
    "$PSScriptRoot\..\RHP\bin\Release\RHP.exe"
) | Where-Object { Test-Path $_ }
if (-not $targets) { Write-Host 'Aucun RHP.exe a signer (bin\Debug ni bin\Release).'; exit 0 }
foreach ($t in $targets) {
    try {
        $r = Set-AuthenticodeSignature -FilePath $t -Certificate $cert -HashAlgorithm SHA256 -TimestampServer 'http://timestamp.digicert.com' -ErrorAction Stop
    } catch {
        $r = Set-AuthenticodeSignature -FilePath $t -Certificate $cert -HashAlgorithm SHA256
    }
    Write-Host ("{0} -> {1}" -f $t, $r.Status)
}
