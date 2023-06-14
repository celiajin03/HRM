FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Interviews.API/", "Services/Interviews/Interviews.API/"]
COPY ["Infrastructure/", "Services/Interviews/Infrastructure/"]
COPY ["ApplicationCore/", "Services/Interviews/ApplicationCore/"]
RUN dotnet restore "Services/Interviews/Interviews.API/Interviews.API.csproj"
COPY . .
WORKDIR "/src/Services/Interviews/Interviews.API"
RUN dotnet build "Interviews.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interviews.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV angularURL = 'http://localhost:4200'
ENTRYPOINT ["dotnet", "Interviews.API.dll"]
