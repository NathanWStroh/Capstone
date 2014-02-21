using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using com.Farouche.Commmons;
using com.Farouche.DataAccess;

//Author: Caleb
//Date Created: 1/31/2014
//Last Modified: 02/07/2014
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/07/2014   Adam                          0.0.1b        Updated method names and class name.
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
            //Returns true or false depending on if the record was inserted.
            return ProductDAL.InsertProduct(product, _connection);
        }//End of addProduct(.)

        public Boolean UpdateProduct(Product product, Product originalProduct)
        {
            return ProductDAL.UpdateProduct(product, originalProduct, _connection);
        }//End of updateProduct(..)

        public Boolean ReactivateProduct(Product product)
        {
            return ProductDAL.ReactivateProduct(product, _connection);
        }//End of reactivateProduct(.)

        public Boolean DeactivateProduct(Product product)
        {
            return ProductDAL.DeactivateProduct(product, _connection);
        }//End of deactivateProduct(.)

        public Boolean DeleteProduct(Product product)
        {
            return ProductDAL.DeleteProduct(product, _connection);
        }//End of deleteProduct(.)

        public List<Product> GetProducts()
        {
            List<Product> products = ProductDAL.FetchProducts(_connection);
            Console.WriteLine(products);
            return products;
        }//End of getProducts()

        public Product GetProduct(int productId)
        {
            Product myProduct = ProductDAL.FetchProduct(productId, _connection);
            return myProduct;
        } //End of getProduct(.)

        public List<Product> GetProductsByActive(Boolean activeState)
        {
            List<Product> products = ProductDAL.FetchProductsByActive(activeState, _connection);
            Console.WriteLine(products);
            return products;
        }//End of getProductsByActive(.)
    }
}
