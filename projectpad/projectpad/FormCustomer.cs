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
    public partial class FormCustomer : Form
    {
        AdventureWorks2019Entities db = new AdventureWorks2019Entities();
        public FormCustomer()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            var terr = from SalesTerritory st in db.SalesTerritories
                       select new
                       {
                           territory = st.Name,
                           id = st.TerritoryID,
                       };
            for (int i = 0; i < terr.ToList().Count; i++)
            {
                comboBoxTerritory.Items.Add(terr.ToList().ElementAt(i).territory);
            }
        }
    }
}
