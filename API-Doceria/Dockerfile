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
# Port for database connection
ENV DB_PORT
# Databse name to connect
ENV DB_DATABASE
# Username to connect to the database
ENV DB_USER
# Password to connect to the database
ENV DB_PASS
# URL to access the api
ENV APP_URL=http://*:5050

COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "API-Doceria.dll"]
