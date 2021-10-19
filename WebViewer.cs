using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Regional_Transport_Office__CodeBreakerz_
{
    public partial class WebViewer : Form
    {
        public WebViewer()
        {
            InitializeComponent();
        }

        //WebBrowser link to Navigate to
        private void WebViewer_Load(object sender, EventArgs e)
        {
            webBrowser.Navigate("https://k53.autotrader.co.za/");
        }

        //Returning to home screen when this button is clicked
        private void btnHome_webBrowser_Click(object sender, EventArgs e)
        {
            RTO_Home rTO = new RTO_Home();
            rTO.Show();
            this.Hide();
        }

        //Exit the application when this button is clicked
        private void btnExit_webBrowser_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Setting the to "Loading..." when the webBrowser is navigating
        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            label1.Text = "Loading...";
        }

        //Clearing the "Loading..." text when the webBrowser navigated
        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            label1.Text = "";
        }
    }
}
