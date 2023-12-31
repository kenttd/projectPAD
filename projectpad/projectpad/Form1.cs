﻿using System;
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

        private void buttonCustomer_Click(object sender, EventArgs e)
        {
            FormCustomer f = new FormCustomer();
            f.ShowDialog();
        }

        private void buttonSalesPerson_Click(object sender, EventArgs e)
        {
            FormSalesPerson f = new FormSalesPerson();
            f.ShowDialog();
        }

        private void buttonTerritory_Click(object sender, EventArgs e)
        {
            FormTerritory f = new FormTerritory();
            f.ShowDialog();
        }
    }
}
