// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.AppBroadcasting;

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
            lvListe.ItemsSource = GestionBD.getInstance().GetMatricule();
        }
                

        //G�RER LA VALIDATION DES NOUVEAUX PROJETS
        //APPELLER LA FONCTION POUR AJOUTER DANS LA TABLE PROJET
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {

            Boolean b = true;
                       

            //V�RIFICATION POUR LE NUM�RO DE PROJET
            if (tbxNumProjet.Text == "")
            {
                b = false;
                tblAlertNum.Visibility = Visibility.Visible;

            }

            //V�RIFICATION POUR LA DATE DE D�BUT
            if (tblDate.SelectedDate  == null)
            {
                b = false;
                tblAlertDebut.Visibility = Visibility.Visible;
            }

            tblDate.ToString();                      

            

            //VALIDER SI LE STRING PEUT �TRE CONVERTIE EN INT 

            try
            {
                double valeur = nbBudget.Value;

                if (valeur < 10000 && valeur > 100000) 
                {
                    b = false;
                    tblAlertBud.Text = "Vous devez entrer une valeur entre 10000 et 100000";
                    tblAlertBud.Visibility = Visibility.Visible;
                }
            }
            catch(FormatException ex) 
            {
                b= false;
                tblAlertBud.Text = "Vous devez entrer un nombre!";
                tblAlertBud.Visibility = Visibility.Visible;
            }
          

            //V�RIFICATION POUR LA DESCRIPTION

            if (tbxDescription.Text == "")
            {
                b = false;
                tblAlertDesc.Visibility = Visibility.Visible;
            }
            

            //V�RIFICATION POUR LE NUMEMPLOYE

            if (lvListe.SelectedIndex < 0)
            {
                b = false;
                tblAlertcb.Visibility = Visibility.Visible;
            }
               
            //QUAND TOUS LES VALIDATIONS SONT V�RIFI�ES LES TBLALERT SONT D�SACTIV�S ET L'OBJET PROJET EST CR��          

            if ( b == true)
            {
                tblAlertNum.Visibility = Visibility.Collapsed;
                tblAlertDebut.Visibility = Visibility.Collapsed;
                tblAlertBud.Visibility = Visibility.Collapsed;
                tblAlertDesc.Visibility = Visibility.Collapsed;
                tblAlertcb.Visibility = Visibility.Collapsed;

                

                
               

                Projets p = new Projets();
                {
                    p.Numero = tbxNumProjet.Text;
                    p.Debut = tblDate.Date.Date.ToString("yyyy-MM-d");
                    p.Budget = nbBudget.Value;
                    p.Description = tbxDescription.Text;
                    p.MatEmploye = lvListe.SelectedItem.ToString();
                };


                GestionBD.getInstance().ajouterProjet(p);

                tblValidation.Text = "Enregistrement r�ussi!";
                tblValidation.Visibility = Visibility.Visible;
            }         

            
        }

        
    }
}
