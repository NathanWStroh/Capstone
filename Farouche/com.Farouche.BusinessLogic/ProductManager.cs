using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.DataAccess;
using com.Farouche.Commons;
//Author: Kaleb Wendel
//Date Created: 1/31/2014
//Last Modified: 03/30/2014
//Last Modified By: Kaleb Wendel

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014   Adam                          0.0.1b        Updated method names and class name.
* 
* 02/26/2014   Kaleb                         0.0.3a        Adjusted the get product methods to assign the returned values to Products.
*
* 03/30/2014   Kaleb                                       Added UpdateThreshold, UpdateReorderAmount, UpdateOnOrder methods.
*
* 03/30/2014   Kaleb                                       Added additional error checking on existing methods.
* 
* 04/02/2014   Kaleb                                       Added GetLocations method.
*/
namespace com.Farouche.BusinessLogic
{
    public class ProductManager : DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();
        public List<Product> Products;
        public Product Product;
        public Boolean AddProduct(Product product)
        {
            if (product == null) throw new ArgumentException("The product was null, therefore it cannot be added.");
            //Returns true or false depending on if the record was inserted.
            return ProductDAL.InsertProduct(product, _connection);
        }//End of addProduct(.)

        public Boolean UpdateProduct(Product product, Product originalProduct)
        {
            if (product == null || originalProduct == null) throw new ArgumentException("The product was null, therefore it cannot be updated.");
            return ProductDAL.UpdateProduct(product, originalProduct, _connection);
        }//End of updateProduct(..)

        public Boolean ReactivateProduct(Product product)
        {
            if (product == null) throw new ArgumentException("The product was null, therefore it cannot be set as active.");
            return ProductDAL.ReactivateProduct(product, _connection);
        }//End of reactivateProduct(.)

        public Boolean DeactivateProduct(Product product)
        {
            if (product == null) throw new ArgumentException("The product was null, therefore it cannot be set as inactive.");
            return ProductDAL.DeactivateProduct(product, _connection);
        }//End of deactivateProduct(.)

        public Boolean DeleteProduct(Product product)
        {
            if (product == null) throw new ArgumentException("The product was null, therefore it cannot be deleted.");
            return ProductDAL.DeleteProduct(product, _connection);
        }//End of deleteProduct(.)

        public List<Product> GetProducts()
        {
            Products = ProductDAL.FetchProducts(_connection);
            return Products;
        }//End of getProducts()

        public Product GetProduct(int productId)
        {
            Product myProduct = ProductDAL.FetchProduct(productId, _connection);
            return myProduct;
        } //End of getProduct(.)

        public List<Product> GetProductsByActive(Boolean activeState)
        {
            Products = ProductDAL.FetchProductsByActive(activeState, _connection);
            return Products;
        }//End of getProductsByActive(.)

        public List<String> GetLocations()
        {
            var locations = ProductDAL.FetchLocations(_connection);
            return locations;
        }//End of GetLocations()

        // start of new methods - 3.28.14
        public Boolean UpdateThreshold(int amount, int productID)
        {
            if (amount < 0) throw new ArgumentException("The threshold amount is invalid. This value must be greater than or equal to zero.");
            return ProductDAL.UpdateThreshold(amount, productID, _connection);
        } //End of UpdateThreshold(.)

        public Boolean UpdateReorderAmount(int amount, int productID)
        {
            if (amount < 0) throw new ArgumentException("The reorder amount is invalid. This value must be greater than or equal to zero.");
            return ProductDAL.UpdateReorderAmount(amount, productID, _connection);
        } //End of UpdateReorderAmount(.)

        public Boolean UpdateOnOrder(int amount, int productID)
        {
            if (amount < 0) throw new ArgumentException("The on order amount is invalid. This value must be greater than or equal to zero.");
            return ProductDAL.UpdateOnOrder(amount, productID, _connection);
        } //End of UpdateOnOrder(.)
    }
}
