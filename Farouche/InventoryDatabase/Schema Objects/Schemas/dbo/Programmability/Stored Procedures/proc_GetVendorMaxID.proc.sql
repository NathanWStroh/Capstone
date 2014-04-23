CREATE PROCEDURE [dbo].[proc_GetVendorMaxID]

AS
	SELECT MAX(VendorID)
	FROM Vendors
	RETURN