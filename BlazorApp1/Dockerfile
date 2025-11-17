# ---------- Build stage ----------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy project files and restore
COPY ["BlazorApp1/BlazorApp1.csproj", "BlazorApp1/"]
COPY ["Model/Model.csproj", "Model/"]
RUN dotnet restore "BlazorApp1/BlazorApp1.csproj"

# copy everything and publish
COPY . .
WORKDIR "/src/BlazorApp1"
RUN dotnet publish "BlazorApp1.csproj" -c Release -o /app/publish

# ---------- Runtime stage ----------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "BlazorApp1.dll"]
