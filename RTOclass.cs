using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Regional_Transport_Office__CodeBreakerz_
{
    public class RTOclass
    {
        //Private fields / attributes
        private string name;
        private string middleName;
        private string surname;
        private string email;
        private string IDnumber;
        private string code;
        private int marks;
        private double percentageMark;
        private const int totalMarks = 24;

        //Property structures /Getter-Setter method
        public string propName { get => name; set => name = value; }
        public string propMiddleName { get => middleName; set => middleName = value; }
        public string propSurname { get => surname; set => surname = value; }
        public string propEmail { get => email; set => email = value; }
        public string propIDnumber { get => IDnumber; set => IDnumber = value; }
        public string propCode { get => code; set => code = value; }
        public int propMarks { get => marks; set => marks = value; }
        public double propPercentageMark { get => percentageMark; set => percentageMark = value; }

        //Default contructor
        public RTOclass()
        {
            name = "";
            middleName = "";
            surname = "";
            email = "";
            IDnumber = "";
            code = "";
            marks = 0;
            percentageMark = 0;
        }

        //Parametarised constructor
        public RTOclass(string n, string mn, string s, string eml, string ID, string cd, int m, double pm)
        {
            name = n;
            middleName = mn;
            surname = s;
            email = eml;
            IDnumber = ID;
            code = cd;
            marks = m;
            percentageMark = pm;
        }

        //Methods / Functions
        public DateTime getDOB()//Extracting date of birth from an ID number
        {
            int Y, M, D;
            if (int.Parse(IDnumber.Substring(0, 2)) > 99 ||
                int.Parse(IDnumber.Substring(0, 2)) < DateTime.Now.Year-2000)
                Y = int.Parse(IDnumber.Substring(0, 2)) + 2000;
            else
                Y = int.Parse(IDnumber.Substring(0, 2)) + 1900;
            M = int.Parse(IDnumber.Substring(2, 2));
            D = int.Parse(IDnumber.Substring(4, 2));
            return (DateTime.Parse($"{Y}/{M}/{D}"));
        }
        public int CalcAge()//Calculating age
        {
            return (DateTime.Now.Year - getDOB().Year);
        }
        public string getInitilas()//Getting initials from the information provided
        {
            if(middleName==null)
                return ($"{name.Substring(0, 1).ToUpper()} {surname.ToUpper()}");
            else
                return ($"{name.Substring(0,1).ToUpper()} {middleName.Substring(0,1).ToUpper()} {surname.ToUpper()}");
        }
        public string getGender()//Determining gender using ID number
        {
            if (int.Parse(IDnumber.Substring(6, 4)) > 4999)
                return ("MALE");
            else
                return ("FEMALE");
        }
        public double CalcPercentageMark()//Calculating percentage marking for the assessment
        {
            return (100.0*marks/totalMarks);
        }
        public string getPermitNumber()//Generating rondom permit number
        {
            Random rnd = new Random();
            int min = 000000;
            int max = 999999;
            int num0 = rnd.Next(min,max);
            int num1 = rnd.Next(min, max);
            return ($"{num0}{num1}");
        }
        public bool getThroughMark()//Determining whether the learner passed the the assessment
        {
            if (CalcPercentageMark() >= 50)
                return (true);
            else
                return (false);
        }
        public string getStatus()//generating the feed after taking an assessment
        {
            if (getThroughMark() == true)
                return ("Success!");
            else
                return ("Unsuccessful");
        }
        public string getNote()//Notice for the learner
        {
            if (getThroughMark() == true)
                return ("Visit any nearest Driving License Test Centre's [DTLC]" +
                    " for further information and payments.");
            else
                return ("Better luck next time!\n*FAIL = First Attempt In Learning.");
        }
        public int getRestrictions()//Determining the number of restrictions depending on your CODE
        {
            if (code == "CODE-1")
                return (2);
            else
                return (1);
        }
        public double CalcCodeFees()//Calculating fees for different drivers CODE *fees vary according to your CODE
        {
            Random rnd = new Random();
            if (code == "CODE-1")
            {
                double fees = rnd.Next(30, 60);
                return (fees);
            }
            else if(code == "CODE-2")
            {
                double fees = rnd.Next(80, 160);
                return (fees);
            }
            else
            {
                double fees = rnd.Next(180, 200);
                return (fees);
            }
        }
        public double CalcIssueFee()//Calculating fees for issueing of the leaners *also vary
        {
            Random rnd = new Random();
            if (code == "CODE-1")
            {
                double fee = rnd.Next(20, 29);
                return (fee);
            }
            else if (code == "CODE-2")
            {
                double fee = rnd.Next(33, 40);
                return (fee);
            }
            else
            {
                double fee = rnd.Next(40, 50);
                return (fee);
            }
        }
    }
}
