FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SomeAPI/SomeAPI.csproj", "SomeAPI/"]
RUN dotnet restore "SomeAPI/SomeAPI.csproj"
COPY . .
WORKDIR "/src/SomeAPI"
RUN dotnet build "SomeAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SomeAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SomeAPI.dll"]
