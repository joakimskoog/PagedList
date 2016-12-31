#!/bin/sh

dotnet pack src/*/ --output .artifacts --no-build --configuration Release 
mono .nuget/nuget.exe push .artifacts/*.nupkg -ApiKey $NUGET_API_KEY -Source https://www.nuget.org/api/v2/package
