using Google.Protobuf.WellKnownTypes;
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
    public sealed partial class RechercheEmploye : Page
    {
        public RechercheEmploye()
        {
            this.InitializeComponent();
        }

        private void choixRecherche_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string a;

            a = choixRecherche.SelectedItem as string;

            if (a == "Nom")
            {
                stackNom.Visibility = Visibility.Visible;
                stackPrenom.Visibility = Visibility.Collapsed;
            }

            if (a == "Prenom")
            {
                stackPrenom.Visibility = Visibility.Visible;
                stackNom.Visibility = Visibility.Collapsed;
            }
        }
        //prenom
        private void btRecherchePrenom_Click(object sender, RoutedEventArgs e)
        {
            Boolean valide = true;
            if (valide)
            {

                lvListe.ItemsSource = GestionBD.getInstance().recherchePrenom(tbxPrenom.Text);
            }
        }
        //nom
        private void btRechercheNom_Click(object sender, RoutedEventArgs e)
        {
            Boolean valide = true;
            if (valide)
            {

                lvListe.ItemsSource = GestionBD.getInstance().rechercheNom(tbxNom.Text);
            }
        }
    }
}
