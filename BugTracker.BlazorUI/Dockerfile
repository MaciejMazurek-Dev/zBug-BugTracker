FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
COPY ["BugTracker.BlazorUI.csproj", "./"]
RUN dotnet restore
COPY . ./

RUN dotnet publish -c Release -o /app/publish

FROM nginx:alpine 
EXPOSE 5003
COPY ["nginx.conf" , "/etc/nginx/nginx.conf"]
COPY --from=build /app/publish/wwwroot /usr/share/nginx/bugtracker/blazor/



