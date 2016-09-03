OutFile "version.exe"

!define File "..\AutoPrintr\bin\Release\AutoPrintr.exe"

Function .onInit

    GetDllVersion "${File}" $R0 $R1
    IntOp $R2 $R0 / 0x00010000
    IntOp $R3 $R0 & 0x0000FFFF
    IntOp $R4 $R1 / 0x00010000
    IntOp $R5 $R1 & 0x0000FFFF
    StrCpy $R1 "$R2.$R3.$R4.$R5"

    FileOpen $R0 "$EXEDIR\version.txt" w
    FileWrite $R0 $R1
    FileClose $R0
    Abort

FunctionEnd


Section

SectionEnd