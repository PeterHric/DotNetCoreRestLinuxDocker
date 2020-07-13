FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY bin/Release/netcoreapp3.1/publish/ App/
WORKDIR /App
EXPOSE 80
ENTRYPOINT ["dotnet", "RestApi.dll"]
