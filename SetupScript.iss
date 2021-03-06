; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "BirthDayS"
#define MyAppVersion "2.1"
#define MyAppPublisher "Danil 'scrolltex' Kalashnikov"
#define MyAppURL "http://www.scrolltex.ru"
#define MyAppExeName "BirthDayS.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{82FCBC04-EDCA-4B6C-BF3F-436EC699D6A4}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
OutputBaseFilename=BirthDayS-setup
SetupIconFile=C:\Projects\Archive\BirthDayS\BirthDayS\app.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "russian"; MessagesFile: "compiler:Languages\Russian.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1

[Files]
Source: "C:\Projects\Archive\BirthDayS\BirthDayS\bin\Release\BirthDayS.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\Archive\BirthDayS\BirthDayS_Tools\bin\Release\BDTools.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\Archive\BirthDayS\BIRTH.DAY"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\Archive\BirthDayS\Birthday1.wav"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\Archive\BirthDayS\Birthday2.wav"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Projects\Archive\BirthDayS\readme.docx"; DestDir: "{app}"; Flags: isreadme
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:ProgramOnTheWeb,{#MyAppName}}"; Filename: "{#MyAppURL}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

