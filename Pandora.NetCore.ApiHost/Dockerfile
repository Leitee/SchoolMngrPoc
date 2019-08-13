FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pandora.NetCore.ApiHost/Pandora.NetCore.ApiHost.csproj", "Pandora.NetCore.ApiHost/"]
COPY ["Pandora.NetStandard.Api/Pandora.NetStandard.Api.csproj", "Pandora.NetStandard.Api/"]
COPY ["Pandora.NetStandard.Business/Pandora.NetStandard.Business.csproj", "Pandora.NetStandard.Business/"]
COPY ["Pandora.NetStandard.Core/Pandora.NetStandard.Core.csproj", "Pandora.NetStandard.Core/"]
COPY ["Pandora.NetStandard.Model/Pandora.NetStandard.Model.csproj", "Pandora.NetStandard.Model/"]
COPY ["Pandora.NetStandard.Data/Pandora.NetStandard.Data.csproj", "Pandora.NetStandard.Data/"]
RUN dotnet restore "Pandora.NetCore.ApiHost/Pandora.NetCore.ApiHost.csproj"
COPY . .
WORKDIR "/src/Pandora.NetCore.ApiHost"
RUN dotnet build "Pandora.NetCore.ApiHost.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pandora.NetCore.ApiHost.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pandora.NetCore.ApiHost.dll"]