FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Jwt/Jwt.csproj", "Jwt/"]
RUN dotnet restore "Jwt/Jwt.csproj"
COPY . .
WORKDIR "/src/Jwt"
RUN dotnet build "Jwt.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Jwt.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Jwt.dll"]