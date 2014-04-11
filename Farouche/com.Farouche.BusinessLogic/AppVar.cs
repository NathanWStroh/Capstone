using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class AppVar
    {
        private static readonly AppVar _instance = new AppVar();
        private AppVar() {}
        public static AppVar Instance { get {return _instance; } }
    }
