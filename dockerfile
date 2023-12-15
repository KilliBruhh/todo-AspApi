FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AspApi.csproj", "."]
RUN dotnet restore "./AspApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AspApi.csproj" -c Release -o /app/build

FROM build AS AspApi
RUN dotnet publish "AspApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AspApi.dll"]
