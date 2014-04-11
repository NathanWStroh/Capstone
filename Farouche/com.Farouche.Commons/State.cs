using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*Author: Adam Chandler
*Date Created: 04/03/14
*Last Modified: 04/03/14
*Last Modified By: Adam Chandler
*/


/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 04/03/14  Adam                                        Added State Class
*/

namespace com.Farouche.Commons
{
    public class State : Entity
    {
        private string _stateCode;
        private string _stateName;
        private int _firstZipCode;
        private int _lastZipCode;
        private int p;

        public State(int id)
        {

            _Id = id;
        }

        public string StateCode
        {
            get { return _stateCode; }
            set { _stateCode = value; }
        }
        public string StateName
        {
            get { return _stateName;  }
            set { _stateName = value; }
        }
        public int FirstZipCode
        {
            get { return _firstZipCode; }
            set { _firstZipCode = value; }
        }

        public int LastZipCode
        {
            get { return _lastZipCode; }
            set { _lastZipCode = value; }
        }



        public override Type GetType()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override string ToXml()
        {
            throw new NotImplementedException();
        }
    }
}
