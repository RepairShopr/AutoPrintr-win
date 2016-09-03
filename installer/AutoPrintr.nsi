; example1.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

;--------------------------------
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
OutFile "AutoPrintr.exe"

; The default installation directory
InstallDir $PROGRAMFILES\AutoPrintr

; Request application privileges for Windows >=Vista
RequestExecutionLevel admin

!getdllversion "..\AutoPrintr\bin\Release\AutoPrintr.exe" appv_
LicenseText "AutoPrintr v.${appv_1}.${appv_2}.${appv_3} License"
; LicenseText "AutoPrintr v.${version} License"
LicenseData "..\LICENSE"

;--------------------------------

; Function WriteToFile
; Exch $0 ;file to write to
; Exch
; Exch $1 ;text to write
 
;   FileOpen $0 $0 a #open file
;   FileSeek $0 0 END #go to end
;   FileWrite $0 $1 #write to file
;   FileClose $0
 
; Pop $1
; Pop $0
; FunctionEnd

; Push `` ;text to write to file 
; Push `version.txt` ;file to write to 
; Call WriteToFile

Function saveVersion
    FileOpen $R0 "$EXEDIR\version.txt" w ;Opens a Empty File an fills it
    FileWrite $R0 "${appv_1}.${appv_2}.${appv_3}.${appv_4}"
    FileClose $R0 ;Closes the filled file
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

    call saveVersion
    ; ExecWait 'Taskkill /F /IM AutoPrintr.exe'
    ; Sleep 1500
    ; Set output path to the installation directory.
    SetOutPath $INSTDIR

    ; Put file there
    ; Allow to store old configuration
    SetOverwrite off
    File ..\AutoPrintr\bin\Release\AutoPrintr.exe.config
    SetOverwrite on
    ; All other files
    File ..\AutoPrintr\bin\Release\AutoPrintr.exe
    File ..\AutoPrintr\skin.json
    File ..\AutoPrintr\bin\Release\SumatraPDF.exe
    File ..\AutoPrintr\bin\Release\PusherClient.dll
    File ..\AutoPrintr\bin\Release\WebSocket4Net.dll
    File ..\AutoPrintr\bin\Release\Newtonsoft.Json.dll
    File ..\AutoPrintr\NLog.config
    File ..\AutoPrintr\bin\Release\NLog.dll

    ;create desktop shortcut
    CreateShortCut "$DESKTOP\AutoPrintr.lnk" "$INSTDIR\AutoPrintr.exe" ""
 
    ;create start-menu items
    CreateDirectory "$SMPROGRAMS\AutoPrintr"
    CreateShortCut "$SMPROGRAMS\AutoPrintr\Uninstall.lnk" "$INSTDIR\Uninstall.exe" "" "$INSTDIR\Uninstall.exe" 0
    CreateShortCut "$SMPROGRAMS\AutoPrintr\AutoPrintr.lnk" "$INSTDIR\AutoPrintr.exe" "" "$INSTDIR\AutoPrintr.exe" 0

    WriteUninstaller "uninstall.exe"

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

  ; ExecWait '"cmd.exe" /C Taskkill /F /IM AutoPrintr.exe'

  ; Remove files and uninstaller
  Delete $INSTDIR\*

  Delete "$DESKTOP\AutoPrintr.lnk"
  Delete "$SMPROGRAMS\AutoPrintr\*.*"
  RmDir  "$SMPROGRAMS\AutoPrintr"

  ; Remove directories used
  RMDir /r /REBOOTOK $INSTDIR

SectionEnd
