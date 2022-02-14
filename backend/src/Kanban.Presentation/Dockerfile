#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Kanban.Core/Kanban.Core.csproj", "Kanban.Core/"]
COPY ["Kanban.DataAccess/Kanban.DataAccess.csproj", "Kanban.DataAccess/"]
COPY ["Kanban.Service/Kanban.Service.csproj", "Kanban.Service/"]
COPY ["Kanban.Presentation/Kanban.Presentation.csproj", "Kanban.Presentation/"]
RUN dotnet restore "Kanban.Presentation/Kanban.Presentation.csproj"

COPY . .
WORKDIR "/src/Kanban.Presentation" 
RUN dotnet build "Kanban.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Kanban.Presentation.csproj" -c Release -o /app/publish

FROM base AS final

# Change timezone to local time
ENV TZ=Asia/Baku
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Kanban.Presentation.dll"]