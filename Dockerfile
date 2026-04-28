FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["MyLove/MyLove.csproj", "MyLove/"]
RUN dotnet restore "MyLove/MyLove.csproj"

COPY . .
WORKDIR "/src/MyLove"
RUN dotnet publish "MyLove.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Production
ENV PORT=10000

EXPOSE 10000

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MyLove.dll"]
