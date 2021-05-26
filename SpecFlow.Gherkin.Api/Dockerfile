#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SpecFlow.Gherkin.Api/SpecFlow.Gherkin.Api.csproj", "SpecFlow.Gherkin.Api/"]
RUN dotnet restore "SpecFlow.Gherkin.Api/SpecFlow.Gherkin.Api.csproj"
COPY . .
WORKDIR "/src/SpecFlow.Gherkin.Api"
RUN dotnet build "SpecFlow.Gherkin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpecFlow.Gherkin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SpecFlow.Gherkin.Api.dll"]