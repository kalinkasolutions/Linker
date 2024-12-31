FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dotnet_build_env

WORKDIR /app

COPY ./ ./ 
RUN dotnet restore --disable-parallel

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app

COPY --from=dotnet_build_env /app/out ./

RUN mkdir -p /var/data

EXPOSE 8080

ENTRYPOINT ["dotnet", "Linker.App.dll"]
