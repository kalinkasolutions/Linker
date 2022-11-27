FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS dotnet_build_env

WORKDIR /app

COPY ./ ./ 
RUN dotnet restore --disable-parallel

RUN dotnet publish -c Release -o out


# serve content (focal => ubuntu)
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal

WORKDIR /app

COPY --from=dotnet_build_env /app/out ./

EXPOSE 80

ENTRYPOINT ["dotnet", "Linker.App.dll"]