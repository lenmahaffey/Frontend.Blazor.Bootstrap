# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

ARG ENV
ARG PORT
ARG HOST

WORKDIR /App
COPY build/ .

#SET URL AND ENVIRONMENT FOR BACKEND HERE###
ENV ASPNETCORE_URLS "http://blazor.lenmahaffey.com:${PORT}"
ENV ASPNETCORE_ENVIRONMENT ${ENV}

EXPOSE ${PORT}
ENTRYPOINT ["dotnet", "MeetingManager.Api.dll"]
