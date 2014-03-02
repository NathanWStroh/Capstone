using System.Data.SqlClient;

//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 02/7/2014 
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 02/7/2014   Adam                          0.0.1b         Added instancing.
* 
* 02/26/2014  Kaleb W                       0.0.3a         Adjusted connection string to include SQLExpress.
*/
namespace com.Farouche.DataAccess
{
    public class DatabaseConnection
    {
        const string ConnectionString = "Data Source=localhost\\SQLExpress;Initial Catalog=InventoryDatabase;Integrated Security=True";
        private static SqlConnection _myConnection;
        static protected SqlConnection GetInventoryDbConnection()
        {
            return _myConnection ?? (_myConnection = new SqlConnection(ConnectionString));
        }
    }
}
