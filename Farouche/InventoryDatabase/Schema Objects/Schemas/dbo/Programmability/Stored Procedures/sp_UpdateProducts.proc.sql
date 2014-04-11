CREATE PROCEDURE [dbo].[sp_UpdateProducts]
	(@ProductID						Int,
	@Available						Int,
	@OnHand							Int,
	@Description					VarChar(250),
	@Location						varchar(250),
	@UnitPrice						Money,
	@ShortDesc						VarChar(50),
	@ReorderThreshold				int,
	@ReorderAmount					int,
	@OnOrder						int,
	@ShippingDimensions				varchar(50),
	@ShippingWeight					float,
	@Active							Bit,
	@OriginalAvailable				Int,
	@OriginalOnHand					Int,
	@OriginalDescription			VarChar(250),
	@OriginalLocation				varchar(250),
	@OriginalUnitPrice				Money,
	@OriginalShortDesc				VarChar(50),
	@OriginalReorderThreshold 		int,
	@OriginalReorderAmount			int,
	@OriginalOnOrder				int,
	@OriginalShippingDimensions 	varchar(50),
	@OriginalShippingWeight			float,
	@OriginalActive					Bit)
AS
	UPDATE [dbo].[Products]
	SET [Available] = @Available, 
		[OnHand] = @OnHand, 
		[Description] = @Description, 
		[Location] = @Location, 
		[UnitPrice] = @UnitPrice, 
		[ShortDesc] = @ShortDesc, 
		[ReorderThreshold] = @ReorderThreshold, 
		[ReorderAmount] = @ReorderAmount, 
		[ShippingDimensions] = @ShippingDimensions, 
		[ShippingWeight] = @ShippingWeight, 
		[Active] = @Active, 
		[OnOrder] = @OnOrder
	WHERE [ProductID] = @ProductID
		AND [Available] = @OriginalAvailable
		AND [OnHand] = @OriginalOnHand
		AND [Description] = @OriginalDescription
		AND (([Location] = @OriginalLocation)
		OR (@OriginalLocation IS NULL))
		AND [UnitPrice] = @OriginalUnitPrice
		AND [ShortDesc] = @OriginalShortDesc
		AND (([ReorderThreshold] = @OriginalReorderThreshold)
		OR (@OriginalReorderThreshold IS NULL))
		AND (([ReorderAmount] = @OriginalReorderAmount)
		OR (@OriginalReorderAmount IS NULL))
		AND [OnOrder] = @OriginalOnOrder
		AND (([ShippingDimensions] = @OriginalShippingDimensions)
		OR (@OriginalShippingDimensions IS NULL))
		AND (([ShippingWeight] = @OriginalShippingWeight)
		OR (@OriginalShippingWeight IS NULL))
		AND [Active] = @OriginalActive
	RETURN @@ROWCOUNT