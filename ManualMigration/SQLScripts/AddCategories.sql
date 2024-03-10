CREATE TABLE Categories
(
    Id INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Add category_id column to Products table
ALTER TABLE Products
ADD category_id INT;

-- Add foreign key constraint
ALTER TABLE Products
ADD CONSTRAINT FK_Products_Categories FOREIGN KEY (category_id)
REFERENCES Categories(Id);