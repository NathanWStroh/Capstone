CREATE PROCEDURE [dbo].[proc_GenerateReorderReports]
	@VendorID int,
	@ReorderActive int
AS
IF @ReorderActive = 0
BEGIN
	select p.ProductID, ShortDesc, ReorderAmount, ReorderThreshold, vsi.VendorID, ItemsPerCase, UnitCost, UnitPrice, MinQtyToOrder
    from Products p
            Join VendorSourceItems vsi on 
                vsi.ProductID = p.ProductID
            where p.active = 'true' and
                vsi.Active = 'true' and
                vsi.VendorID = @VendorID  and
                OnHand + OnOrder < ReorderThreshold
END
ELSE
BEGIN
select p.ProductID, ShortDesc, ReorderAmount, ReorderThreshold, vsi.VendorID, ItemsPerCase, UnitCost, UnitPrice, MinQtyToOrder
    from Products p
            Join VendorSourceItems vsi on 
                vsi.ProductID = p.ProductID
            where p.active = 'true' and
                vsi.Active = 'true' and
                vsi.VendorID = @VendorID  and
                OnHand + OnOrder > ReorderThreshold
END