using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;
using MySql.Data.MySqlClient;

namespace App1
{
    internal class GestionBD
    {
        // Connectio A la BD
        MySqlConnection con;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=cours.cegep3r.info;Database=2130666-nathan-lafrenière;Uid=2130666;Pwd=2130666;");
        }

        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        // AFFICHER TOUT LES EMPLOYES
        public ObservableCollection<Employes> GetEmployes()
        {

            ObservableCollection<Employes> liste = new ObservableCollection<Employes>();
            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Employes(r.GetString(0),

                    r.GetString(1),
                    r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }
        // recherche PAR UN NOM
        public ObservableCollection<Employes> rechercheNom(string valeur)
        {



            ObservableCollection<Employes> liste = new ObservableCollection<Employes>();
            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            
            
            commande.CommandText = "Select * from employe where nom = @valeur";
            
            
            
            commande.Parameters.AddWithValue("@valeur", valeur);

            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Employes(r.GetString(0),

                    r.GetString(1),
                    r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }
        //recherche PAR UN PRENOM
        public ObservableCollection<Employes> recherchePrenom(string valeur)
        {



            ObservableCollection<Employes> liste = new ObservableCollection<Employes>();
            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;


            commande.CommandText = "Select * from employe where prenom = @valeur";



            commande.Parameters.AddWithValue("@valeur", valeur);

            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Employes(r.GetString(0),

                    r.GetString(1),
                    r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }

        // AJOUTER UN EMPLOYE   
        public void ajouterEmployes(Employes m)
        {
            int retour;



            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;


                commande.Parameters.AddWithValue("@matricule", m.Matricule);
                commande.Parameters.AddWithValue("@nom", m.Nom);
                commande.Parameters.AddWithValue("@prenom", m.Prenom);
                commande.CommandText = "insert into employe values(@matricule, @nom, @prenom) ";

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }



        // Ajouter un Trajet 

        public void ajouterProjet(Projets m)
        {
            int retour;



            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;


                commande.Parameters.AddWithValue("@numero", m.Numero);
                commande.Parameters.AddWithValue("@debut", m.Debut.ToString());
                commande.Parameters.AddWithValue("@budget", m.Budget);
                commande.Parameters.AddWithValue("@description", m.Description);
                commande.Parameters.AddWithValue("@employe", m.MatEmploye);
                commande.CommandText = "insert into projet values(@numero, @debut, @budget, @description, @employe) ";

                con.Open();
                commande.Prepare();
                retour = commande.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        // AFFICHER TOUT LES PROJETS
        public ObservableCollection<Projets> GetProjets()
        {

            ObservableCollection<Projets> liste = new ObservableCollection<Projets>();
            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Projets(r.GetString(0),

                    r.GetString(1),
                    r.GetInt32(2),
                    r.GetString(3),
                    r.GetString(4)));
                    
            }
            r.Close();
            con.Close();

            return liste;
        }

        //RECHERCHE PAR DATE PROJET
        public ObservableCollection<Projets> rechercheProjetDate(DatePicker valeur)
        {

            // convertir la valeur en format date

            ObservableCollection<Projets> liste = new ObservableCollection<Projets>();
            liste.Clear();
            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;


            commande.CommandText = "Select * from projet where debut = @valeur";



            commande.Parameters.AddWithValue("@valeur", valeur);

            con.Open();
            commande.Prepare();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                liste.Add(new Projets(r.GetString(0),

                    r.GetString(1),
                    r.GetInt32(2),
                    r.GetString(3),
                    r.GetString(4)));
            }
            r.Close();
            con.Close();

            return liste;
        }
    }
}
