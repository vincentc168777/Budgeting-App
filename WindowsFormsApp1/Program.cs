using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Form2 mainDisplay;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainDisplay = new Form2();
            Application.Run(mainDisplay);
            //Add an item to test
            //Item i = new Item { ItemName = "shirt", Cost = 19f };
            //DBConnect.SavePeople(i);

            
        }
    }
}
