cls 
@ECHO OFF 
title Folder Locker
if EXIST "Locker" goto UNLOCK 
if NOT EXIST userdata goto MDLOCKER 
:LOCK 
ren userdata "Locker" 
attrib +h +s "Locker" 
echo Catalog locked
goto End 
:UNLOCK  
attrib -h -s "Locker" 
ren "Locker" userdata 
echo Catalog unlocked
goto End 
:FAIL 
echo Wrong password! 
md userdata 
goto end 
:MDLOCKER 
echo Secret folder created 
goto End 
:End