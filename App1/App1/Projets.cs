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

        int numero;        
        string debut;
        int budget;
        string description;
        string matEmploye;


        

        public int Numero 
        { 
          get => numero;
          set => numero = value;
        }
        public string Debut 
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
