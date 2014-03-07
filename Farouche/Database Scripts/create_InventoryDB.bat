@ECHO on

ECHO Attempting to create the Inventory database . . . 
ECHO OFF
sqlcmd -S localhost\SQLExpress -E /i InventoryMaster2.0.1.sql 
ECHO.
ECHO Attempting to create Shipping Tables . . .
sqlcmd -S localhost\SQLExpress -E /i InventoryDatabase_Shipping_v0.0.3.sql
ECHO.
ECHO.
ECHO.

ECHO If no error message is shown, then the database was created successfully.
ECHO.
PAUSE