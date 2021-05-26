#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SpecFlow.Gherkin.IntegrationTest/SpecFlow.Gherkin.IntegrationTest.csproj", "SpecFlow.Gherkin.IntegrationTest/"]
RUN dotnet restore "SpecFlow.Gherkin.IntegrationTest/SpecFlow.Gherkin.IntegrationTest.csproj"
COPY . .
WORKDIR "/src/SpecFlow.Gherkin.IntegrationTest"
RUN dotnet build "SpecFlow.Gherkin.IntegrationTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecFlow.Gherkin.IntegrationTest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecFlow.Gherkin.IntegrationTest.dll"]