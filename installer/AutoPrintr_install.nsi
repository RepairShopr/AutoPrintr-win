; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there.

;--------------------------------
; saving version.txt file
!system "version.exe"

SetCompressor /FINAL lzma

!include LogicLib.nsh
Icon "..\resources\ico\48x48.ico"
; Application icon and logo
; !include "MUI2.nsh"

; !define MUI_ICON "..\resources\ico\AutoPrintr.ico"
; !define MUI_HEADERIMAGE
; !define MUI_HEADERIMAGE_BITMAP "..\resources\installer.bmp"
; !define MUI_HEADERIMAGE_RIGHT

; The name of the installer
Name "AutoPrintr"

; The file to write
OutFile "AutoPrintr_install.exe"

; The default installation directory
InstallDir $PROGRAMFILES\AutoPrintr

; Request application privileges for Windows >=Vista
RequestExecutionLevel admin

!getdllversion "..\AutoPrintr\bin\Release\AutoPrintr.exe" appv_
LicenseText "AutoPrintr v.${appv_1}.${appv_2}.${appv_3} License"
; LicenseText "AutoPrintr v.${version} License"
LicenseData "..\LICENSE"

!define AppName "AutoPrintr.exe"
!define ServiceName "AutoPrintrService"

;--------------------------------

Function saveVersion
    FileOpen $R0 "$EXEDIR\version.txt" w ;Opens a Empty File an fills it
    FileWrite $R0 "${appv_1}.${appv_2}.${appv_3}.${appv_4}"
    FileClose $R0 ;Closes the filled file
FunctionEnd



!macro stopApp un
    Function ${un}stopApp
        DetailPrint "Stoping AutoPrintr.exe"
        ExecWait 'cmd /C "Taskkill /F /IM AutoPrintr.exe"'
        ; nsExec::Exec 'cmd /C "Taskkill /F /IM AutoPrintr.exe"'
        ; FindProcDLL::FindProc ${AppName}
        ; ${If} $R0 == 1
        ;     DetailPrint "Stopping the AutoPrintr"
        ;     ; KillProcDLL::KillProc  ${AppName}
        ;     Sleep 1500
        ;     ; FindProcDLL::WaitProcEnd ${AppName} -1
        ;     Abort
        ; ${EndIf}
    FunctionEnd
!macroend

!insertmacro stopApp ""
!insertmacro stopApp "un."


; start_type - one of the following codes
!define SERVICE_BOOT_START 0        ; Driver boot stage start
!define SERVICE_SYSTEM_START 1      ; Driver scm stage start
!define SERVICE_AUTO_START 2        ; Service auto start (Should be used in most cases)
!define SERVICE_DEMAND_START 3      ; Driver/service manual start
!define SERVICE_DISABLED 4          ; Driver/service disabled

; service_status - one of the following codes
!define SERVICE_STOPPED 1
!define SERVICE_START_PENDING 2
!define SERVICE_STOP_PENDING 3
!define SERVICE_RUNNING 4
!define SERVICE_CONTINUE_PENDING 5
!define SERVICE_PAUSE_PENDING 6
!define SERVICE_PAUSED 7


Var isRunService

!macro stopService un

    Function ${un}stopService
        StrCpy $isRunService "false"

        DetailPrint "Searching if service installed"
        SimpleSC::ExistsService ${ServiceName}
        Pop $0
        ${If} $0 == 0

            DetailPrint "    Service is installed"
            DetailPrint "    Checking service start type"
            SimpleSC::GetServiceStartType ${ServiceName}
            Pop $0 ; returns an errorcode (<>0) otherwise success (0)
            Pop $1 ; returns the start type of the service (see "start_type" in the parameters)
            ${If} $1 == ${SERVICE_AUTO_START}

                StrCpy $isRunService "true" ; Set flag to autostart service after update
                DetailPrint "        Service start type is AUTO_START"
                DetailPrint "        Checking if service is running"

                SimpleSC::GetServiceStatus  ${ServiceName}
                Pop $0 ; returns an errorcode (<>0) otherwise success (0)
                Pop $1 ; return the status of the service (See "service_status" in the parameters)
                ${If} $1 == ${SERVICE_RUNNING}

                    DetailPrint "            Service is running"
                    DetailPrint "            Stoping service"

                    SimpleSC::StopService ${ServiceName} 1 30
                    Pop $0 ; returns an errorcode (<>0) otherwise success (0)
                    ${If} $0 != 0

                        Push $0
                        SimpleSC::GetErrorMessage
                        Pop $0
                        DetailPrint "                Service stop error: $0"

                    ${Else}
                        DetailPrint "                Service stop success"
                    ${EndIf}

                ${Else}
                    DetailPrint "        Service not running"
                ${EndIf}

                DetailPrint "            Service removing"
                SimpleSC::RemoveService ${ServiceName}
                Pop $0
                ${If} $0 != 0
                    Push $0
                    SimpleSC::GetErrorMessage
                    Pop $0
                    DetailPrint "                Service remove error: $0"
                ${Else}
                    DetailPrint "                Service remove success"
                ${EndIf}

            ${Else}
                DetailPrint "    Service start type not AUTO_START"
            ${EndIf}

        ${Else}
            DetailPrint "Service not installed"
        ${EndIf}

    FunctionEnd

!macroend

!insertmacro stopService ""
!insertmacro stopService "un."

Function startServiceIfNeed
    ${If} $isRunService == "true"

        DetailPrint "Installing service"
        ExecWait '"$INSTDIR\AutoPrintrService.exe" /i'
        ; nsExec::Exec 'cmd /C "$INSTDIR\AutoPrintrService.exe /i"'
        ; Sleep 3000
        DetailPrint "Starting service"
        SimpleSC::StartService ${ServiceName} "" 30
        Pop $0 ; returns an errorcode (<>0) otherwise success (0)
        ${If} $0 != 0

            Push $0
            SimpleSC::GetErrorMessage
            Pop $0
            DetailPrint "    Service start error: $0"

        ${Else}
            DetailPrint "    Service start success"
        ${EndIf}
    ${EndIf}
FunctionEnd


Function un.stopAll
    call un.stopApp
    call un.stopService
FunctionEnd

;--------------------------------

; Pages

Page license
Page directory
Page instfiles


UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "" ;No components page, name is not important

    ; FindProcDLL::FindProc ${AppName}
    ; IntCmp $R0 1 0 notRunning
    ;     FindProcDLL::KillProc  ${AppName}
    ;     FindProcDLL::WaitProcEnd ${AppName} -1
    ;     MessageBox MB_OK|MB_ICONEXCLAMATION "MyApp is running." /SD IDOK
    ;     Abort
    ; notRunning:
    ;     MessageBox MB_OK|MB_ICONEXCLAMATION "MyApp isnt unning." /SD IDOK
    ;     Abort

    call stopService
    ; Abort
    call stopApp
    call saveVersion

    ; nsExec::Exec 'cmd /C "Taskkill /F /IM AutoPrintr.exe"'
    ; Sleep 1500
    ; Set output path to the installation directory.
    SetOutPath $INSTDIR

    ; Put file there
    ; Allow to store old configuration
    SetOverwrite off
    File ..\AutoPrintr\bin\Release\AutoPrintr.exe.config
    SetOverwrite on

    ; All other files
    File ..\AutoPrintrService\bin\Release\AutoPrintrService.exe
    File ..\AutoPrintrService\bin\Release\AutoPrintrService.exe.config
    File ..\AutoPrintr\bin\Release\AutoPrintr.exe
    File ..\AutoPrintr\bin\Release\PusherClient.dll
    File ..\AutoPrintr\bin\Release\WebSocket4Net.dll
    File ..\AutoPrintr\bin\Release\Newtonsoft.Json.dll
    File ..\AutoPrintr\bin\Release\NLog.dll
    File ..\AutoPrintr\bin\Release\NamedPipeWrapper.dll
    File ..\resources\skin.json
    File ..\resources\NLog.config
    File ..\resources\SumatraPDF.exe

    ;create desktop shortcut
    CreateShortCut "$DESKTOP\AutoPrintr.lnk" "$INSTDIR\AutoPrintr.exe" ""

    ;create start-menu items
    CreateDirectory "$SMPROGRAMS\AutoPrintr"
    CreateShortCut "$SMPROGRAMS\AutoPrintr\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0
    CreateShortCut "$SMPROGRAMS\AutoPrintr\AutoPrintr.lnk" "$INSTDIR\AutoPrintr.exe" "" "$INSTDIR\AutoPrintr.exe" 0

    WriteUninstaller "uninstall.exe"

    call startServiceIfNeed

SectionEnd ; end the section

Function .onInit
    UserInfo::GetAccountType
    pop $0
    ${If} $0 != "admin" ;Require admin rights on NT4+
        MessageBox mb_iconstop "Administrator rights required!"
        SetErrorLevel 740 ;ERROR_ELEVATION_REQUIRED
        Quit
    ${EndIf}
FunctionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"

    SetOutPath $TEMP

    ; nsExec::Exec 'cmd /C "Taskkill /F /IM AutoPrintr.exe"'
    ; nsExec::Exec 'cmd /C "$INSTDIR\AutoPrintrService.exe /u"'

    call un.stopAll
    ExecWait '"$INSTDIR\AutoPrintrService.exe" /u'
    ; nsExec::Exec 'cmd /C "$INSTDIR\AutoPrintrService.exe /u"'
    ; FindProcDLL::WaitProcEnd "AutoPrintrService.exe" -1
    ; Sleep 3000
    ; Remove files and uninstaller
    Delete $INSTDIR\*

    Delete "$DESKTOP\AutoPrintr.lnk"
    Delete "$SMPROGRAMS\AutoPrintr\*.*"
    RmDir  "$SMPROGRAMS\AutoPrintr"

    ; Remove directories used
    RMDir /r /REBOOTOK $INSTDIR

SectionEnd
