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
            if (comboBoxType.SelectedIndex!=-1)
            {
                if (comboBoxType.SelectedIndex==0)
                {
                    SpecialOffer inserted = new SpecialOffer()
                    {
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
    }
}
