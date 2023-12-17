FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ReportService.Presentation/ReportService.Presentation.csproj", "ReportService.Presentation/"]
COPY ["ReportService.Infrastructure/ReportService.Infrastructure.csproj", "ReportService.Infrastructure/"]
COPY ["ReportService.Application/ReportService.Application.csproj", "ReportService.Application/"]
COPY ["ReportService.Domain/ReportService.Domain.csproj", "ReportService.Domain/"]
RUN dotnet restore "ReportService.Presentation/ReportService.Presentation.csproj"
COPY . .
WORKDIR "/src/ReportService.Presentation"
RUN dotnet build "ReportService.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportService.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportService.Presentation.dll"]
