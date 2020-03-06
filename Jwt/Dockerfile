FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.2 AS runtime
WORKDIR /app
COPY . /app
ENTRYPOINT ["dotnet", "Jwt.dll"]