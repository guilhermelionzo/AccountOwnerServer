FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
 
WORKDIR /home/app
COPY bin/Debug/netcoreapp3.1/publish .

#open application on port 3000
#EXPOSE 5001

ENTRYPOINT ["dotnet", "AccountOwnerServer.dll"]
