using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoGestionAS_BLL;
using MetroSet_UI;


namespace DemoGestionAS
{
    public partial class ModuleConnexion : MetroFramework.Forms.MetroForm
    {
        public ModuleConnexion()
        {
            InitializeComponent();
            this.Text = "Connexion";

            // Récupération de chaîne de connexion à la BD à l'ouverture du formulaire
            GestionUtilisateurs.SetchaineConnexion(ConfigurationManager.ConnectionStrings["Utilisateur"]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string returnValue = GestionConnexion.ConnexionForm(this.textBox1.Text, this.textBox2.Text);
            if (String.IsNullOrEmpty(returnValue))
            {
                MessageBox.Show("Vos identifiants sont incorrectes !");
                return;
            }
            if (returnValue == "M")
            {
                MenuAdmin fr1 = new MenuAdmin();
                fr1.Show();
                this.Hide();
            }
            else if (returnValue == "F")
            {
                MenuCompta fr2 = new MenuCompta();
                fr2.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.PasswordChar == '*')
            {
                this.textBox2.PasswordChar = '\0';
            }
            else if (textBox2.PasswordChar == '\0')
            {
                this.textBox2.PasswordChar = '*';
            }
        }

        private void ModuleConnexion_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
