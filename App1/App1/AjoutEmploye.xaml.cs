using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutEmploye : Page
    {
        public AjoutEmploye()
        {
            this.InitializeComponent();
        }

        private void btAjout_Click(object sender, RoutedEventArgs e)
        {
            bool valide = true;

            Employes employes = new Employes();
            {
               

                if (tbxMatricule.Text == "")
                {
                    
                    valide = false;
                    MatE.Visibility = Visibility.Visible;
                }

                if (tbxMatricule.Text.Length > 7)
                {

                    valide = false;
                    MatE.Text = "Le matricule doit avoir un maximum de 7 lettre et chiffre";
                    MatE.Visibility = Visibility.Visible;
                }


                if (tbxNom.Text == "")
                {
                    valide = false;
                    nomE.Visibility = Visibility.Visible;
                }

                if (tbxNom.Text.Length > 30)
                {

                    valide = false;
                    tbxNom.Text = "Le nom doit avoir un maximum de 30 lettre";
                    tbxNom.Visibility = Visibility.Visible;
                }

                if (tbxPrenom.Text == "")
                {
                    valide = false;
                    prenomE.Visibility = Visibility.Visible;
                }

                if (tbxPrenom.Text.Length > 20)
                {

                    valide = false;
                    prenomE.Text = "Le Prenom doit avoir un maximum de 20 lettre";
                    prenomE.Visibility = Visibility.Visible;
                }

                employes.Matricule = tbxMatricule.Text;
                employes.Nom = tbxNom.Text;
                employes.Prenom = tbxPrenom.Text;

            };
            if (valide)
            {
                GestionBD.getInstance().ajouterEmployes(employes);
                fin.Text = "enregistrement réussi";
            }
        }
    }
}
