CREATE PROCEDURE [dbo].[sp_InsertIntoProducts]
	(@Available			Int,
	@OnHand				Int,
	@Description		VarChar(250),
	@Location			varchar(250),
	@UnitPrice			Money,
	@ShortDesc			VarChar(50),
	@ReorderThreshold	int,
	@ReorderAmount		int,
	@OnOrder			int,
	@ShippingDimensions varchar(50),
	@ShippingWeight		float,
	@Active				Bit)
AS
	INSERT INTO [dbo].[Products]([Available],[OnHand],[Description],[Location],[UnitPrice],[ShortDesc],[ReorderThreshold],[ReorderAmount],[OnOrder],[ShippingDimensions],[ShippingWeight],[Active])
	VALUES ( @Available, @OnHand, @Description, @Location, @UnitPrice, @ShortDesc, @ReorderThreshold, @ReorderAmount, @OnOrder, @ShippingDimensions, @ShippingWeight, @Active)
	RETURN @@ROWCOUNT