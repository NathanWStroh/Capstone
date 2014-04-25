CREATE PROCEDURE [dbo].[proc_UpdateVendorOrderLineItemNote]
	@vendorOrderId int,
	@productId int, 
	@note varchar(250)
AS
	UPDATE[dbo].[VendorOrderLineItems]
	SET
		[Note] = @note
	WHERE
		[VendorOrderID] = @vendorOrderId
	RETURN @@ROWCOUNT