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
        int id = -1;
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
            comboBoxType.Items.Add("No Discount");
            comboBoxType.Items.Add("Volume Discount");
            comboBoxCategory.Items.Add("No Discount");
            comboBoxCategory.Items.Add("Reseller");
            comboBoxCategory.Items.Add("Customer");
            numericUpDownMin.Enabled = false;
            numericUpDownMax.Enabled = false;
            numericUpDownDiscount.Enabled = false;
            
            comboBoxCategory.Enabled = false;
            richTextBoxDesc.Enabled=false;
            buttonDelete.Enabled = false;
            buttonUpdate.Enabled=false;
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

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            Guid guid = Guid.NewGuid();
            int a = (int)dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value + 1;
            if (comboBoxType.SelectedIndex!=-1)
            {
                if (comboBoxType.SelectedIndex==0)
                {
                    SpecialOffer inserted = new SpecialOffer()
                    {
                        //SpecialOfferID = 20,
                        SpecialOfferID = db.SpecialOffers.OrderByDescending(h => h.SpecialOfferID).FirstOrDefault().SpecialOfferID + 1,
                        Type = comboBoxType.Items[0].ToString(),
                        StartDate=dateTimePickerStart.Value,
                        EndDate=dateTimePickerEnd.Value,
                        Description = comboBoxType.Items[0].ToString(),
                        DiscountPct = 0,
                        Category = comboBoxType.Items[0].ToString(),
                        MinQty = 0,
                        MaxQty = 0,
                        ModifiedDate = DateTime.Now,
                        rowguid = guid,
                    };
                    db.SpecialOffers.Add(inserted);
                    db.SaveChanges();
                    refreshData();
                }
                else
                {
                    
                    SpecialOffer inserted = new SpecialOffer()
                    {
                        //SpecialOfferID = a,
                        SpecialOfferID = db.SpecialOffers.OrderByDescending(h => h.SpecialOfferID).FirstOrDefault().SpecialOfferID + 1,
                        Type = comboBoxType.Items[comboBoxType.SelectedIndex].ToString(),
                        StartDate = dateTimePickerStart.Value,
                        EndDate = dateTimePickerEnd.Value,
                        Description = richTextBoxDesc.Text,
                        DiscountPct = (Decimal)(numericUpDownDiscount.Value/100),
                        Category = comboBoxCategory.Items[comboBoxCategory.SelectedIndex].ToString(),
                        MinQty = (int)numericUpDownMin.Value,
                        MaxQty = (int)numericUpDownMax.Value,
                        ModifiedDate = DateTime.Now,
                        rowguid = guid,
                    };
                    db.SpecialOffers.Add(inserted);
                    db.SaveChanges();
                    refreshData();
                }
            }
            else
            {

            }
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxType.SelectedIndex!=-1 && comboBoxType.SelectedIndex != 0)
            {
                numericUpDownMin.Enabled = true;
                numericUpDownMax.Enabled = true;
                numericUpDownDiscount.Enabled = true;
                
                comboBoxCategory.Enabled = true;
                richTextBoxDesc.Enabled = true;
            }
            else
            {
                numericUpDownMin.Enabled = false;
                numericUpDownMax.Enabled = false;
                numericUpDownDiscount.Enabled = false;
                
                comboBoxCategory.Enabled = false;
                richTextBoxDesc.Enabled = false;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxType.SelectedIndex = -1;
            comboBoxCategory.SelectedIndex = -1;
            richTextBoxDesc.Text = "Description";
            numericUpDownDiscount.Value = 0;
            numericUpDownMin.Value = 0;
            numericUpDownMax.Value = 0;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SpecialOffer deletedsp = db.SpecialOffers.FirstOrDefault(h => h.SpecialOfferID == id);
            db.SpecialOffers.Remove(deletedsp);
            db.SaveChanges();
            refreshData();
            id = -1;

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            buttonUpdate.Enabled = true;
            buttonDelete.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            var updated = db.SpecialOffers.FirstOrDefault(h => h.SpecialOfferID == id);
            updated.Type = comboBoxType.Items[comboBoxType.SelectedIndex].ToString();
            updated.StartDate = dateTimePickerStart.Value;
            updated.EndDate = dateTimePickerEnd.Value;
            if (updated.Type!="No Discount")
            {
                updated.MinQty = (int)numericUpDownMin.Value;
                updated.MaxQty = (int)numericUpDownMax.Value;
                updated.DiscountPct = (Decimal)(numericUpDownDiscount.Value / 100);
                updated.ModifiedDate=DateTime.Now;
                updated.Description=richTextBoxDesc.Text;
                updated.Category = comboBoxCategory.Items[comboBoxCategory.SelectedIndex].ToString();
            }
            db.SaveChanges();
            refreshData();
        }
    }
}
