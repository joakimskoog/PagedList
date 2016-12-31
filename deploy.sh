#!/bin/sh

dotnet pack src/*/ --output .artifacts --no-build --configuration Release 
mono .nuget/nuget.exe push .artifacts/*.nupkg $NUGET_API_KEY
