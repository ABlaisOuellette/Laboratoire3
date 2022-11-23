using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace App1
{
    internal class GestionBD
    {
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
        // recherche nom
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
        //recherche Prenom
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
    }
}
