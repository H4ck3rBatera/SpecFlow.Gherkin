IF NOT EXISTS(SELECT * FROM sys.tables WHERE NAME = 'Customer' AND type = 'U')
BEGIN
    CREATE TABLE Customer
      (
         ID       INT IDENTITY(1,1) NOT NULL,
         Name     NVARCHAR(50) NOT NULL,
         LastName NVARCHAR(50) NOT NULL,
         Document NVARCHAR(14) NOT NULL UNIQUE,
         CONSTRAINT pk_customer PRIMARY KEY CLUSTERED (id ASC)
      )
END