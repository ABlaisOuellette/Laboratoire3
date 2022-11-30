using Microsoft.UI.Xaml.Controls;
using Microsoft.VisualBasic;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Projets
    {
        //LES ATTRIBUTS DE MA CLASSE  

        string numero;
        string debut;
        double budget;
        string description;
        string matricule; 
        
        //CONSTRUCTEURS
        public Projets()
        {

        }

        public Projets(string numero, string debut, double budget, string description, string matEmploye)
        {
            this.numero = numero;
            this.debut = debut;
            this.budget = budget;
            this.description = description;
            this.matricule = matEmploye;
        }

        //ACCESSEURS

        public string Numero 
        { 
          get => numero;
          set => numero = value;
        }
        public string Debut 
        {
         get => debut;
         set => debut = value;
        }
        public double Budget 
        { 
         get => budget;
         set => budget = value;
        }
        public string Description 
        {
         get => description;
         set => description = value;
        }
        public string MatEmploye 
        { 
          get => matricule;
          set => matricule = value;
        }

        //METHODE TOSTRING()

        public override string ToString()
        {
            return numero + " " + debut + " " + budget + " " + description + " " + matricule;
        }



    }
}
