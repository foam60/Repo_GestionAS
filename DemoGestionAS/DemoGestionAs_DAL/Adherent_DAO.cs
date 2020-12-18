using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoGestionAS_BO;

namespace DemoGestionAs_DAL
{
    public class Adherent_DAO
    {
        public static Adherent_DAO unAdherent_DAO;

        // Accesseur en lecture, renvoi une instance
        public static Adherent_DAO GetUnAdherentDAO()
        {
            if (unAdherent_DAO == null)
            {
                unAdherent_DAO = new Adherent_DAO();
            }

            return unAdherent_DAO;
        }

        public static string adherentAjout(string prenom, string nom, string email, string ddn, int tel,
                                int telparent, string mdp, string login, bool autoprelev, string genre, int archive, DateTime date, int idUser, int classe)
        {
            string query = "INSERT INTO ADHERENT(Nom_adherent, Prenom_adherent, Ddn_adherent, Numtel_adherent, " +
                           "Numparent_adherent, Email_adherent, Autprelev_adherent, Sexe_adherent, " +
                           "Login_adherent, Mdp_adherent, Datemaj_adherent, Archive_adherent, Id_utilisateur, Id_classe) values(@nom, @prenom, @ddn, @tel, @telparent, @email, @autoprelev, @sexe, @login, @mdp, @datemaj, @archive, @iduser, @classe)";
            string returnValue = "";
            string connectionString = ConfigurationManager.ConnectionStrings["Utilisateur"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, con))
                {
                    sqlcmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = prenom;
                    sqlcmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = nom;
                    sqlcmd.Parameters.Add("@ddn", SqlDbType.VarChar).Value = ddn;
                    sqlcmd.Parameters.Add("@tel", SqlDbType.BigInt).Value = tel;
                    sqlcmd.Parameters.Add("@telparent", SqlDbType.BigInt).Value = telparent;
                    sqlcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    sqlcmd.Parameters.Add("@autoprelev", SqlDbType.Bit).Value = autoprelev;
                    sqlcmd.Parameters.Add("@sexe", SqlDbType.VarChar).Value = genre;
                    sqlcmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    sqlcmd.Parameters.Add("@mdp", SqlDbType.VarChar).Value = mdp;
                    sqlcmd.Parameters.Add("@datemaj", SqlDbType.VarChar).Value = date;
                    sqlcmd.Parameters.Add("@archive", SqlDbType.Int).Value = archive;
                    sqlcmd.Parameters.Add("@iduser", SqlDbType.Int).Value = idUser;
                    sqlcmd.Parameters.Add("@classe", SqlDbType.Int).Value = classe;
                    con.Open();
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            return returnValue;
        }

        public static string adherentEdit(string prenom, string nom, string email, string ddn, int tel,
                                int telparent, string mdp, string login, bool autoprelev, string genre, int archive, DateTime date, int idUser, int classe,int id)
        {
            string query = "UPDATE ADHERENT set Nom_adherent=@nom, Prenom_adherent=@prenom, Ddn_adherent=@ddn, Numtel_adherent=@tel, " +
                           "Numparent_adherent=@telparent, Email_adherent=@email, Autprelev_adherent=@autoprelev, Sexe_adherent=@sexe, " +
                           "Login_adherent=@login, Mdp_adherent=@mdp, Datemaj_adherent=@datemaj, Archive_adherent=@archive, Id_utilisateur=@iduser, Id_classe=@classe WHERE ID=@id)";
            string returnValue = "";
            string connectionString = ConfigurationManager.ConnectionStrings["Utilisateur"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, con))
                {
                    sqlcmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                    sqlcmd.Parameters.Add("@prenom", SqlDbType.VarChar).Value = prenom;
                    sqlcmd.Parameters.Add("@nom", SqlDbType.VarChar).Value = nom;
                    sqlcmd.Parameters.Add("@ddn", SqlDbType.VarChar).Value = ddn;
                    sqlcmd.Parameters.Add("@tel", SqlDbType.BigInt).Value = tel;
                    sqlcmd.Parameters.Add("@telparent", SqlDbType.BigInt).Value = telparent;
                    sqlcmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    sqlcmd.Parameters.Add("@autoprelev", SqlDbType.Bit).Value = autoprelev;
                    sqlcmd.Parameters.Add("@sexe", SqlDbType.VarChar).Value = genre;
                    sqlcmd.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    sqlcmd.Parameters.Add("@mdp", SqlDbType.VarChar).Value = mdp;
                    sqlcmd.Parameters.Add("@datemaj", SqlDbType.VarChar).Value = date;
                    sqlcmd.Parameters.Add("@archive", SqlDbType.Int).Value = archive;
                    sqlcmd.Parameters.Add("@iduser", SqlDbType.Int).Value = idUser;
                    sqlcmd.Parameters.Add("@classe", SqlDbType.Int).Value = classe;
                    con.Open();
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            return returnValue;
        }
        public static DataSet GetDataSet()
        {
            
            string query = "SELECT * FROM dbo.ADHERENT";
            string connectionString = ConfigurationManager.ConnectionStrings["Utilisateur"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    DataSet ds1 = new DataSet();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(ds1, "Adherent");
                    }
                    return ds1;
                }
            }
        }

        public static List<Adherent> GetAdherents()
        {
            int id;
            string login;
            Adherent unAdherent;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBdd.GetConnexionBD().GetSqlConnexion();

            // Création d'une liste vide d'objets Utilisateurs
            List<Adherent> lesAdherents = new List<Adherent>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT * FROM dbo.ADHERENT";

            SqlDataReader monReader = cmd.ExecuteReader();

            // Remplissage de la liste
            while (monReader.Read())
            {
                string prenom = string.Empty;
                string nom = string.Empty;
                string ddn = string.Empty;
                int tel = 0;
                int telParent = 0;
                bool autoPrelev = false;
                string mail = string.Empty;
                string mdp = string.Empty;
                int archive = 0;
                string genre = string.Empty;

                id = Int32.Parse(monReader["Id_adherent"].ToString());

                if (monReader["Id_adherent"] == DBNull.Value)
                {
                    login = default(string);
                }
                else
                {
                    prenom = monReader["Nom_adherent"].ToString();
                    nom = monReader["Prenom_adherent"].ToString();
                    mail = monReader["Ddn_adherent"].ToString();
                    ddn = monReader["Email_adherent"].ToString();
                    tel = Int32.Parse(monReader["Numtel_adherent"].ToString());
                    telParent = Int32.Parse(monReader["Numparent_adherent"].ToString());
                    genre = monReader["Sexe_adherent"].ToString();
                    login = monReader["Login_adherent"].ToString();
                    mdp = monReader["Mdp_adherent"].ToString();
                    archive = Int32.Parse(monReader["Archive_adherent"].ToString());
                }
                unAdherent = new Adherent(id,prenom, nom, mail, ddn, tel, telParent, mdp, login, autoPrelev, genre, archive);
                lesAdherents.Add(unAdherent);
            }
            // Fermeture de la connexion
            maConnexion.Close();

            return lesAdherents;
        }
    }
}
