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
using DemoGestionAS_BO;

namespace DemoGestionAS
{
    public partial class ModuleConnexion : Form
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
            string query = "SELECT Droit_utilisateur from UTILISATEUR WHERE Login_utilisateur = @username and Mdp_utilisateur = @password";
            string returnValue = "";
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Demo_GestionAS;Integrated Security=True"))
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, con))
                {
                    sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = textBox1.Text;
                    sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = textBox2.Text;
                    con.Open();
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            //EDIT to avoid NRE 
            if (String.IsNullOrEmpty(returnValue))
            {
                MessageBox.Show("Incorrect username or password");
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
    }
}
