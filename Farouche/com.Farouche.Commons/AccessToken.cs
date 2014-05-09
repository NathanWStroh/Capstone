//Author: Steven Schuette
//Date Created: 1/28/2014
//Last Modified: 1/30/2014
//Last Modified By: Steven Schuette

namespace com.Farouche.Commons
{
    public class AccessToken : Entity
    {
        private Role _Role;
        private string _FirstName;
        private string _LastName;

        public Role Role
        {
            get { return _Role; }
            set { _Role = value; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        public int UserID
        {
            get { return _Id; }
        }
        public AccessToken(int UserID)
        {
            _Id = UserID;
        }

        public AccessToken()
        {
        }

        public override System.Type GetType()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public override string ToXml()
        {
            throw new System.NotImplementedException();
        }
    }
}
