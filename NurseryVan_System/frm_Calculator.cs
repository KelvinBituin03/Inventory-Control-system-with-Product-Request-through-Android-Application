using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NurseryVan_System
{
    public partial class frm_Calculator : Form
    {
        public frm_Calculator()
        {
            InitializeComponent();
        }
        string operation;
        string firstnum;
        string secondnum;

        double result = 0;
        bool enter_value = false;

        private void frm_Calculator_Load(object sender, EventArgs e)
        {
            if (lblDisplayText.Text == "0")
            {
                btnEquals.Enabled = false;
                return;
            }
        }

        private void Operators_Click(object sender, EventArgs e)
        {
            try
            {
                Button num = (Button)sender;
                if (result != 0)
                {
                    btnEquals.PerformClick();
                    enter_value = true;
                    operation = num.Text;
                    lblShowCal.Text = result + " " + operation;


                }
                else
                {


                    operation = num.Text;
                    result = Double.Parse(lblDisplayText.Text);
                    enter_value = true;

                    lblShowCal.Text = result + " " + operation;
                }


                firstnum = lblShowCal.Text;

           

            }
            catch (Exception)
            {

            }

        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            try
            {


                secondnum = lblDisplayText.Text;
                lblShowCal.Text = "";

                switch (operation)
                {

                    case "+":
                        lblDisplayText.Text = (result + Double.Parse(lblDisplayText.Text)).ToString();


                        break;

                    case "-":
                        lblDisplayText.Text = (result - Double.Parse(lblDisplayText.Text)).ToString();
                        break;
                    case "x":
                        lblDisplayText.Text = (result * Double.Parse(lblDisplayText.Text)).ToString();
                        break;
                    case "÷":
                        lblDisplayText.Text = (result / Double.Parse(lblDisplayText.Text)).ToString();
                        break;


                    default:

                        break;


                }
                result = 0;
                lblShowCal.Text = "";
                result = Double.Parse(lblDisplayText.Text);
                operation = "";

                btnHistory.Visible = true;
                richTextBox1.AppendText(firstnum + " " + secondnum + " = " + lblDisplayText.Text + "\n\n");

                lblhistory.Text = "";
                btnEquals.Enabled = false;

                if (result != 0)
                {

                    enter_value = true;

                    firstnum = lblShowCal.Text;

                }

                if (lblDisplayText.Text == "∞")
                {

                    lblDisplayText.Text = "Cannot divide by 0."; new Font("Arial", 12);
                    richTextBox1.Clear();
                    return;
                }

            }
            catch (Exception)
            {
                btnEquals.Enabled = false;
            }
        }

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            try
            {


                if (lblDisplayText.Text.Length > 0)
                {
                    lblDisplayText.Text = lblDisplayText.Text.Remove(lblDisplayText.Text.Length - 1, 1);
                }

                if (lblDisplayText.Text == "")
                {
                    lblDisplayText.Text = "0";
                }
            }
            catch (Exception)
            {

            }
        }

        private void lblDisplayText_Click(object sender, EventArgs e)
        {
            if (lblDisplayText.Text.Length == 11)
            {
                MessageBox.Show("Stop!");
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblDisplayText.Text = "0";
            lblShowCal.Text = "";
            result = 0;
            btnEquals.Enabled = false;
            firstnum = "0 + ";
        }

        private void btnClearE_Click(object sender, EventArgs e)
        {

            lblDisplayText.Text = "0";
            lblShowCal.Text = "";
            result = 0;
            btnEquals.Enabled = false;
            firstnum = "0 + ";
        }

        private void frm_Calculator_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void Numbers(object sender, EventArgs e)
        {

            try
            {

                Button num = (Button)sender;
                if ((lblDisplayText.Text == "0") || (enter_value))

                    lblDisplayText.Text = "";
                enter_value = false;

                if (num.Text == ".")
                {
                    if (!lblDisplayText.Text.Contains("."))

                        lblDisplayText.Text = lblDisplayText.Text + num.Text;

                }


                else
                {
                    lblDisplayText.Text = lblDisplayText.Text + num.Text;
                }




                btnEquals.Enabled = true;



                if (lblDisplayText.Text.Length == 11)
                {
                    lblDisplayText.Text = lblDisplayText.Text.Remove(lblDisplayText.Text.Length - 1, 1);
                    return;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (lblhistory.Text == "")
            {
                lblhistory.Text = "There's no history yet.";
            }
            btnHistory.Visible = false;
        }
    }
}
