FROM mcr.microsoft.com/dotnet/aspnet:6.0 as final
WORKDIR /app/publish
COPY ./bin/Release/net6.0 /app/publish
ENTRYPOINT ["dotnet","/app/publish/LegoCollectors.WebAPI.dll"]
