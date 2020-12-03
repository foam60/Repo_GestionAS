using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoGestionAS_BO
{
    public class Utilisateur
    {
        private int id_utilisateur;
        private string login_utilisateur;
        private string mdp_utilisateur;
        private int droit_utilisateur;

        public Utilisateur(int id, string login,string mdp, int droit)
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
    }
}
