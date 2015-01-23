using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkytapApi;

namespace SkytapDesktop
{
    static class Program
    {
        public static List<Configuration> Configurations { get; set; }
        public static Configuration DefaultConfiguration { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false); 
            Application.Run(new Dashboard());
        }
    }
}
