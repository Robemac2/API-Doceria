FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App

# Expose port 5050
EXPOSE 5050/TCP
# IP for the database host
ENV DB_HOST
# Username to conect to the database
ENV DB_USER
# Password to conect to the database
ENV DB_PASS
# URL to access the api
ENV ASPNETCORE_URLS=http://*:5050

COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "API-Doceria.dll"]
