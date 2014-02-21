using System;

//Author: Adam
//Date Created: 1/31/2014
//Last Modified: 1/31/2014
//Last Modified By: Adam Chandler

/*
*                               Changelog
* Date         By          Ticket          Version         Description
* 1/31/2014   Adam                          0.0.1b        Changed id to a private set
*/
namespace com.Farouche.Commons
{
    public abstract class Entity
    {

        protected int _Id;
        private string _name;
        private Boolean _active;

        public  int Id
        {
            get
            {
                return _Id;
            }
            protected set
            {
                _Id = value;
            }
        }

        public new abstract Type GetType();
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public Boolean Active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
        public abstract override string ToString();
        public abstract string ToXml();
    }
}
