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
            comboBoxMakeFlag.Items.Add("Purchased from supplier");
            comboBoxMakeFlag.Items.Add("Manufactured in-house");
            comboBoxGoodsFlag.Items.Add("Raw material or component");
            comboBoxGoodsFlag.Items.Add("Finished goods ready for sale");
            numericUpDownSafety.Maximum = 1000;
            numericUpDownReorder.Maximum = 1000;
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
                               ProductID = p.ProductID,
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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            int a = (int)dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value + 1;
            Guid guid = Guid.NewGuid();
            String productnumber = textBoxName.Text.Substring(0, 2).ToUpper()+"-"+a.ToString("D4");
            if (textBoxName.Text!="")
            {
                Product p = new Product() { 
                    Name = textBoxName.Text,
                    MakeFlag = (comboBoxMakeFlag.SelectedIndex==1),
                    FinishedGoodsFlag = (comboBoxGoodsFlag.SelectedIndex==1),
                    SafetyStockLevel = (short)numericUpDownSafety.Value,
                    ReorderPoint = (short)numericUpDownReorder.Value,
                    StandardCost = (Decimal)numericUpDownStandard.Value,
                    ListPrice = (Decimal)numericUpDownReorder.Value,
                    DaysToManufacture = (int)numericUpDownDays.Value,
                    SellStartDate = dateTimePickerSell.Value,
                    ProductNumber = productnumber,
                    ProductID = a,
                    ModifiedDate = DateTime.Now,
                    rowguid = guid,
                };
                db.Products.Add(p);
                db.SaveChanges();
                refreshData();
            }
        }
    }
}
