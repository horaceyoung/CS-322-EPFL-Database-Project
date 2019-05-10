using System;
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
        List<String> Verification = new List<String>();
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "Country", "Score" };
            DataContext = this;

        }   
    
        

        private void InsertTableOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (InsertTableOption.SelectedItem.ToString()){
                case "Listing":
                    newSelection(sender, e);
                    InsertListing.Visibility = Visibility.Visible;
                    break;
                case "Host":
                    newSelection(sender, e);
                    InsertHost.Visibility = Visibility.Visible;
                    break;
                case "Country":
                    newSelection(sender, e);
                    InsertCountry.Visibility = Visibility.Visible;
                    break;
                case "Score":
                    newSelection(sender, e);
                    InsertScore.Visibility = Visibility.Visible;
                    break;

            }
        

        }
        private void newSelection(object sender, SelectionChangedEventArgs e)
        {
            InsertListing.Visibility = Visibility.Collapsed;
            InsertHost.Visibility = Visibility.Collapsed;
            InsertCountry.Visibility = Visibility.Collapsed;
            InsertScore.Visibility = Visibility.Collapsed;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckedHandle(sender as CheckBox);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UncheckedHandle(sender as CheckBox);
        }

        void CheckedHandle(CheckBox checkBox)
        {
            //// Use IsChecked.
            //bool flag = checkBox.IsChecked.Value;

            //// Assign Window Title.
            //this.Title = "IsChecked = " + flag.ToString();

            Verification.Add(checkBox.Content.ToString());

        }
        void UncheckedHandle(CheckBox checkBox)
        {
            //// Use IsChecked.
            //bool flag = checkBox.IsChecked.Value;

            //// Assign Window Title.
            //this.Title = "IsChecked = " + flag.ToString();

            Verification.Remove(checkBox.Content.ToString());

        }

    }
}