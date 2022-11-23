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
    public sealed partial class ajoutProjet : Page
    {
        public ajoutProjet()
        {
            this.InitializeComponent();
            lvListe.ItemsSource = GestionBD.getInstance().GetEmployes();
        }

        //GÉRER LA VALIDATION DES NOUVEAUX PROJETS
        //APPELLER LA FONCTION POUR AJOUTER DANS LA TABLE PROJET
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {

            Boolean b = true;
            DatePicker datePicker = new DatePicker();

            tblDate.Text = datePicker.Date.Date.ToString("dd MM yyyy");

            //VÉRIFICATION POUR LE NUMÉRO DE PROJET
            if (tbxNumProjet.Text == "")
            {
                b = false;
                tblAlertNum.Visibility = Visibility.Visible;

            }

            //VÉRIFICATION POUR LA DATE DE DÉBUT
            if (tblDate.Text  == "")
            {
                b = false;
                tblAlertDebut.Visibility = Visibility.Visible;
            }
            

            //VÉRIFICATION POUR LE BUDGET
            if (tbxBudget.Text == "")
            {
                b = false;
                tblAlertBud.Visibility = Visibility.Visible;
            }
            

            //VÉRIFICATION POUR LA DESCRIPTION

            if (tbxDescription.Text == "")
            {
                b = false;
                tblAlertDesc.Visibility = Visibility.Visible;
            }
            

            //VÉRIFICATION POUR LE NUMEMPLOYE

            if ( lvListe.SelectedIndex == -1 )
            {
                b = false;
                tblAlertcb.Visibility = Visibility.Visible;
            }
            

            if ( b == true)
            {
                Projets p = new Projets()
                {
                    Numero = tbxNumProjet.Text,
                    Debut = datePicker,
                    Budget = Convert.ToInt32(tbxBudget.Text),
                    Description = tbxDescription.Text,
                    MatEmploye = lvListe.SelectedItem.ToString()
                };

                GestionBD.getInstance().ajouterProjet(p);
            }         

            
        }

        



    }
}
