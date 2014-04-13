using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Resources;

namespace com.Farouche.Commons
{
    public class Messeges
    {
        public static String GetMessage(String message)
        {
            if (message.Length == 0)
            {
                throw new ArgumentException("No message string passed in");
            }
            return ApplicationStrings.ResourceManager.GetString(message);
        }
    }
}
