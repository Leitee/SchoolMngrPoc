FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Pandora.NetCore.WebApi/Pandora.NetCore.WebApi.csproj", "Pandora.NetCore.WebApi/"]
COPY ["Pandora.NetStandard.Business/Pandora.NetStandard.Business.csproj", "Pandora.NetStandard.Business/"]
COPY ["Pandora.NetStandard.Core/Pandora.NetStandard.Core.csproj", "Pandora.NetStandard.Core/"]
COPY ["Pandora.NetStandard.Model/Pandora.NetStandard.Model.csproj", "Pandora.NetStandard.Model/"]
COPY ["Pandora.NetStandard.Data/Pandora.NetStandard.Data.csproj", "Pandora.NetStandard.Data/"]
RUN dotnet restore "Pandora.NetCore.WebApi/Pandora.NetCore.WebApi.csproj"
COPY . .
WORKDIR "/src/Pandora.NetCore.WebApi"
RUN dotnet build "Pandora.NetCore.WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pandora.NetCore.WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pandora.NetCore.WebApi.dll"]