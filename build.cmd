@ECHO off
echo.
echo "Blessed is the mind too small for doubt."
echo "Praise the Omnissiah. May His circuits light the way."
echo.

echo PATH
echo %PATH%
set OUT=%cd%\.out\
for /f %%i in ('git describe --tags --long --always') do set v=%%i
echo %v% 

echo "Creating space for sacret computation"
if not exist .out mkdir .out

pushd .\Solution
echo "Oh spirits of the Machine, follow thy call to Resoration (dotnet resore)"
dotnet restore mqtt2cmd.sln --force || exit 1

echo "Compile thy blessed Code"
dotnet publish mqtt2cmd.sln -r win-x86 --self-contained true -c release --force
popd


set outArchive=%OUT%\mqtt2cmd_%v%.zip
pushd .\Solution\bin\Release\net6.0\win-x86\publish

MOVE .\mqtt2cmd.exe .\mqtt2cmd_%v%.exe || exit 1
powershell Compress-Archive .\mqtt2cmd_%v%.exe -Update %outArchive% || exit 1








