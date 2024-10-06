using System;
using System.Windows.Forms;

namespace SaveGameSaver
{
    internal static class Program
    {
        /*
         * Icons made by https://www.freepik.com/
         * Restore settings icons created by Freepik - Flaticon - <https://www.flaticon.com/free-icons/restore-settings>
         * Upload icons created by Google - Flaticon - <https://www.flaticon.com/free-icons/upload>
         */

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainAppForm());
        }
    }
}