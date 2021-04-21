#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ponea.Homework.Bookshop.Api/Ponea.Homework.Bookshop.Api.csproj", "Ponea.Homework.Bookshop.Api/"]
RUN dotnet restore "Ponea.Homework.Bookshop.Api/Ponea.Homework.Bookshop.Api.csproj"
COPY . .
WORKDIR "/src/Ponea.Homework.Bookshop.Api"
RUN dotnet build "Ponea.Homework.Bookshop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ponea.Homework.Bookshop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ponea.Homework.Bookshop.Api.dll"]