using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace qunit.net
{
	public partial class BrowserWindow : Form
	{
		public bool passed = false;

		public BrowserWindow()
		{
			InitializeComponent();
		}

		private void BrowserWindow_Shown(object sender, EventArgs e)
		{
			try
			{
                webBrowser.Navigate(RunOptions.html_page);

				while (webBrowser.ReadyState != WebBrowserReadyState.Complete)
					Application.DoEvents();

                var x = webBrowser.Document.GetElementById(RunOptions.qunit_finished_id);
				while (x.InnerText != "done")
					Application.DoEvents();

                var testResults = webBrowser.Document.GetElementById(RunOptions.qunit_testresult_id).InnerHtml;
				var matches = Regex.Matches(testResults, ">[0-9]+<");
				var success = int.Parse(matches[0].Value.Trim('<', '>'));
				var total = int.Parse(matches[1].Value.Trim('<', '>'));
				var failed = int.Parse(matches[2].Value.Trim('<', '>'));

				if (success != total)
					passed = false;
				else if (failed != 0)
					passed = false;
				else
					passed = true;
			}
			catch
			{
				passed = false;
			}
			this.Close();
		}
	}
}
