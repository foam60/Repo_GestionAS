using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoGestionAs_DAL

{// Classe de gestion de la connexion à la BD
    public class ConnexionBdd
    {
        private SqlConnection maConnexion;
        private static ConnexionBdd uneConnexionBdd; // instance d'une connexion
        private string chaineConnexion; // chaîne de connexion à la BD
                                        
        // Accesseur en lecture de la chaîne de connexion
        public string GetchaineConnexion()
        {
            return chaineConnexion;
        }
        // Accesseur en écriture de la chaîne de connexion
        public void SetchaineConnexion(string ch)
        {
            chaineConnexion = ch;
        }
        // Accesseur en lecture, renvoi une instance de connexion
        public static ConnexionBdd GetConnexionBD()
        {
            if (uneConnexionBdd == null)
            {
                uneConnexionBdd = new ConnexionBdd();
            }
            return uneConnexionBdd;
        }
        // Constructeur privé
        private ConnexionBdd()
        {
        }
        public SqlConnection GetSqlConnexion()
        {
            if (maConnexion == null)
            {
                maConnexion = new SqlConnection();
            }
            maConnexion.ConnectionString = chaineConnexion;
            // Si la connexion est fermée, on l’ouvre
            if (maConnexion.State == System.Data.ConnectionState.Closed)
            {
                maConnexion.Open();
            }
            return maConnexion;
        }
        public void CloseConnexion()
        {
            // Si la connexion est ouverte, on la ferme
            if (this.maConnexion != null && this.maConnexion.State !=
            System.Data.ConnectionState.Closed)
            {
                this.maConnexion.Close();
            }
        }
    }
}
