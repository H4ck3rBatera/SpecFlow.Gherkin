INSERT INTO Customer (Name, LastName)
VALUES (@Name, @LastName);
SELECT SCOPE_IDENTITY();