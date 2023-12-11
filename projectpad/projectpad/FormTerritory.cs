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
    public partial class FormTerritory : Form
    {
        AdventureWorks2019Entities db = new AdventureWorks2019Entities();
        public FormTerritory()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTerritory_Load(object sender, EventArgs e)
        {
            //var group = from SalesTerritory st in db.SalesTerritories
            //            select new
            //            {
            //                region = st.Group
            //            };

            //for (int i = 0; i < group.ToList().Count; i++)
            //{
            //    comboBoxTerritory.Items.Add(group.ToList().ElementAt(i).region);
            //}
            comboBoxTerritory.Items.Add("North America");
            comboBoxTerritory.Items.Add("Europe");
            comboBoxTerritory.Items.Add("Pacific");
        }
    }
}
