<h5>Commands used for this project in terminal:</h5>  
  
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
    
  
<h5>Interesting log for a second migration database update (Remember: I had to hardcode the data source on 'OnConfiguring'):</h5>

```
 dotnet tool run dotnet-ef database update --startup-project .\EntityFrameworkCore.Console\ --project .\EntityFrameworkCore.Data\
Build started...
Build succeeded.
warn: 4/29/2026 16:07:22.915 CoreEventId.SensitiveDataLoggingEnabledWarning[10400] (Microsoft.EntityFrameworkCore.Infrastructure) 
      Sensitive data logging is enabled. Log entries and exception messages may include sensitive application data; this mode should only be enabled during development.
info: 4/29/2026 16:07:23.230 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (14ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      PRAGMA journal_mode = 'wal';
Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: 4/29/2026 16:07:23.243 RelationalEventId.AcquiringMigrationLock[20411] (Microsoft.EntityFrameworkCore.Migrations)
      Acquiring an exclusive lock for migration application. See https://aka.ms/efcore-docs-migrations-lock for more information if this takes too long.
info: 4/29/2026 16:07:23.251 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (4ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsLock' AND "type" = 'table';
info: 4/29/2026 16:07:23.254 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (3ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE IF NOT EXISTS "__EFMigrationsLock" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK___EFMigrationsLock" PRIMARY KEY,
          "Timestamp" TEXT NOT NULL
      );
info: 4/29/2026 16:07:23.256 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT OR IGNORE INTO "__EFMigrationsLock"("Id", "Timestamp") VALUES(1, '2026-04-29 13:07:23.255014+00:00');
      SELECT changes();
info: 4/29/2026 16:07:23.322 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
          "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,
          "ProductVersion" TEXT NOT NULL
      );
info: 4/29/2026 16:07:23.331 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT COUNT(*) FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' AND "type" = 'table';
info: 4/29/2026 16:07:23.334 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";
Applying migration '20260415142025_InitialMigration'.
info: 4/29/2026 16:07:23.341 RelationalEventId.MigrationApplying[20402] (Microsoft.EntityFrameworkCore.Migrations)
      Applying migration '20260415142025_InitialMigration'.
info: 4/29/2026 16:07:23.351 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Coaches" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Coaches" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NOT NULL,
          "CreatedDate" TEXT NOT NULL
      );
info: 4/29/2026 16:07:23.351 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Teams" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Teams" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NULL,
          "CreatedDate" TEXT NOT NULL
      );
info: 4/29/2026 16:07:23.351 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20260415142025_InitialMigration', '10.0.6');
Applying migration '20260416140428_SeededTeams'.
info: 4/29/2026 16:07:23.353 RelationalEventId.MigrationApplying[20402] (Microsoft.EntityFrameworkCore.Migrations)
      Applying migration '20260416140428_SeededTeams'.
info: 4/29/2026 16:07:23.363 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "Teams" ("Id", "CreatedDate", "Name")
      VALUES (1, '2026-04-16 16:00:00', 'Tivoli');
      SELECT changes();

      INSERT INTO "Teams" ("Id", "CreatedDate", "Name")
      VALUES (2, '2026-04-16 16:00:00', 'Rosenborg');
      SELECT changes();

      INSERT INTO "Teams" ("Id", "CreatedDate", "Name")
      VALUES (3, '2026-04-16 16:00:00', 'Brann');
      SELECT changes();
info: 4/29/2026 16:07:23.364 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20260416140428_SeededTeams', '10.0.6');
Applying migration '20260429130241_AddMoreEntities'.
info: 4/29/2026 16:07:23.365 RelationalEventId.MigrationApplying[20402] (Microsoft.EntityFrameworkCore.Migrations)
      Applying migration '20260429130241_AddMoreEntities'.
info: 4/29/2026 16:07:23.380 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command) 
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Teams" ADD "CoachId" INTEGER NOT NULL DEFAULT 0;
info: 4/29/2026 16:07:23.381 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Teams" ADD "CreatedBy" TEXT NULL;
info: 4/29/2026 16:07:23.381 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Teams" ADD "LeagueId" INTEGER NOT NULL DEFAULT 0;
info: 4/29/2026 16:07:23.381 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Teams" ADD "ModifiedBy" TEXT NULL;
info: 4/29/2026 16:07:23.382 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Teams" ADD "ModifiedDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
info: 4/29/2026 16:07:23.382 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Coaches" ADD "CreatedBy" TEXT NULL;
info: 4/29/2026 16:07:23.382 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Coaches" ADD "ModifiedBy" TEXT NULL;
info: 4/29/2026 16:07:23.382 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Coaches" ADD "ModifiedDate" TEXT NOT NULL DEFAULT '0001-01-01 00:00:00';
info: 4/29/2026 16:07:23.383 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      ALTER TABLE "Coaches" ADD "TeamId" INTEGER NULL;
info: 4/29/2026 16:07:23.383 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Leagues" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Leagues" PRIMARY KEY AUTOINCREMENT,
          "Name" TEXT NOT NULL,
          "CreatedDate" TEXT NOT NULL,
          "ModifiedDate" TEXT NOT NULL,
          "CreatedBy" TEXT NULL,
          "ModifiedBy" TEXT NULL
      );
info: 4/29/2026 16:07:23.383 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE "Matches" (
          "Id" INTEGER NOT NULL CONSTRAINT "PK_Matches" PRIMARY KEY AUTOINCREMENT,
          "HomeTeamId" INTEGER NOT NULL,
          "AwayTeamId" INTEGER NOT NULL,
          "TicketPrice" TEXT NOT NULL,
          "Date" TEXT NOT NULL,
          "CreatedDate" TEXT NOT NULL,
          "ModifiedDate" TEXT NOT NULL,
          "CreatedBy" TEXT NULL,
          "ModifiedBy" TEXT NULL
      );
info: 4/29/2026 16:07:23.383 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      UPDATE "Teams" SET "CoachId" = 0, "CreatedBy" = NULL, "LeagueId" = 0, "ModifiedBy" = NULL, "ModifiedDate" = '0001-01-01 00:00:00'
      WHERE "Id" = 1;
      SELECT changes();
info: 4/29/2026 16:07:23.384 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      UPDATE "Teams" SET "CoachId" = 0, "CreatedBy" = NULL, "LeagueId" = 0, "ModifiedBy" = NULL, "ModifiedDate" = '0001-01-01 00:00:00'
      WHERE "Id" = 2;
      SELECT changes();
info: 4/29/2026 16:07:23.384 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      UPDATE "Teams" SET "CoachId" = 0, "CreatedBy" = NULL, "LeagueId" = 0, "ModifiedBy" = NULL, "ModifiedDate" = '0001-01-01 00:00:00'
      WHERE "Id" = 3;
      SELECT changes();
info: 4/29/2026 16:07:23.384 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
      VALUES ('20260429130241_AddMoreEntities', '10.0.6');
info: 4/29/2026 16:07:23.386 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (1ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      DELETE FROM "__EFMigrationsLock";
Done.
```
