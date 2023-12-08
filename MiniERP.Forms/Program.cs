using System;
using System.Windows.Forms;

namespace MiniERP.Forms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Altere a linha abaixo para iniciar o novo formulário (MainForm) em vez de Form1
            Application.Run(new MainForm());
        }
    }
}
