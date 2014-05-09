using System;
using com.Farouche.DataAccess;
using com.Farouche.Commons;
//Author: Steven Schuette
//Date Created: 1/31/2014
//Last Modified: 5/9/2014
//Last Modified By: Adam Chandler

namespace com.Farouche.BusinessLogic
{
    public class Authenticator
    {
        public static AccessToken Authenticate(int userID, String password)
        {
            try 
	        {	        
		        return AuthenticatorDAL.Authenticate(userID, password);
	        }
	        catch (Exception)
	        {
               throw new ApplicationException("Error retriving user credentials");
	        }
            throw new ApplicationException("User not found");
        }
    }
}
