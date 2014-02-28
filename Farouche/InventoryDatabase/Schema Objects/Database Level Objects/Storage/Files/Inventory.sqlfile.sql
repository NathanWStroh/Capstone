ALTER DATABASE [$(DatabaseName)]
    ADD FILE (NAME = [Inventory], FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Inventory.mdf', SIZE = 2304 KB, FILEGROWTH = 1024 KB) TO FILEGROUP [PRIMARY];

