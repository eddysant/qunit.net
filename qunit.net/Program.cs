using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace qunit.net
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{

            if (args.Length == 1)
            {
                RunOptions.html_page = args[1];
            }
            else if (string.IsNullOrEmpty(RunOptions.html_page))
            {
                MessageBox.Show("The html page to run is required. Either include it in the run command, or set it in RunOptions.");
                return;
            }
			
            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var window = new BrowserWindow();
			window.ShowDialog();			

		}
	}
}
