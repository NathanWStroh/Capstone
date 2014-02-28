
/*Object:  StoredProcedure [dbo].[sp_GetVendorsActive]*/
CREATE PROCEDURE [dbo].[sp_GetVendorsActive]
AS
	SELECT *
	FROM Vendors
	WHERE Active = 1
	Return