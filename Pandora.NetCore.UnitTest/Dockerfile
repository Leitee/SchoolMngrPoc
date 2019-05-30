#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/runtime:2.2-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-nanoserver-1809 AS build
WORKDIR /src
COPY ["Pandora.NetCore.UnitTest/Pandora.NetCore.UnitTest.csproj", "Pandora.NetCore.UnitTest/"]
COPY ["Pandora.NetCore.WebApi/Pandora.NetCore.WebApi.csproj", "Pandora.NetCore.WebApi/"]
COPY ["Pandora.NetStandard.Business/Pandora.NetStandard.Business.csproj", "Pandora.NetStandard.Business/"]
COPY ["Pandora.NetStandard.Core/Pandora.NetStandard.Core.csproj", "Pandora.NetStandard.Core/"]
COPY ["Pandora.NetStandard.Model/Pandora.NetStandard.Model.csproj", "Pandora.NetStandard.Model/"]
COPY ["Pandora.NetStandard.Data/Pandora.NetStandard.Data.csproj", "Pandora.NetStandard.Data/"]
RUN dotnet restore "Pandora.NetCore.UnitTest/Pandora.NetCore.UnitTest.csproj"
COPY . .
WORKDIR "/src/Pandora.NetCore.UnitTest"
RUN dotnet build "Pandora.NetCore.UnitTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pandora.NetCore.UnitTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pandora.NetCore.UnitTest.dll"]