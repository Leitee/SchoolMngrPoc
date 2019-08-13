FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pandora.NetCore.Identity/Pandora.NetCore.Identity.csproj", "Pandora.NetCore.Identity/"]
COPY ["Pandora.NetStandard.Core/Pandora.NetStandard.Core.csproj", "Pandora.NetStandard.Core/"]
COPY ["Pandora.NetStandard.Model/Pandora.NetStandard.Model.csproj", "Pandora.NetStandard.Model/"]
RUN dotnet restore "Pandora.NetCore.Identity/Pandora.NetCore.Identity.csproj"
COPY . .
WORKDIR "/src/Pandora.NetCore.Identity"
RUN dotnet build "Pandora.NetCore.Identity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pandora.NetCore.Identity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pandora.NetCore.Identity.dll"]