CREATE PROCEDURE [dbo].[proc_DeleteProduct]
	(@ProductID				Int,
	@Available				Int,
	@OnHand				int,
	@Description			VarChar(250),
	@Location				varchar(250),
	@UnitPrice				Money,
	@ShortDesc				VarChar(50),
	@ReorderThreshold		int,
	@ReorderAmount			int,
	@OnOrder				int,
	@ShippingDimensions		varchar(50),
	@ShippingWeight			float,
	@Active					Bit)
AS
	DELETE FROM [dbo].[Products]
	WHERE [ProductID] = @ProductID
	AND [Available] = @Available
	AND [OnHand] = @OnHand
	AND [Description] = @Description
	AND [Location] = @Location
	AND [UnitPrice] = @UnitPrice
	AND [ShortDesc] = @ShortDesc
	AND [ReorderThreshold] = @ReorderThreshold
	AND [ReorderAmount] = @ReorderAmount
	AND [OnOrder] = @OnOrder
	AND [ShippingDimensions] = @ShippingDimensions
	AND [ShippingWeight] = @ShippingWeight
	AND [Active] = @Active
	RETURN @@ROWCOUNT