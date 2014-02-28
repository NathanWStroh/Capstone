ALTER DATABASE [$(DatabaseName)]
    ADD LOG FILE (NAME = [Inventory_log], FILENAME = 'c:\Program Files\Microsoft SQL Server\MSSQL10.SQLEXPRESS\MSSQL\DATA\Inventory_log.LDF', SIZE = 768 KB, MAXSIZE = 2097152 MB, FILEGROWTH = 10 %);

