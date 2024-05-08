using System;

using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        public static Form2 mainDisplay;
        public static Form1 HomePage;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            HomePage = new Form1();
            Application.Run(HomePage);
            mainDisplay = new Form2();
            Application.Run(mainDisplay);   
        }
    }
}
