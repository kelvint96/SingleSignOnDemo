#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Web/WebClient_1/WebClient1/WebClient1.csproj", "Web/WebClient_1/WebClient1/"]
RUN dotnet restore "Web/WebClient_1/WebClient1/WebClient1.csproj"
COPY . .
WORKDIR "/src/Web/WebClient_1/WebClient1"
RUN dotnet build "WebClient1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebClient1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebClient1.dll"]