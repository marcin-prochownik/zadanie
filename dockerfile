FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY . .

RUN dotnet restore && dotnet build --no-restore -c Release
RUN dotnet publish ./src/Subscriptions/Subscriptions.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as final
WORKDIR /app

COPY --from=build /app/publish/ .

ENTRYPOINT [ "dotnet", "/app/Subscriptions.dll" ]
