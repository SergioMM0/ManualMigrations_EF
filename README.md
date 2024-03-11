# Manual Migration 
## Compulsory Assignment: Databases For Developers

This is the manual branch of the database migration assignment. Included below is the full rollback plan to revert any changes to the database schema so far.

### **Setup**
You could run the project using `dotnet run` in the console which would make the database accessible via the web API. Here you can test whether or not the database remained stable after a migration or rollback.

### **Database Migration instructions**
To migrate to the next iteration of the database, SQL scripts are added in the folder "SQLScripts". Make sure you know at what iteration you are currently on before migrating. The SQL scripts in chronological order are: *initial_schema.sql*, *AddProductRatings.sql* and *AddCategories.sql*. Make sure you to back up the database in case the migration fails to prevent any data loss from occurring.

Here are the migrations in order:\
1. Migration from initial schema to add categories:
    Execute AddCategories.sql after checking if the database matches the initial schema architecture.
2. Migration from the categories schema to add ratings:
    Execute AddProductRatings.sql after checking if the database matches the schema architecture that ecompasses both the initial schema and the categories schema.
3. Migration from the initial schema to the current schema:
    Execute the previous steps in order.

### **Database Migration Rollback Instructions**
To roll back to a previous iteration, an SQL script needs to be executed in order to guarantee a stable transition from one version of the database to another. The SQL scripts are given in order for ease of use. Make sure you test whether or not the rollback procedure has resulted in a clean migration. Before you perform a rollback of any kind, please follow the best practices.

**Best practices for performing rollbacks:**
- Back up your database before executing the rollback script to revert the changes. This allows you to restore the database to its state before the rollback if needed.
- Analyze the data in the affected tables before executing the rollback script to identify any critical information that might be lost.
- Communicate the rollback process and potential data loss to stakeholders to ensure awareness and agreement.

### **Revert Product Ratings**
To revert the implementation of the product ratings migration, follow these steps:\
Execute these statements in your SQLite database management tool or run them in your application's migration process.
```
-- Drop foreign key constraint on Products table
-- This ensures that there are no constraints preventing the removal of the Rating column
ALTER TABLE Products DROP CONSTRAINT IF EXISTS FK_Products_ProductRatings;

-- Remove Rating column from Products table
ALTER TABLE Products DROP COLUMN IF EXISTS Rating;

-- Drop ProductRatings table
DROP TABLE IF EXISTS ProductRatings;
```

**Potential data loss:**
1. If any data was added to the Rating column of the Products table, and those values correspond to valid foreign keys in the ProductRatings table, dropping the foreign key constraint could result in orphaned data in the Products table. However, since the Rating column was added with a default value of 0.0, this scenario is less likely.
2. If any data was added to the Rating column of the Products table, it would be lost when the column is removed. Since the script doesn't specify a mechanism to preserve or migrate this data, it would be dropped.
3. Any data stored in the ProductRatings table would be lost when the table is dropped. This includes any product ratings that were recorded before the rollback script is executed.

### **Revert Product Categories**
To revert the addition of product categories migration, follow these steps:\
Execute these statements in your SQLite database management tool or run them in your application's migration process.
```
-- Drop foreign key constraint on Products table
-- This ensures that there are no constraints preventing the removal of the Categories column
ALTER TABLE Products DROP CONSTRAINT IF EXISTS FK_Products_Categories;

-- Remove category_id column from Products table
ALTER TABLE Products DROP COLUMN IF EXISTS category_id;

-- Drop Categories table
DROP TABLE IF EXISTS Categories;
```
**Potential data loss:**
1. Dropping the foreign key constraint FK_Products_Categories on the Products table shouldn't result in any immediate data loss. However, if referential integrity constraints were violated before dropping the constraint, orphaned data in the Products table could be present. Dropping the constraint wouldn't resolve this issue, but it would allow data modifications without enforcing referential integrity.
2. If there were existing records in the Products table that contained values in the category_id column, removing the column would result in the loss of these values. Since the script doesn't specify a mechanism to preserve or migrate this data, it would be dropped. If the category_id column was added with a default value of 1 as in the original script, any records without explicit values would have been assigned this default value.
3. Dropping the Categories table would result in the loss of all data stored in this table. If there were any categories defined and associated with products in the Products table, this information would be lost.

### **Full rollback to initial schema**
To get a full rollback to the initial schema, perform all rollbacks from the top down in order. So start first with reverting the product ratings, followed by reverting the product categories. This will result in the database with the products containing an Id, name and price for each product. **Any other data would be lost during rollback** so make sure the database is backed up before proceeding with a full rollback.