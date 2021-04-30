FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

# Copy the csproj and restore all of the nugets
COPY Bespereboiniki.sln ./
COPY Bespereboiniki/*.csproj ./Bespereboiniki/
COPY Bespereboiniki.Datalayer/*.csproj ./Bespereboiniki.Datalayer/

RUN dotnet restore Bespereboiniki/Bespereboiniki.csproj
RUN dotnet restore Bespereboiniki.Datalayer/Bespereboiniki.Datalayer.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Bespereboiniki.dll"]