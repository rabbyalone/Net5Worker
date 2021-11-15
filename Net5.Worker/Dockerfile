#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Net5.Worker/Net5.Worker.csproj", "Net5.Worker/"]
RUN dotnet restore "Net5.Worker/Net5.Worker.csproj"
COPY . .
WORKDIR "/src/Net5.Worker"
RUN dotnet build "Net5.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net5.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net5.Worker.dll"]