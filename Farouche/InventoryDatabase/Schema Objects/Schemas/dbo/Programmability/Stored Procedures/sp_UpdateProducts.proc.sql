
/*Object:  StoredProcedure [dbo].[sp_UpdateProducts]*/
CREATE PROCEDURE [dbo].[sp_UpdateProducts]
	(@ProductID				Int,
	@Available				Int,
	@OriginalAvailable		Int,
	@OnHand				Int,
	@OriginalOnHand		Int,
	@Description			VarChar(250),
	@OriginalDescription	VarChar(250),
	@Location				varchar(250),
	@OriginalLocation		varchar(250),
	@UnitPrice				Money,
	@OriginalUnitPrice		Money,
	@ShortDesc				VarChar(50),
	@OriginalShortDesc		VarChar(50),
	@ReorderThreshold		int,
	@OriginalReorderThreshold int,
	@ReorderAmount			int,
	@OriginalReorderAmount	int,
	@ShippingDimensions		varchar(50),
	@OriginalShippingDimensions varchar(50),
	@ShippingWeight			float,
	@OriginalShippingWeight	float,
	@Active					Bit,
	@OriginalActive			Bit)
AS
	UPDATE [dbo].[Products]
	SET [Available] = @Available, [OnHand] = @OnHand, [Description] = @Description, [Location] = @Location, [UnitPrice] = @UnitPrice, [ShortDesc] = @ShortDesc, [ReorderThreshold] = @ReorderThreshold, [ReorderAmount] = @ReorderAmount, [ShippingDimensions] = @ShippingDimensions, [ShippingWeight] = @ShippingWeight, [Active] = @Active
	WHERE [ProductID] = @ProductID
	AND [Available] = @OriginalAvailable
	AND [OnHand] = @OriginalOnHand
	AND [Description] = @OriginalDescription
	AND [Location] = @OriginalLocation
	AND [UnitPrice] = @OriginalUnitPrice
	AND [ShortDesc] = @OriginalShortDesc
	AND [ReorderThreshold] = @OriginalReorderThreshold
	AND [ReorderAmount] = @OriginalReorderAmount
	AND [ShippingDimensions] = @OriginalShippingDimensions
	AND	[ShippingWeight] = @OriginalShippingWeight
	AND [Active] = @OriginalActive
	RETURN @@ROWCOUNT