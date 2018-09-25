using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.Specialized;

using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Core.DatabaseTableClass;
using System.Data;

namespace Krov
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);        
            Application.Run(new Autorisation());
        }

    }
}
