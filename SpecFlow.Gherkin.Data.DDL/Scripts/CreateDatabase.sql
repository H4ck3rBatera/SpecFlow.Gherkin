IF NOT EXISTS(SELECT * FROM sys.databases WHERE name = 'CustomerBase')
BEGIN
    CREATE DATABASE CustomerBase
END