// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinRT;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class affichage : Page
    {
        public affichage()
        {
            this.InitializeComponent();
            //LIER LES DONNÉES DE LA TABLE PROJET
            lvProjet.ItemsSource = GestionBD.getInstance().GetProjetsNoms();            
        }

        //EFFECTUER UNE RECHERCHE AVEC LA DATE
        private void btnRecherche_Click(object sender, RoutedEventArgs e)
        {
            Boolean validation;
            DateTime dt;

            validation = DateTime.TryParseExact(tbxRecherche.Text, "yyyy-MM-dd",CultureInfo.InvariantCulture,DateTimeStyles.None, out dt);
          
            
            try
            {
                if(validation == false)
                {                    
                    tblAlertDate.Text = "Vous devez entrer une date";
                    tblAlertDate.Visibility = Visibility.Visible;
                }
                else
                {
                    tblAlertDate.Visibility = Visibility.Collapsed;
                    lvProjet.ItemsSource = GestionBD.getInstance().rechercheProjetDate(tbxRecherche.Text);
                }
                                    

            }
            catch(FormatException ex)
            {
                
                tblAlertDate.Text = "Vous devez entrer une date valide";
                tblAlertDate.Visibility = Visibility.Visible;
            }
            
        }
    }
}
