INSERT INTO Customer (Name, LastName, Document)
VALUES (@Name, @LastName, @Document);
SELECT SCOPE_IDENTITY();