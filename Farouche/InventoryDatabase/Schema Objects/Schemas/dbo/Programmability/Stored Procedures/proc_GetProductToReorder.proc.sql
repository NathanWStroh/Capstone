CREATE PROCEDURE [dbo].[proc_GetProductToReorder]
	@shortDesc  varchar(50)
AS
	select p.ProductID, ShortDesc, ReorderAmount, ReorderThreshold, vsi.VendorID, ItemsPerCase, UnitCost, UnitPrice, MinQtyToOrder
    from Products p
            Join VendorSourceItems vsi on 
                vsi.ProductID = p.ProductID
            where p.active = 'true' and
                vsi.Active = 'true' and
                ShortDesc = @shortDesc