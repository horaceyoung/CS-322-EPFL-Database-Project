﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Proj
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] table_names { get; set; }
        public string[] VerificationName { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "City", "Country", "Room Type", "Property Type" };
            VerificationName = new string[] { "telephone", "email"};
            DataContext = this;
        }

        private void InsertTableOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(InsertTableOption.SelectedItem.ToString()){
                case "Listing":
                    InsertListing.Visibility = Visibility.Visible;
                    InsertHost.Visibility = Visibility.Collapsed;
                    break;
                case "Host":
                    InsertHost.Visibility = Visibility.Visible;
                    InsertListing.Visibility = Visibility.Collapsed;
                    //HostVerificationInsert.Visibility = Visibility.Visible;
                    //                            < Grid x: Name = "HostVerificationInsert" HorizontalAlignment = "Left" Margin = "80,10,0,0" Visibility = "Collapsed" >

                    //                    < TextBlock Text = "Host Verification" />

                    //                     < StackPanel >


                    //                         < ComboBox Name = "cb" ItemsSource = "{Binding .}" Margin = "0,20,0,0" >

                    //                                  < ComboBox.ItemTemplate >

                    //                                      < DataTemplate >

                    //                                          < StackPanel Orientation = "Horizontal" >

                    //                                               < CheckBox Name = "HostVerification"  IsChecked = "{Binding IsChecked}" Checked = "CheckBox_Checked" Unchecked = "CheckBox_Unchecked" ></ CheckBox >

                    //                                                      < TextBlock Text = "{Binding VerificationName}" ></ TextBlock >

                    //                                                   </ StackPanel >

                    //                                               </ DataTemplate >

                    //                                           </ ComboBox.ItemTemplate >

                    //                                       </ ComboBox >

                    //                                   </ StackPanel >

                    //                               </ Grid >
                    break;
                    

            }


        }
    }
}