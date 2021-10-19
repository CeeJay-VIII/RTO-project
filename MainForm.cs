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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        //Bringing the first panel to front
        private void MainForm_Load(object sender, EventArgs e)
        {
            pnlPersonalDetails.BringToFront();
        }

        //Public Variables
        public string name, middleName, surname, email, IDNo, code;
        public int marks = 0;
        
        //Panel1
        //Validating user input and keys
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else
            {
                e.Handled = false;
                name = txtName.Text;
            }
        }
        private void txtName_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtmiddleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else
            {
                e.Handled = false;
                middleName = txtmiddleName.Text;
            }
        }
        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar) || char.IsPunctuation(e.KeyChar))
                e.Handled = true;
            else
            {
                e.Handled = false;
            }
        }
        private void txtSurname_Validating(object sender, CancelEventArgs e)
        {
            surname = txtSurname.Text;
        }
        private void txtSurname_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!txtEmail.Text.StartsWith("@") ||
                      (txtEmail.Text.EndsWith("@gmail.com") ||
                      (txtEmail.Text.Contains("@") && (txtEmail.Text.EndsWith(".co.za") ||
                       txtEmail.Text.Contains(".org") || txtEmail.Text.EndsWith(".ac.za") ||
                       txtEmail.Text.EndsWith(".gov.za")) || txtEmail.Text.EndsWith(".com") ||
                       txtEmail.Text.EndsWith(".net"))))
            {
                email = txtEmail.Text;
            }
        }
        private void txtEmail_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider.Clear();
        }

        private void txtIDnumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsWhiteSpace(e.KeyChar) || char.IsPunctuation(e.KeyChar) ||
                char.IsSeparator(e.KeyChar) || char.IsSymbol(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = false;
        }
        private void txtIDnumber_Validating(object sender, CancelEventArgs e)
        {
            if (!(txtIDnumber.TextLength == 13))
                errorProvider.SetError(txtIDnumber, "Invalid ID number!");
            else
            {
                errorProvider.Clear();
                IDNo=txtIDnumber.Text;
            }
        }
        private void txtIDnumber_MouseClick(object sender, MouseEventArgs e)
        {
            errorProvider.Clear();
        }
        private void cboCode_Validating(object sender, CancelEventArgs e)
        {
            code = cboCode.Text;
        }

        //Procced button after providing your personal details
        void btnProcceed_Click(object sender, EventArgs e)
        {
            RTOclass rTO = new RTOclass();
            rTO.propName = name;
            rTO.propMiddleName = middleName;
            rTO.propSurname = surname;
            rTO.propEmail = email;
            rTO.propIDnumber = IDNo;
            rTO.propCode = code;
            //if the following conditions are true the user cannot proceed otherwise
            if (string.IsNullOrWhiteSpace(txtName.Text))
                errorProvider.SetError(txtName, "Name required!");
            else if (string.IsNullOrWhiteSpace(txtSurname.Text))
                errorProvider.SetError(txtSurname, "Surname required!");
            else if (string.IsNullOrWhiteSpace(txtEmail.Text))
                errorProvider.SetError(txtEmail, "Email required!");
            else if (txtEmail.Text.StartsWith("@")||
                     !(txtEmail.Text.EndsWith("@gmail.com") ||
                      (txtEmail.Text.Contains("@") && (txtEmail.Text.EndsWith(".co.za")||
                       txtEmail.Text.Contains(".org")||txtEmail.Text.EndsWith(".ac.za")||
                       txtEmail.Text.EndsWith(".gov.za"))||txtEmail.Text.EndsWith(".com")||
                       txtEmail.Text.EndsWith(".net"))))
                errorProvider.SetError(txtEmail, "Invalid email!");
            else if (string.IsNullOrWhiteSpace(txtIDnumber.Text))
                errorProvider.SetError(txtIDnumber, "ID number required!");
            else if (int.Parse(txtIDnumber.Text.Substring(2, 2)) > 12 || int.Parse(txtIDnumber.Text.Substring(4, 2)) > 31)
                errorProvider.SetError(txtIDnumber, "Invalid ID number!");
            else if ((string.IsNullOrWhiteSpace(cboCode.Text)))
                errorProvider.SetError(cboCode, "Must select code!");
            else if (rTO.CalcAge() < 18) //Validating the user age
            {
                lblUpdate.Text = "A learner must be over 18 years!";
                errorProvider.SetError(lblUpdate, "You are under age!\nA person under the age of 18 years\n" +
                    "is not eligible to have a Licence");
                grpInputs.Visible = false;
                btnExit_PersonalDetails.Visible = true;
            }
            else
            {
                errorProvider.Clear();
                pnlMCQ.BringToFront();
            }
        }

        //Exit button in the first panel
        private void btnExit_PersonalDetails_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Panel2
        //Multiple Choice Questions_MCQ for a learner who chose Code 1,2 or 3
        //Total marks for MCQ = 12  marks
        private void groupBox1_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton1D.Checked)
                marks += 2;
        }

        private void groupBox2_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton2B.Checked)
                marks += 2;
        }

        private void groupBox3_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton3B.Checked)
                marks += 2;
        }

        private void groupBox4_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton4C.Checked)
                marks += 2;
        }

        private void groupBox5_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton5B.Checked)
                marks += 2;
        }

        private void groupBox6_Validating(object sender, CancelEventArgs e)
        {
            if (radioButton6D.Checked)
                marks += 2;
        }


        //Next button on MCQ
        //Now this button will direct you to the questions related to what code you have chosen on the first panel
        private void btnMCQNext_Click(object sender, EventArgs e)
        {
            if (cboCode.SelectedIndex == 0)
                pnlCode1.BringToFront();
            else if (cboCode.SelectedIndex == 1)
                pnlCode2.BringToFront();
            else
                pnlCode3.BringToFront();
        }

        //Panel3
        //Questions for a learner who chose Code 1
        private void btnCode1Next_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "GEAR LEVER")
                marks++;
            if (textBox2.Text.Contains("CLUTCH"))
                marks++;
            if (textBox3.Text.Contains("MIRROR"))
                marks++;
            if (textBox4.Text == ("FRONT BRAKE"))
                marks++;
            if (textBox5.Text == "ACCELERATOR" || textBox5.Text == "THROTTLE")
                marks++;
            if (textBox6.Text.Contains("INDICATOR"))
                marks++;
            if (textBox7.Text.Contains("BRAKE"))
                marks++;
            if (textBox8.Text == "HANDLEBARS")
                marks++;
            if (textBox9.Text == "SPEEDOMETER")
                marks++;
            if (textBox10.Text == "TACHOMETER")
                marks++;
            if (textBox11.Text.Contains("SWITCH"))
                marks++;
            if (textBox12.Text.Contains("STARTER"))
                marks++;

            RTOclass rTOclass = new RTOclass();
            rTOclass.propName = name;
            rTOclass.propMiddleName = middleName;
            rTOclass.propSurname = surname;
            rTOclass.propEmail = email;
            rTOclass.propIDnumber = IDNo;
            rTOclass.propCode = code;
            rTOclass.propMarks = marks;
            //Displaying the results of the learner
            lblStatus.Text = rTOclass.getStatus();
            lblNote.Text = rTOclass.getNote();
            lblMarks.Text += rTOclass.propMarks;
            lblPercentageMarking.Text += rTOclass.CalcPercentageMark().ToString("f1")+"%";
            lblEmail.Text = rTOclass.propEmail;
            if (rTOclass.getThroughMark() == false)//Get getThroughMark is set to false if the percentageMarking <50%
            {
                pboPassed.Visible = false;
                btnInvoice.Visible = false;
                lblEmail.Visible = false;
            }
            pnlResults.BringToFront();
        }

        //Panel4
        //Questions for a learner who chose Code 2
        private void btnCode2Next_Click(object sender, EventArgs e)
        {
            if (textBox_1.Text == "REAR-VIEW" || textBox_1.Text == "REAR VIEW" || textBox_1.Text.Contains("MIRROR"))
                marks++;
            if (textBox_2.Text == "WIPER" || textBox_2.Text == "WIPERS")
                marks++;
            if (textBox_3.Text.Contains("MIRROR"))
                marks++;
            if (textBox_4.Text == "STEERING WHEEL")
                marks += 2;
            if (textBox_5.Text.Contains("INDICATOR"))
                marks++;
            if (textBox_6.Text == "GEAR LEVER")
                marks++;
            if (textBox_7.Text == "PARKING BRAKE" || textBox_7.Text==("HANDBRAKE"))
                marks++;
            if (textBox_8.Text == "CLUTCH")
                marks++;
            if (textBox_9.Text.Contains("BRAKE"))
                marks++;
            if (textBox_10.Text == "ACCELERATOR" || textBox_10.Text == "THROTTLE")
                marks++;
            if (textBox_11.Text == "HOOTER" || textBox_11.Text == "HORN")
                marks++;

            RTOclass rTOclass = new RTOclass();
            rTOclass.propName = name;
            rTOclass.propMiddleName = middleName;
            rTOclass.propSurname = surname;
            rTOclass.propEmail = email;
            rTOclass.propIDnumber = IDNo;
            rTOclass.propCode = code;
            rTOclass.propMarks = marks;
            //Displaying the results of the learner
            lblStatus.Text = rTOclass.getStatus();
            lblNote.Text = rTOclass.getNote();
            lblMarks.Text += rTOclass.propMarks;
            lblPercentageMarking.Text += rTOclass.CalcPercentageMark().ToString("f1")+"%";
            lblEmail.Text = rTOclass.propEmail;
            if (rTOclass.getThroughMark() == false)//Get getThroughMark is set to false if the percentageMarking <50%
            {
                pboPassed.Visible = false;
                btnInvoice.Visible = false;
                lblEmail.Visible = false;
            }
            pnlResults.BringToFront();
        }

        //Panel5
        //Questions for code 3 Learner
        private void btnCode3Next_Click(object sender, EventArgs e)
        {
            if (txtRegSign1.Text == "NO ENTRY" || txtRegSign1.Text == "PROHIBITED")
                marks++;
            if (txtRegSign2.Text.Contains("STOP"))
                marks++;
            if (txtProbSign1.Text == "NO OVERTAKING" ||
               (txtProbSign1.Text.Contains("OVERTAKING") && txtProbSign1.Text.Contains("PROHIBITED")))
                marks++;
            if (txtProbSign2.Text.Contains("U-TURN") || txtProbSign2.Text.Contains("U TURN") &&
                (txtProbSign2.Text.Contains("PROHIBITED")))
                marks++;
            if (txtRegSign1.Text.Contains("RESERVED") && txtRegSign1.Text.Contains("POLICE"))
                marks += 2;
            if (txtRegSign2.Text.Contains("RESERVED") && txtRegSign2.Text.Contains("LANE") &&
                (txtRegSign2.Text.Contains("BUS") || txtRegSign2.Text.Contains("BUSES")))
                marks += 2;
            if (txtWarnSign1.Text.Contains("TRAVERSE") || txtWarnSign1.Text.Contains("TRANSIT") ||
                txtWarnSign1.Text.Contains("CROSS") && (txtWarnSign1.Text.Contains("ROAD")))
                marks += 2;
            if (txtWarnSign2.Text.Contains("SPEED") && txtWarnSign2.Text.Contains("HUMP"))
                marks++;
            if (txtWarnSign3.Text.Contains("UNPAVED") || txtWarnSign3.Text.Contains("NOT PAVED") &&
                (txtWarnSign3.Text.Contains("ROAD")))
                marks++;

            RTOclass rTOclass = new RTOclass();
            rTOclass.propName = name;
            rTOclass.propMiddleName = middleName;
            rTOclass.propSurname = surname;
            rTOclass.propEmail = email;
            rTOclass.propIDnumber = IDNo;
            rTOclass.propCode = code;
            rTOclass.propMarks = marks;
            //Displaying the results of the learner
            lblStatus.Text = rTOclass.getStatus();
            lblNote.Text = rTOclass.getNote();
            lblMarks.Text += rTOclass.propMarks;
            lblPercentageMarking.Text += rTOclass.CalcPercentageMark().ToString("f1")+"%";
            lblEmail.Text = rTOclass.propEmail;
            if (rTOclass.getThroughMark() == false)//Get getThroughMark is set to false if the percentageMarking <50%
            {
                pboPassed.Visible = false;
                btnInvoice.Visible = false;
            }
            pnlResults.BringToFront();
        }
        //panel6
        //Button to exit the results panel
        private void btnResultsExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //This is the Invoice button
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            RTOclass rTOclass = new RTOclass();
            rTOclass.propName = name;
            rTOclass.propMiddleName = middleName;
            rTOclass.propSurname = surname;
            rTOclass.propIDnumber = IDNo;
            rTOclass.propCode = code;
            //Displaying invoice information
            txt_Initials.Text = rTOclass.getInitilas();
            txt_IDNnumber.Text = rTOclass.propIDnumber;
            txt_Gender.Text = rTOclass.getGender();
            txt_DOB.Text = rTOclass.getDOB().ToString("d");
            txt_Age.Text = rTOclass.CalcAge().ToString();
            txt_PermitNumber.Text = rTOclass.getPermitNumber();
            txt_ValidFrom.Text = DateTime.Now.ToString("d");
            txt_ValidTo.Text = DateTime.Now.AddMonths(12).ToString("d");
            txt_Code.Text = rTOclass.propCode;
            txt_Restrictions.Text = rTOclass.getRestrictions().ToString();
            if (rTOclass.getGender() == "MALE")//Displaying relavant picture for the user 
                pboFemale.Visible = false;     //we have two picture boxes with MALE & FEMALE
            lblfees.Text += rTOclass.CalcCodeFees().ToString("C");
            lblfees.Text += "\nIssueing fee :" + rTOclass.CalcIssueFee().ToString("C");
            lblfees.Text += "\nTotal cost pending :" + (rTOclass.CalcCodeFees() + rTOclass.CalcIssueFee()).ToString("C");
            pnlInvoice.BringToFront();
        }
        //panel7
        //Exiting the application
        private void btnInvoiceExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
