FROM mcr.microsoft.com/dotnet/aspnet:3.1
COPY src/Prototype.WebApi/bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "Prototype.WebApi.dll"]
