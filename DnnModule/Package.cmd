@echo off
setlocal
pushd

set Z7="C:\Program Files\7-Zip\7z.exe"
set PACKAGE=tmp_Package
set VERSION=01.00.00

cd ..

rmdir /Q /S %PACKAGE%
mkdir %PACKAGE%\bin

cd DnnModule

%Z7% a ..\%PACKAGE%\DnnModule.zip *.ascx *.css *.js App_LocalResources\*.resx js 

xcopy /Y *.SqlDataProvider ..\%PACKAGE%\
xcopy /Y *.dnn ..\%PACKAGE%\
xcopy /Y *.txt ..\%PACKAGE%\

cd ..
xcopy /Y ..\..\bin\DnnModule*.dll %PACKAGE%\bin\

cd %PACKAGE%
%Z7% a ..\DnnModule-%VERSION%-Install.zip *

cd ..
rmdir /Q /S %PACKAGE%

popd
endlocal

