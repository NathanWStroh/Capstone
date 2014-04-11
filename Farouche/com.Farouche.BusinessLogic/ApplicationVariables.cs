﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.Farouche.BusinessLogic;
using com.Farouche.Commons;
using com.Farouche.DataAccess;
using System.Data.SqlClient;


//Author: Andrew
//Date Created: 4/10/14
//Last Modified: 4/10/14
//Last Modified By: Andrew Willhoit

/*
*                               Changelog
* Date         By          Ticket          Version         Description
*
* 
*/


namespace com.Farouche.BusinessLogic
{
    public class ApplicationVariables
    {
        private static readonly ApplicationVariables _instance = new ApplicationVariables();
        private Dictionary<int, State> _states;
        private Dictionary<String, String> _variables;

        public Dictionary<String, String> Variables
        {
            get { return _variables;  }
        }
        public Dictionary<int, State> States
        {
            get { return _states; }
            set { _states = value; }
        }
        public static ApplicationVariables Instance 
        { 
            get { return _instance; } 
        }

        private ApplicationVariables()
        {
            try
            {
                _variables = ApplicationVariablesDAL.GetAllApplicationVariables();
                StateManager stateManager = new StateManager();
                Dictionary<int, State> tempStates = new Dictionary<int, State>();

                // Dictionary<int, State> tempStates = new Dictionary<int, State>(stateManager.GetAllStates());

                //  Dictionary<int, State> tempStates = new Dictionary<int, State>();
                //  tempStates = stateManager.GetAllStates();


                //  _states = new Dictionary<int, State>(tempStates);


                // tempStates = StatesDAL.GetAllStates(_connection);


                //     Console.WriteLine(stateManager.GetAllStates().ToString());



                //   tempStates.Add();

            }
            catch (SqlException ex)
            {

                Console.WriteLine("Database server or Connection error. Please conntact your system administrator" + ex.ToString());
                //throw ex;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NULL REF EXCEPTION!! \n" + ex.ToString() + "\n" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION!! \n" + ex.ToString() + "\n" + ex.Message);
            }
        
        }
    } //end ApplicationVariables class
}
