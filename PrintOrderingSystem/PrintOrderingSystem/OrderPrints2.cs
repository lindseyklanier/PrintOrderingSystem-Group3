using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintOrderingSystem
{
    public partial class OrderPrints2 : Form
    {
        public OrderPrints2()
        {
            InitializeComponent();
            qty4X6Matte.Enabled = false;
            qty4X6Glossy.Enabled = false;
            qty5X7Matte.Enabled = false;
            qty5X7Glossy.Enabled = false;
            qty8X10Matte.Enabled = false;
            qty8X10Glossy.Enabled = false;
            radNextDay.Checked = true;
            totalPrice.Text = "$ 0.00";


        }

        private void paperSizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void chk4X6Glossy_CheckedChanged(object sender, EventArgs e)
        {

            qty4X6Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";
            

            if (chk4X6Glossy.Checked)
                qty4X6Glossy.Enabled = true;
            else
                qty4X6Glossy.Enabled = false;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void chk4X6Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty4X6Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk4X6Matte.Checked) {
                qty4X6Matte.Enabled = true;
        }
            else
                qty4X6Matte.Enabled=false;
        }

        private void OrderPrints2_Load(object sender, EventArgs e)
        {

        }

        private void chk5X7Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty5X7Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk5X7Matte.Checked)
            {
                qty5X7Matte.Enabled = true;
            }
            else
                qty5X7Matte.Enabled = false;

        }

        private void chk5X7Glossy_CheckedChanged(object sender, EventArgs e)
        {
            qty5X7Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk5X7Glossy.Checked)
            {
                qty5X7Glossy.Enabled = true;
            }
            else
                qty5X7Glossy.Enabled = false;

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void chk8X10Matte_CheckedChanged(object sender, EventArgs e)
        {
            qty8X10Matte.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk8X10Matte.Checked)
            {
                qty8X10Matte.Enabled = true;
            }
            else
                qty8X10Matte.Enabled = false;

        }

        private void chk8X10Glossy_CheckedChanged(object sender, EventArgs e)
        {
            qty8X10Glossy.Value = 0;
            totalPrice.Text = "$ 0.00";

            if (chk8X10Glossy.Checked)
            {
                qty8X10Glossy.Enabled = true;
            }
            else
                qty8X10Glossy.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal total = 0;
            total = qty4X6Matte.Value + qty4X6Glossy.Value + qty5X7Matte.Value + qty5X7Glossy.Value + qty8X10Matte.Value
                + qty8X10Glossy.Value;
            if (total <= 0)
            {
                MessageBox.Show("Select atleast one Print greater than Zero.",
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                       );
            }
            else if (total > 100)
            {
                MessageBox.Show("Total prints can't be more than 100",
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                      );

            }
            else
            {
                decimal totOrdValue = 0;
                totOrdValue = calculate4X6Glossy() 
                    + calculate4X6Matte() 
                    + calculate5X7Glossy() 
                    + calculate5X7Matte() 
                    + calculate8X10Glossy()
                    + calculate8X10Matte();

                if (radOneHour.Checked)  {
                    if (total <= 60)
                    {
                        totOrdValue += 2;
                    }
                    else { 
                        totOrdValue += (decimal)2.5; 
                    }
                }
    
            /*    MessageBox.Show("Total " + totOrdValue,
                       "Critical Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1
                      );
                */

                if (totOrdValue > 35) totOrdValue = totOrdValue - totOrdValue * (decimal) .05;

                totalPrice.Text = "$" + totOrdValue.ToString();

            }


        }

        private decimal calculate4X6Matte()
        {

            return qty4X6Matte.Value * (decimal)0.23 ;
        }

        private decimal calculate4X6Glossy()
        {

            return qty4X6Glossy.Value * (decimal)0.19 ;
        }
        
        private decimal calculate5X7Matte()
        {

            return qty5X7Matte.Value * (decimal)0.45;
        }

        private decimal calculate5X7Glossy()
        {

            return qty5X7Glossy.Value * (decimal)0.39 ;
        }

        private decimal calculate8X10Matte()
        {

            return qty8X10Matte.Value * (decimal)0.87;
        }

        private decimal calculate8X10Glossy()
        {

            return qty8X10Glossy.Value * (decimal)0.79;
        }

    }
}
