
/*Object:  StoredProcedure [dbo].[sp_GetVendors]*/
CREATE PROCEDURE [dbo].[sp_GetVendors]
AS
	SELECT *
	FROM Vendors 
	Return