using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoGestionAS_BLL;
using DemoGestionAs_DAL;

namespace DemoGestionAS
{
    public partial class ModuleGestionEleve : MetroFramework.Forms.MetroForm
    {
        public int idSelec;
        public ModuleGestionEleve()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
           
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Adherent_DAO.GetDataSet();
            dataGridViewGestionEleve.DataSource = ds.Tables["Adherent"].DefaultView;
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in dataGridViewGestionEleve.Rows)
            {
                int id = Convert.ToInt32(dgvr.Cells[0].Value);
            }

            var moduleAjoutEdition = new ModuleAjout_Edit();
            moduleAjoutEdition.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {

        }
    }
}
