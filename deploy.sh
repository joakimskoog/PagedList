dotnet pack src/*/ --output .artifacts --no-build --configuration Release 
mono .nuget/nuget.exe push .artifacts/*.nupkg -apikey $NUGET_API_KEY
