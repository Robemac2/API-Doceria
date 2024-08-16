FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Define environment variables for database (POSTGRESQL) connection
ARG DATABASE_URL
ENV DATABASE_URL=$DATABASE_URL
ARG DATABASE_PORT
ENV DATABASE_PORT=$DATABASE_PORT
ARG DATABASE_NAME
ENV DATABASE_NAME=$DATABASE_NAME
ARG DATABASE_USER
ENV DATABASE_USER=$DATABASE_USER
ARG DATABASE_PASSWORD
ENV DATABASE_PASSWORD=$DATABASE_PASSWORD

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
EXPOSE 8080
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "API-Doceria.dll"]