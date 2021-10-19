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
    public partial class RTO_Home : Form
    {
        public RTO_Home()
        {
            InitializeComponent();
        }

        //Link to the form which has the Website with K53 Manuals
        private void llbGoogle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WebViewer webViewer = new WebViewer();
            webViewer.Show();
            this.Hide();
        }

        //Messagebox for terms and conditions
        private void llbTermsAndConditions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("TERMS & CONDITIONS OF USE." +
                "\n\nBy establishing an account with Professional " +
                "\nOnline Testing Solutions, Inc. (RTO) and by " +
                "\npurchasing an online test you I agree to and " +
                "\naccept the terms and conditions of this Assessment" +
                "\nAgreement." +
                "\n\nScope of Agreement.");
        }

        //Enabling the button to procced only if the user accept T&C's
        private void chkTermsAndConditions_CheckedChanged(object sender, EventArgs e)
        {
            btnClickHere.Enabled = true;
            if (chkTermsAndConditions.Checked)
            {
                chkTermsAndConditions.Enabled = false;
                btnClickHere.BackColor = Color.Green;
            }
        }

        //Main menu exit button
        private void btnMainMenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Procceding to the next form when this buuton is clicked
        private void btnClickHere_Click(object sender, EventArgs e)
        {
            MainForm assessment = new MainForm();
            assessment.Show();
            this.Hide();
        }
    }
}
