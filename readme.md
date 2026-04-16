Commands used for this project in terminal:
   ```bash
  dotnet new sln  

  dotnet new classlib -o EntityFrameworkCore.Data
  dotnet new classlib -o EntityFrameworkCore.Domain
  dotnet sln add .\EntityFrameworkCore.Data\EntityFrameworkCore.Data.csproj
  dotnet sln add .\EntityFrameworkCore.Domain\EntityFrameworkCore.Domain.csproj
  
  cd .\EntityFrameworkCore.Data\
  dotnet add package Microsoft.EntityFrameworkCore
  dotnet add package Microsoft.EntityFrameworkCore.Sqlite
  cd ..
  dotnet add .\EntityFrameworkCore.Data\EntityFrameworkCore.Data.csproj reference .\EntityFrameworkCore.Domain\EntityFrameworkCore.Domain.csproj
  
  dotnet new console -o EntityFrameworkCore.Console                         
  dotnet sln add .\EntityFrameworkCore.Console\EntityFrameworkCore.Console.csproj
  cd .\EntityFrameworkCore.Console\                                          
  dotnet add package Microsoft.EntityFrameworkCore.Design                  
  cd ..                                                                   
  dotnet add .\EntityFrameworkCore.Console\EntityFrameworkCore.Console.csproj reference .\EntityFrameworkCore.Data\EntityFrameworkCore.Data.csproj
  
  dotnet new tool-manifest                                                        
  dotnet tool install dotnet-ef --version 10.*                        
  dotnet tool run dotnet-ef migrations add InitialMigration --startup-project .\EntityFrameworkCore.Console\  --project .\EntityFrameworkCore.Data\
  dotnet tool run dotnet-ef database update --startup-project .\EntityFrameworkCore.Console\ --project .\EntityFrameworkCore.Data\

  dotnet tool run dotnet-ef migrations add SeededTeams --startup-project .\EntityFrameworkCore.Console\  --project .\EntityFrameworkCore.Data\
  #correction needed
  dotnet tool run dotnet-ef migrations remove --startup-project .\EntityFrameworkCore.Console\  --project .\EntityFrameworkCore.Data\
  dotnet tool run dotnet-ef migrations add SeededTeams --startup-project .\EntityFrameworkCore.Console\  --project .\EntityFrameworkCore.Data\
  dotnet tool run dotnet-ef database update --startup-project .\EntityFrameworkCore.Console\ --project .\EntityFrameworkCore.Data\
  ```