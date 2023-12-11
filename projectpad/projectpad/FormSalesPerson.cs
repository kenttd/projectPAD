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
    public partial class FormSalesPerson : Form
    {
        AdventureWorks2019Entities db = new AdventureWorks2019Entities();
        public FormSalesPerson()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormSalesPerson_Load(object sender, EventArgs e)
        {
            var terr = from SalesTerritory st in db.SalesTerritories
                       select new
                       {
                           id = st.TerritoryID,
                           name = st.Name,
                       };
            for (int i = 0; i < terr.ToList().Count; i++)
            {
                comboBoxTerritory.Items.Add(terr.ToList().ElementAt(i).name);
            }
        }
    }
}
