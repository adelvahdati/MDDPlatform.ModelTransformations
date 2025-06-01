FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app

COPY  MDDPlatform.ModelTransformations.Api/app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "MDDPlatform.ModelTransformations.Api.dll"]