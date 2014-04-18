
/*Object:  StoredProcedure [dbo].[proc_GetVendorsActive]*/
CREATE PROCEDURE [dbo].[proc_GetVendorsActive]
AS
	SELECT *
	FROM Vendors
	WHERE Active = 1
	Return