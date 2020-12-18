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
    class GestionAdherent
    {
        private int id_adherent;
        private string prenom_adherent;
        private string nom_adherent;
        private string email_adherent;
        private string ddn_adherent;
        private int tel_adherent;
        private int telparent_adherent;
        private string mdp_adherent;
        private string login_adherent;
        private bool autoprelev_adherent;
        private string genre_adherent;
        private int archive_adherent;
        private DateTime dateMaj;

        public GestionAdherent() { }
        public GestionAdherent(int id)
        {
            this.id_adherent = id;
        }
        public GestionAdherent(int id, string prenom_adherent, string nom_adherent, 
                                string email_adherent, string ddn_adherent, int tel_adherent,
                                int telparent_adherent, string mdp_adherent, string login_adherent,
                                bool autoprelev_adherent, string genre_adherent, int archive_adherent)
        {
            this.id_adherent = id;
            this.prenom_adherent = prenom_adherent;
            this.nom_adherent = nom_adherent;
            this.email_adherent = email_adherent;
            this.ddn_adherent = ddn_adherent;
            this.tel_adherent = tel_adherent;
            this.telparent_adherent = telparent_adherent;
            this.login_adherent = login_adherent;
            this.mdp_adherent = mdp_adherent;
            this.autoprelev_adherent = autoprelev_adherent;
            this.genre_adherent = genre_adherent;
            this.archive_adherent = archive_adherent;

        }
        public int Id
        {
            get => this.id_adherent;
            set => this.id_adherent = value;
        }

        public string Prenom
        {
            get => this.prenom_adherent;
            set => this.prenom_adherent = value;
        }
        public string Nom
        {
            get => this.nom_adherent;
            set => this.nom_adherent = value;
        }

        public string Email
        {
            get => this.email_adherent;
            set => this.email_adherent = value;
        }

        public string Ddn
        {
            get => this.ddn_adherent;
            set => this.ddn_adherent = value;
        }

        public int Tel
        {
            get => this.tel_adherent;
            set => this.tel_adherent = value;
        }

        public int TelParent
        {
            get => this.telparent_adherent;
            set => this.telparent_adherent = value;
        }

        public int Archive
        {
            get => this.archive_adherent;
            set => this.archive_adherent = value;
        }

        public bool AutoPrelev
        {
            get => this.autoprelev_adherent;
            set => this.autoprelev_adherent = value;
        }

        public string Mdp
        {
            get => this.mdp_adherent;
            set => this.mdp_adherent = value;
        }

        public string Login
        {
            get => this.login_adherent;
            set => this.login_adherent = value;
        }

        private static GestionAdherent uneGestionAdherent; // objet BLL

        // Accesseur en lecture
        public static GestionAdherent GetGestionAdherent()
        {
            if (uneGestionAdherent == null)
            {
                uneGestionAdherent = new GestionAdherent();
            }

            return uneGestionAdherent;
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
        public static List<Adherent> GetAdherent()
        {
            return Adherent_DAO.GetAdherents();
        }

    }
}
