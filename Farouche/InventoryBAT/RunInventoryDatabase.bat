@ECHO off

ECHO creating Inventory database... the hard way.
sqlcmd -S localhost\SQLExpress -E /i ../InventoryDatabase\sql\debug\InventoryDatabase.sql
ECHO.
ECHO done with the vb generated database
ECHO.
sqlcmd -S localhost\SQLExpress -E /i VendorOrders.sql
ECHO.
ECHO. look for errors. yay!
ECHO.
Pause