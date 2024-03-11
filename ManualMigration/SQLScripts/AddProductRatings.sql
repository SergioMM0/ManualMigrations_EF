CREATE TABLE ProductRatings (
    ProductID INT NOT NULL,
    Rating DECIMAL(18, 2) NOT NULL DEFAULT 0.0,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

-- Add table to store product ratings
ALTER TABLE Products
ADD Rating DECIMAL(18, 2) NOT NULL DEFAULT 0.0;

-- Add foreign key constraint
ALTER TABLE Products
ADD CONSTRAINT FK_Products_ProductRatings FOREIGN KEY (Rating)
REFERENCES ProductRatings(Rating);