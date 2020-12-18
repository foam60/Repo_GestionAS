using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoGestionAs_DAL;
using DemoGestionAS_BO;

namespace DemoGestionAS
{
    public partial class ModuleAjout_Edit : MetroFramework.Forms.MetroForm
    {
        public ModuleAjout_Edit()
        {
            InitializeComponent();
        }

        private void ModuleAjout_Edit_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel6_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel7_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel10_Click(object sender, EventArgs e)
        {

        }

        private void metroCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            int archive = 2;
            DateTime date = DateTime.Now;

            

            if (metroTextBoxEmail.Text != "" && metroTextBoxPrenom.Text != "")
            {
                int idUser = 1;
                int tel, telparent, classe, id = 0;
                string returnValue;
                int.TryParse(metroTextBoxTel.Text, out tel);
                int.TryParse(metroTextBoxTelparent.Text, out telparent);
                int.TryParse(metroTextBoxClasse.Text, out classe);

                returnValue = Adherent_DAO.adherentEdit(metroTextBoxPrenom.Text, metroTextBoxNom.Text, metroTextBoxEmail.Text, metroDateTimeDdn.Text, tel,
                                                          telparent, metroTextBoxMdp.Text, metroTextBoxLogin.Text, false, "H", archive, date, idUser, classe, id);
                MessageBox.Show("Données inserer correctement.");
            }
            else
            {
                MessageBox.Show("Problèmes lors de l'insertion des données.");
            }

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            int archive = 2;
            DateTime date = DateTime.Now;
            

            if (metroTextBoxEmail.Text != "" && metroTextBoxPrenom.Text != "")
            {
                int idUser = 1;
                int tel, telparent, classe = 0;
                string returnValue;
                int.TryParse(metroTextBoxTel.Text, out tel);
                int.TryParse(metroTextBoxTelparent.Text, out telparent);
                int.TryParse(metroTextBoxClasse.Text, out classe);

                returnValue = Adherent_DAO.adherentAjout(metroTextBoxPrenom.Text, metroTextBoxNom.Text, metroTextBoxEmail.Text, metroDateTimeDdn.Text, tel,
                                                          telparent, metroTextBoxMdp.Text, metroTextBoxLogin.Text, false, "H", archive, date, idUser, classe);
                MessageBox.Show(returnValue);
            } else
            {
                MessageBox.Show("Data NOT Inserted");
            }
        }
    }
}
