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
    public partial class FormSales : Form
    {
        AdventureWorks2019Entities db = new AdventureWorks2019Entities();
        public FormSales()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSales_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        public void refreshData()
        {
            var salesoffer = from SpecialOffer so in db.SpecialOffers
                             select new
                             {
                                 ID = so.SpecialOfferID,
                                 Type = so.Type,
                                 StartDate = so.StartDate,
                                 EndDate = so.EndDate,
                                 Description = so.Description,
                                 Discount = so.DiscountPct,
                                 Category = so.Category,
                                 MinQty = so.MinQty,
                                 MaxQty = so.MaxQty,
                             };
            dataGridView1.DataSource=salesoffer.ToList();
        }
    }
}
