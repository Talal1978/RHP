@echo off
rem ============================================================
rem Installe le certificat de signature dev RHP dans les magasins
rem MACHINE (Racine de confiance + Editeurs approuves).
rem A executer EN ADMINISTRATEUR (clic droit ^> Executer en tant
rem qu'administrateur). Sans cette etape, la signature de RHP.exe
rem existe mais Windows/Kaspersky ne font pas confiance a
rem l'editeur. A refaire sur chaque poste de dev.
rem ============================================================
certutil -addstore -f Root "%~dp0RHP_DevCodeSigning.cer"
certutil -addstore -f TrustedPublisher "%~dp0RHP_DevCodeSigning.cer"
echo.
echo Si les deux lignes ci-dessus reussissent, le certificat est
rem approuve au niveau machine.
pause
