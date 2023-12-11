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
        int id = -1;
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
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
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

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            comboBoxGoodsFlag.SelectedIndex = -1;
            comboBoxMakeFlag.SelectedIndex = -1;    
            numericUpDownSafety.Value = 0;
            numericUpDownReorder.Value = 0;
            numericUpDownStandard.Value = 0;
            numericUpDownDays.Value = 0;
            numericUpDownPrice.Value = 0;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            buttonDelete.Enabled = true;
            buttonUpdate.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            var deleted = db.Products.FirstOrDefault(h => h.ProductID == id);
            db.Products.Remove(deleted);
            db.SaveChanges();
            refreshData();
            id = -1;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            buttonUpdate.Enabled = false;
            buttonDelete.Enabled = false;
            var updated = db.Products.FirstOrDefault(h => h.ProductID == id);
            updated.Name = textBoxName.Text;
            updated.MakeFlag = (comboBoxMakeFlag.SelectedIndex == 1);
            updated.FinishedGoodsFlag = (comboBoxGoodsFlag.SelectedIndex == 1);
            updated.SafetyStockLevel = (short)numericUpDownSafety.Value;
            updated.ReorderPoint = (short)numericUpDownReorder.Value;
            updated.StandardCost = (int)numericUpDownStandard.Value;
            updated.ListPrice = (int)numericUpDownPrice.Value;
            updated.SellStartDate=dateTimePickerSell.Value;
            db.SaveChanges();
            refreshData();
            id= -1;
        }
    }
}
