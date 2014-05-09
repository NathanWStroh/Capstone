using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.Farouche.Commons
{
    public class RoleControl : Entity
    {
        private String _formName;
        private Boolean _visible;
        private Boolean _disabled;
        private int _roleID;
        public String status { get; set; }

        public Boolean Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public Boolean Disabled
        {
            get { return _disabled; }
            set { _disabled = value; }
        }

        public String FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }

        public int RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
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
