IF NOT EXISTS(SELECT * FROM sysobjects WHERE NAME = 'Customer' AND xtype = 'U')
BEGIN
    CREATE TABLE Customer
      (
         ID       INT NOT NULL,
         Name     NVARCHAR(50) NOT NULL,
         LastName NVARCHAR(50) NOT NULL,
         CONSTRAINT pk_customer PRIMARY KEY CLUSTERED (id ASC)
      )
END