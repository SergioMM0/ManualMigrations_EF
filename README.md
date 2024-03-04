# EF branch

The branch [Master](https://github.com/SergioMM0/ManualMigrations_EF) contains the migration history generated with EF Core.

The database file is present inside the API folder under the name 'BloggingDatabase.db' and it contains the migrations made with EF Core.

## Creating a migration

After making sure that the current state of the database matches the latest migration, you can modify the context and add a new migration by running:

```bash
dotnet ef migrations add [DescriptionOfTheMigration]
```

Review the generated migration by checking the .Migration file inside the folder 'Migrations':

![image](https://github.com/SergioMM0/ManualMigrations_EF/assets/90683062/51db93bc-8bac-47af-9f19-d7dbe60d420f)

Check the up and down methods to see how the data structure is going to be affected:

![image](https://github.com/SergioMM0/ManualMigrations_EF/assets/90683062/36d1e194-a7ec-4558-95bd-bea2279e4648)

If the migration is ready to be applied, you can update the context of your database by running:

```bash
dotnet ef database update
```

If done correctly, the table named '__EFMigrationsHistory' should contain all the migrations applied to the database.

## Rollback

In order to rollback the current state of the database to any other migration run the command

```bash
dotnet ef database update [NameOfTheMigrationYouWantToRollback]
```

# Manual branch

This branch contains a folder in /API/SQLScripts that contains all the SQL Scripts for performing manual migrations. 

Also notice that this branch contains an outdated version of the database which is ready to be migrated.

## Executing the migration

To perform the migration, execute the SQL Script named 'V1_04032024_InitialCreate_to_RefactorBlogAndComment.sql' in the console of the database.

## Rollback

To perform a rollback, execute the SQL Script named 'V1_04032024_Rollback_RefactorBlogAndComment_to_InitialCreate.sql' in the console of the database.


