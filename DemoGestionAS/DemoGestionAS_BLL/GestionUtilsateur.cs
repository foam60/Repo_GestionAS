using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DemoGestionAs_DAL;
using DemoGestionAS_BO;
using System.Collections.Generic;

namespace DemoGestionAS_BLL
{
    public class GestionUtilisateurs
    {
        private int id_selec;
        private int id_utilisateur;
        private string login_utilisateur;
        private string mdp_utilisateur;
        private int droit_utilisateur;

        public GestionUtilisateurs() { }
        public GestionUtilisateurs(int id)
        {
            this.id_utilisateur = id;
        }
        public GestionUtilisateurs(int id, string login)
        {
            this.id_utilisateur = id;
            this.login_utilisateur = login;
        }
        public GestionUtilisateurs(int id, string login, string mdp)
        {
            this.id_utilisateur = id;
            this.login_utilisateur = login;
            this.mdp_utilisateur = mdp;
        }
        public GestionUtilisateurs(int id, string login, string mdp, int droit)
        {
            this.id_utilisateur = id;
            this.login_utilisateur = login;
            this.mdp_utilisateur = mdp;
            this.droit_utilisateur = droit;
        }

        public int Id
        {
            get => this.id_utilisateur;
            set => this.id_utilisateur = value;
        }

        public string Login
        {
            get => this.login_utilisateur;
            set => this.login_utilisateur = value;
        }
        public string Mdp
        {
            get => this.mdp_utilisateur;
            set => this.mdp_utilisateur = value;
        }

        public int Droit
        {
            get => this.droit_utilisateur;
            set => this.droit_utilisateur = value;
        }

        public int Selec
        {
            get => this.id_selec;
            set => this.id_selec = value;
        }

        private static GestionUtilisateurs uneGestionUtilisateurs; // objet BLL

        // Accesseur en lecture
        public static GestionUtilisateurs GetGestionUtilisateurs()
        {
            if (uneGestionUtilisateurs == null)
            {
                uneGestionUtilisateurs = new GestionUtilisateurs();
            }

            return uneGestionUtilisateurs;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion
        // de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBdd.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Utilisateur en faisant appel à
        // la méthode GetUtilisateurs() de la DAL
        public static List<Utilisateur> GetUtilisateurs()
        {
            return Utilisateur_DAO.GetUtilisateurs();
        }
    }
}
