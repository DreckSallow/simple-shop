## BACKEND
Attach backend proyect references, and documentation relate to the tools used here.

#### SQL-SERVER
```bash
 # Run a sql-server container
  docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Dreck@sallow.dikson" -p 1432:1433 --name sql-dreck --hostname sql-dreck -v sqlvolume:/var/opt/mssql  -d mcr.microsoft.com/mssql/server:2022-latest  

 # Connect by inside the container
 docker exec -it sql1 "bash" 
 /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "<YourNewStrong@Passw0rd>"
 
 # Connect oustide the container
 sqlcmd -S localhost:1432 -U SA -P Dreck@sallow.dikson
```


- Getting started: https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-ver16&pivots=cs1-powershell

