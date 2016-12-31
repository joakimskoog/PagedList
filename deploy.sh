#!/bin/sh

echo $NUGET_API_KEY
echo {$NUGET_API_KEY}
dotnet pack src/*/ --output .artifacts --no-build --configuration Release 
mono .nuget/nuget.exe push .artifacts/*.nupkg $NUGET_API_KEY -Source https://www.nuget.org/api/v2/package
