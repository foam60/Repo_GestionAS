using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DemoGestionAs_DAL;
using DemoGestionAS_BO;
using System.Data;

namespace DemoGestionAS_BLL
{
    public class GestionConnexion
    {
        public static string ConnexionForm(string username, string mdp)
        {
            string query = "SELECT Droit_utilisateur from UTILISATEUR WHERE Login_utilisateur = @username and Mdp_utilisateur = @password";
            string returnValue = "";
            using (SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Demo_GestionAS;Integrated Security=True"))
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, con))
                {
                    sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = mdp;
                    con.Open();
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            return returnValue;
        }
    }
}
