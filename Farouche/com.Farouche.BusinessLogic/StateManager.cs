using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.DataAccess;
using System.Data.SqlClient;
using com.Farouche.Commons;

namespace com.Farouche.BusinessLogic
{
    class StateManager: DatabaseConnection
    {
        private readonly SqlConnection _connection = GetInventoryDbConnection();

        public Dictionary<int, State> GetAllStates()
        {
            return StatesDAL.GetAllStates(_connection);
        }
    }
}
