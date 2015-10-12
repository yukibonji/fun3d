@echo off
set cur_dir=%~dp0
set root_dir=%cur_dir%\..
%root_dir%\.paket\paket.bootstrapper.exe
if errorlevel 1 (
  exit /b %errorlevel%
)

%root_dir%\.paket\paket.exe restore
if errorlevel 1 (
  exit /b %errorlevel%
)

%root_dir%\packages\FAKE\tools\FAKE.exe %root_dir%\build.fsx %*
