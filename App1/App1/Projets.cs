using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
    internal class Projets
    {
        //LES ATTRIBUTS DE MA CLASSE
        //DATE DÉBUT PROJET FORMAT DATE ???

        string numero;        
        DatePicker debut;
        int budget;
        string description;
        string matEmploye; 
        
        public Projets()
        {

        }

        public Projets(string numero, DatePicker debut, int budget, string description, string matEmploye)
        {
            this.numero = numero;
            this.debut = debut;
            this.budget = budget;
            this.description = description;
            this.matEmploye = matEmploye;
        }

        public string Numero 
        { 
          get => numero;
          set => numero = value;
        }
        public DatePicker Debut 
        {
         get => debut;
         set => debut = value;
        }
        public int Budget 
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
          get => matEmploye;
          set => matEmploye = value;
        }

        //METHODE TOSTRING()

        public override string ToString()
        {
            return numero + " " + debut + " " + budget + " " + description + " " + matEmploye;
        }



    }
}
