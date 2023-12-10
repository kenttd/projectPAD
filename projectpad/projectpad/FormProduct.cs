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
    public partial class FormProduct : Form
    {
        AdventureWorks2019Entities db = new AdventureWorks2019Entities();
        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            refreshData();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void refreshData()
        {
            var products = from Product p in db.Products
                           select new
                           {
                               ProductName = p.Name,
                               MakeFlag = p.MakeFlag,
                               FinishedGoodsFlag = p.FinishedGoodsFlag,
                               SafetyStockLevel = p.SafetyStockLevel,
                               ReorderPoint = p.ReorderPoint,
                               StandardCost = p.StandardCost,
                               ListPrice = p.ListPrice,
                               DaysToManufacture = p.DaysToManufacture,
                               SellStartDate = p.SellStartDate,
                           };
            dataGridView1.DataSource = products.ToList();

        }
    }
}
