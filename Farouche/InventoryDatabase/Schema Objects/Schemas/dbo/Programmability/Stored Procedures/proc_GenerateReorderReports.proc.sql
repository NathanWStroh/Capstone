CREATE PROCEDURE [dbo].[proc_GenerateReorderReports]
	@VendorID int
AS
	select p.ProductID, ReorderAmount, ReorderThreshold, vsi.VendorID, ItemsPerCase, UnitCost, UnitPrice, MinQtyToOrder
    from Products p
            Join VendorSourceItems vsi on 
                vsi.ProductID = p.ProductID
            where p.active = 'true' and
                vsi.Active = 'true' and
                vsi.VendorID = @VendorID  and
                OnHand + OnOrder < ReorderThreshold
