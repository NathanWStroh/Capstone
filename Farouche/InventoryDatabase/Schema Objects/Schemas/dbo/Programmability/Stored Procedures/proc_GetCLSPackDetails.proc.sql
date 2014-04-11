CREATE PROCEDURE [dbo].[proc_GetCLSPackDetails]
	(@ShippingOrderId int)
AS
	SELECT so.ShippingOrderID, so.ShippingTermID, sv.ShippingVendorID, st.Description, sv.Name, st.Description, si.ProductID, pr.ShortDesc, si.Quantity, so.ShipDate, so.ShipToName, so.ShipToAddress, so.ShipToCity, so.ShipToState, so.ShipToZip
	FROM [dbo].[ShippingTermsLookup] st, [dbo].[Products] pr, [dbo].[ShippingVendors] sv, [dbo].[ShippingOrders] so, [dbo].[ShippingOrderLineItems] si
	WHERE so.ShippingOrderID = @ShippingOrderId AND so.ShippingTermID = st.ShippingTermID AND st.ShippingVendorID = sv.ShippingVendorID AND so.ShippingOrderID = si.ShippingOrderID AND si.ProductID = pr.ProductID
RETURN