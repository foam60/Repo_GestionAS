using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DemoGestionAS_BO;


namespace DemoGestionAs_DAL
{
    public class Utilisateur_DAO
    {
        public static Utilisateur_DAO unUtilisateur_DAO;

        // Accesseur en lecture, renvoi une instance
        public static Utilisateur_DAO GetUnUtilisateurDAO()
        {
            if (unUtilisateur_DAO == null)
            {
                unUtilisateur_DAO = new Utilisateur_DAO();
            }

            return unUtilisateur_DAO;
        }
        public static List<Utilisateur> GetUtilisateurs()
        {
            int id;
            string login;
            Utilisateur unUtilisateur;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBdd.GetConnexionBD().GetSqlConnexion();

            // Création d'une liste vide d'objets Utilisateurs
            List<Utilisateur> lesUtilisateurs = new List<Utilisateur>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT * FROM UTILISATEUR";

            SqlDataReader monReader = cmd.ExecuteReader();

            // Remplissage de la liste
            while (monReader.Read())
            {
                int droit = 0;
                string mdp = string.Empty;

                id = Int32.Parse(monReader["id_utilisateur"].ToString());

                if (monReader["id_utilisateur"] == DBNull.Value)
                {
                    login = default(string);
                }
                else
                {
                    login = monReader["login_utilisateur"].ToString();
                    mdp = monReader["mdp_utilisateur"].ToString();
                    droit = Int32.Parse(monReader["droit_utilisateur"].ToString());
                }
                unUtilisateur = new Utilisateur(id, login, mdp, droit);
                lesUtilisateurs.Add(unUtilisateur);
            }
            // Fermeture de la connexion
            maConnexion.Close();

            return lesUtilisateurs;
        }
    }
}
