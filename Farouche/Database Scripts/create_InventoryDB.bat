@ECHO on


ECHO Attempting to create the Inventory database . . . 
sqlcmd -S localhost\SQLExpress -E /i InventoryMaster2.0.1.sql
ECHO.
ECHO If no error message is shown, then the database was created successfully.
ECHO.
PAUSE