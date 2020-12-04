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
            return Utilisateur_DAO.ConnexionReturn(username, mdp);
        }

    }
}
