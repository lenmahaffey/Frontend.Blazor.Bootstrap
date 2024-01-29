FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Frontend.Blazor.Bootstrap.csproj", "."]
RUN dotnet restore "Frontend.Blazor.Bootstrap.csproj"
COPY . .
RUN dotnet build "Frontend.Blazor.Bootstrap.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Frontend.Blazor.Bootstrap.csproj" -c Release -o /app/publish

FROM nginx:lastest
RUN rm /etc/nginx/conf.d/*
RUN rm /usr/share/nginx/html/*
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Frontend.Blazor.Bootstrap.dll"]