using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Employes
    {
        string matricule;
        string nom;
        string prenom;



        public Employes()
        {

        }


        public Employes(string matricule, string nom, string prenom)
        {
            this.matricule = matricule;
            this.nom = nom;
            this.prenom = prenom;
        }

        public Employes(string n, string p)
        {
            this.nom = n;
            this.prenom = p;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public override string ToString()
        {
            return matricule + " " + nom + " " + prenom;
        
        
        }

        public  string GetMat()
        {
            return matricule;


        }
    }
}
