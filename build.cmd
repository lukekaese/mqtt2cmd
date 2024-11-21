@ECHO off
echo.
echo "Blessed is the mind too small for doubt."
echo "Praise the Omnissiah. May His circuits light the way."
echo.

echo PATH
echo %PATH%
set OUT=%cd%\.out\

echo "Creating space for sacret computation"
if not exist .out mkdir .out

pushd .\Solution
echo "Oh spirits of the Machine, follow thy call to Resoration (dotnet resore)"
dotnet restore mqtt2commandline.sln --force || exit 1

echo "Compile thy blessed Code"
dotnet publish mqtt2commandline.sln -r win-x86 --self-contained true -c release --force
popd


set outArchive=%OUT%\mqtt2commandline.zip
pushd .\Solution\bin\Release\net6.0\win-x86\publish
powershell Compress-Archive .\mqtt2commandline.exe -Update %outArchive% || exit 1








