#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["NetCore.Api/NetCore.Api.csproj", "NetCore.Api/"]
COPY ["NetCore.Core/NetCore.Core.csproj", "NetCore.Core/"]
COPY ["NetCore.Model/NetCore.Model.csproj", "NetCore.Model/"]
RUN dotnet restore "NetCore.Api/NetCore.Api.csproj"
COPY . .
WORKDIR "/src/NetCore.Api"
RUN dotnet build "NetCore.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NetCore.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NetCore.Api.dll"]