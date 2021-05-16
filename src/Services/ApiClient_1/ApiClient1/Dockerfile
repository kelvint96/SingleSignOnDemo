#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Services/ApiClient_1/ApiClient1/ApiClient1.csproj", "src/Services/ApiClient_1/ApiClient1/"]
RUN dotnet restore "src/Services/ApiClient_1/ApiClient1/ApiClient1.csproj"
COPY . .
WORKDIR "/src/src/Services/ApiClient_1/ApiClient1"
RUN dotnet build "ApiClient1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiClient1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiClient1.dll"]
