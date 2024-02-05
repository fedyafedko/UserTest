#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://*80
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["UserTest/UserTest.csproj", "UserTest/"]
COPY ["UserTest.BLL/UserTest.BLL.csproj", "UserTest.BLL/"]
COPY ["UserTest.Common/UserTest.Common.csproj", "UserTest.Common/"]
COPY ["UserTest.DAL/UserTest.DAL.csproj", "UserTest.DAL/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "UserTest/UserTest.csproj"
COPY . .
WORKDIR "/src/UserTest"
RUN dotnet build "UserTest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserTest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserTest.dll"]