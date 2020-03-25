FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Nexul.Demo.MvcWeb/Nexul.Demo.MvcWeb.csproj", "Nexul.Demo.MvcWeb/"]
RUN dotnet restore "Nexul.Demo.MvcWeb/Nexul.Demo.MvcWeb.csproj"
COPY . .
WORKDIR "/src/Nexul.Demo.MvcWeb"
RUN dotnet build "Nexul.Demo.MvcWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nexul.Demo.MvcWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nexul.Demo.MvcWeb.dll"]