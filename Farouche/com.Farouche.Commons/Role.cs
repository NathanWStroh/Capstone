using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class Role : Entity
    {
        private string _desciption;
        private List<RoleControl> _controls;
        public Role(int id)
        {
            this.Id = id;
        }

	    public string Description
	    {
		    get { return _desciption;}
            set { _desciption = value; }
	    }

        public List<RoleControl> Controls
        {
            get { return _controls;  }
            set { _controls = value; }
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
