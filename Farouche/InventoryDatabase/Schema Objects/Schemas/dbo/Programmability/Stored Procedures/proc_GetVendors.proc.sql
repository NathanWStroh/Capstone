
/*Object:  StoredProcedure [dbo].[proc_GetVendors]*/
CREATE PROCEDURE [dbo].[proc_GetVendors]
AS
	SELECT *
	FROM Vendors 
	Return