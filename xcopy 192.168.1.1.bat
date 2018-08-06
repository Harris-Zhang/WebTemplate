@ECHO OFF
CLS
color 0a

GOTO MENU
:MENU
ECHO.
ECHO. =-=-=-=-=COPY MES APP MENU=-=-=-=-=
ECHO.
ECHO. 1 COPY
ECHO.
ECHO. 2 QUIT
ECHO.
echo. Please input menu number£º
set /p id= 
if "%id%"=="1" goto cmd1
EXIT

:cmd1
echo COPY KAN_BAN APPLICATION FILES TO SPECIFIED DESTINATIONS

XCOPY Web\*.* \\192.168.1.1\inetpub\Fixture_KB /S /I /Y /D /EXCLUDE:D:\zzh\webform\SYSTemplate\exclude.txt

set id=nul
GOTO MENU
