using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonProduct_Click(object sender, EventArgs e)
        {
            FormProduct product = new FormProduct();
            product.ShowDialog();
        }

        private void buttonSalesOffer_Click(object sender, EventArgs e)
        {
            FormSales f = new FormSales();
            f.ShowDialog();
        }
    }
}
