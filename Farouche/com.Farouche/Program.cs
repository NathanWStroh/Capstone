using System;
using System.Windows.Forms;
using com.Farouche.Commons;
namespace com.Farouche.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin(_myAccessToken));
        }
    }
}
