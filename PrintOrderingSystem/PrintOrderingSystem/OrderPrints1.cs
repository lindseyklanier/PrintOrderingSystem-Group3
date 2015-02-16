using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 

3.2.1    If all prints have the same size, the system should calculate the price as below:
3.2.1.1  Prices for size 4 x 6 are:
3.2.1.1.1        First 1 – 50 prints: $ 0.14 each
3.2.1.1.2        Prints after 50 and before or equal 75 - $ 0.12
3.2.1.1.3        Prints after 75 and before or equal 100 - $ 0.10
3.2.1.2  Prices for size 5 x 7 are:
3.2.1.2.1        First 1 – 50 prints: $ 0.34 each
3.2.1.2.2        Prints after 50 and before or equal 75 - $ 0.31
3.2.1.2.3        Prints after 75 and before or equal 100 - $ 0.28
 
3.2.1.3  Prices for size 8 x 10 are:
3.2.1.3.1        First 1 – 50 prints: $ 0.68 each
3.2.1.3.2        Prints after 50 and before or equal 75 - $ 0.64
3.2.1.3.3        Prints after 75 and before or equal 100 - $ 0.60
 
3.2.1.4  If all prints have matte finish, the system should add:
3.2.1.4.1        0.02 for each print 4 x 6 size
3.2.1.4.2        0.03 for each print 5 x 7 size
3.2.1.4.3        0.04 for each print 8 x 10 size
 
 */

namespace PrintOrderingSystem
{
    public partial class OrderPrints1 : Form
    {
        public decimal totalCalculatedPrice = 0;

        public OrderPrints1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillComboBoxes();
        }

        private void FillComboBoxes()
        {
            paperSizeCB.Items.Add("4 x 6");
            paperSizeCB.Items.Add("5 x 7");
            paperSizeCB.Items.Add("8 x 10");
            paperSizeCB.SelectedItem = paperSizeCB.Items[0];

            finishCB.Items.Add("Glossy");
            finishCB.Items.Add("Matte");
            finishCB.SelectedItem = finishCB.Items[0];

            ptCB.Items.Add("Standard");
            ptCB.Items.Add("1-hour");
            ptCB.SelectedItem = ptCB.Items[0];
        }

        private void calculatePriceButton_Click(object sender, EventArgs e)
        {
            // Calculate 4 x 6
            if (paperSizeCB.SelectedItem.Equals(paperSizeCB.Items[0]))
            {
                Calculate4x6();
            }
            // Calculate 5 x 7
            if(paperSizeCB.SelectedItem.Equals(paperSizeCB.Items[1]))
            {
                Calculate5x7();
            }

            // Calculate 8 x 10
            if (paperSizeCB.SelectedItem.Equals(paperSizeCB.Items[2]))
            {
                Calculate8x10();
            }

            //Check processing time
            //“If processing time is 1-hour the client should add $ 1.00 if the order has less or equal 60 prints and $ 1.50 if the order has more than 60 prints”
            if(ptCB.SelectedItem.Equals(ptCB.Items[1]))
            {
               if(totalQuantity.Value < 61) {                   
                    totalCalculatedPrice += 1;
                    Debug.WriteLine("Added an extra dollar for 1-hour processing time.");
                }

                if(totalQuantity.Value > 60) {
                    totalCalculatedPrice += (decimal)1.50;
                    Debug.WriteLine("Added an extra $1.50 for 1-hour processing time.");
                }
            }

            //Check for promotion code
            if(totalQuantity.Value > 99 && promoCodeTextBox.Text.Equals("N56M2"))
            {
                totalCalculatedPrice -= 1;
                Debug.WriteLine("Your promotion code has been accepted.");
            }

            //See if the order is eligible for a 5% reduction
            if(totalCalculatedPrice > 34)
            {
                decimal discount = totalCalculatedPrice * (decimal)0.05;
                totalCalculatedPrice -= discount;
                Debug.WriteLine("A discount has been applied to this order!");
            }

            Debug.WriteLine("Calculated Total: $" + totalCalculatedPrice);
            totalPrice.Text = "$" + totalCalculatedPrice.ToString();

        }

        private void Calculate4x6()
        {
            /* 3.2.1.1       Prices for size 4 x 6 are:
            3.2.1.1.1        First 1 – 50 prints: $ 0.14 each
            3.2.1.1.2        Prints after 50 and before or equal 75 - $ 0.12
            3.2.1.1.3        Prints after 75 and before or equal 100 - $ 0.10
                             If Matte: 0.02 for each print 4 x 6 size
             */

            decimal tQ = totalQuantity.Value;          

            if(tQ > 0 && tQ < 51)
            {
                totalCalculatedPrice = tQ * (decimal)0.14;    
            }

            if(tQ > 50 && tQ < 76)
            {
                totalCalculatedPrice = tQ * (decimal)0.12;
            }

            if(tQ > 75 && tQ < 101)
            {
                totalCalculatedPrice = tQ * (decimal)0.10;
            }

            if(finishCB.SelectedItem == finishCB.Items[1]) //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.02;
                totalCalculatedPrice += additionalCharge;
                Debug.WriteLine("An additional charge has been added for Matte finish.");
            }

            Debug.WriteLine("Calculate4x6 Debugging, Price = " + totalCalculatedPrice);
            //totalPrice.Text = "$" + totalCalculatedPrice.ToString();


        }

        private void Calculate5x7()
        {
            /* 
                3.2.1.2  Prices for size 5 x 7 are:
                3.2.1.2.1        First 1 – 50 prints: $ 0.34 each
                3.2.1.2.2        Prints after 50 and before or equal 75 - $ 0.31
                3.2.1.2.3        Prints after 75 and before or equal 100 - $ 0.28
                If Matte: 0.03 for each print 5 x 7 size
             */

            decimal tQ = totalQuantity.Value;            

            if (tQ > 0 && tQ < 51)
            {
                totalCalculatedPrice = tQ * (decimal)0.34;
            }

            if (tQ > 50 && tQ < 76)
            {
                totalCalculatedPrice = tQ * (decimal)0.31;
            }

            if (tQ > 75 && tQ < 101)
            {
                totalCalculatedPrice = tQ * (decimal)0.28;
            }

            if (finishCB.SelectedItem == finishCB.Items[1]) //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.03;
                totalCalculatedPrice += additionalCharge;
                Debug.WriteLine("An additional charge has been added for Matte finish.");
            }

            Debug.WriteLine("Calculate5x7 Debugging, Price = " + totalCalculatedPrice);
            //totalPrice.Text = "$" + totalCalculatedPrice.ToString();
        }

        private void Calculate8x10()
        {
            /* 
                3.2.1.3  Prices for size 8 x 10 are:
                3.2.1.3.1        First 1 – 50 prints: $ 0.68 each
                3.2.1.3.2        Prints after 50 and before or equal 75 - $ 0.64
                3.2.1.3.3        Prints after 75 and before or equal 100 - $ 0.60
                If Matte: 0.04 for each print 5 x 7 size
             */

            decimal tQ = totalQuantity.Value;

            if (tQ > 0 && tQ < 51)
            {
                totalCalculatedPrice = tQ * (decimal)0.68;
            }

            if (tQ > 50 && tQ < 76)
            {
                totalCalculatedPrice = tQ * (decimal)0.64;
            }

            if (tQ > 75 && tQ < 101)
            {
                totalCalculatedPrice = tQ * (decimal)0.60;
            }

            if (finishCB.SelectedItem == finishCB.Items[1]) //If Matte finish is chosen, add 0.02 for each print.
            {
                decimal additionalCharge = tQ * (decimal)0.04;
                totalCalculatedPrice += additionalCharge;
                Debug.WriteLine("An additional charge has been added for Matte finish.");
            }

            Debug.WriteLine("Calculate8x10 Debugging, Price = " + totalCalculatedPrice);
            //totalPrice.Text = "$" + totalCalculatedPrice.ToString();
        }
    }
}
