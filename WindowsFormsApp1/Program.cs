using System;

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
            Application.Run(new Form1());
            mainDisplay = new Form2();
            
            
        }
    }
}
