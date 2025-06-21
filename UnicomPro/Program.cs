using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomPro.Database;
using UnicomPro.View;

namespace UnicomPro
{
    internal static class Program
    {
      
        [STAThread]
        static void Main()
        {

            Migration.CreateTables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Application.Run(new LoginForm());
        }
    }
}
