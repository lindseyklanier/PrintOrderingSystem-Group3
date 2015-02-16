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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            /*
               Form2 frm = new Form2();
               frm.Show();
             */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderPrints1 form1 = new OrderPrints1();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderPrints2 form2 = new OrderPrints2();
            form2.Show();
        }
    }
}
