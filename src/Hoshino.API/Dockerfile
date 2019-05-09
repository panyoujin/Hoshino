 FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
 WORKDIR /app
 EXPOSE 80
 EXPOSE 443
 
 FROM microsoft/dotnet:2.2-sdk AS build
 WORKDIR /src
 COPY ["Hoshino.API/Hoshino.API.csproj", "Hoshino.API/"]
 RUN dotnet restore "Hoshino.API/Hoshino.API.csproj"
 COPY . .
 WORKDIR "/src/Hoshino.API"
 RUN dotnet build "Hoshino.API.csproj" -c Release -o /app
 
 FROM build AS publish
 RUN dotnet publish "Hoshino.API.csproj" -c Release -o /app
 
 FROM base AS final
 WORKDIR /app
 COPY --from=publish /app .
 ENTRYPOINT ["dotnet", "Hoshino.API.dll"]
