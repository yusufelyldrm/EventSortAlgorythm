FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LenaAlgorythmProject/LenaAlgorythmProject.csproj", "LenaAlgorythmProject/"]
RUN dotnet restore "LenaAlgorythmProject/LenaAlgorythmProject.csproj"
COPY . .
WORKDIR "/src/LenaAlgorythmProject"
RUN dotnet build "LenaAlgorythmProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LenaAlgorythmProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LenaAlgorythmProject.dll"]
