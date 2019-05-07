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
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "City", "Country", "Room Type", "Property Type" };

            DataContext = this;
        }

        private void InsertTableOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(InsertTableOption.SelectedItem.ToString()){
                case "Listing":
                    InsertListing.Visibility = Visibility.Visible;
                    break;
                    

            }


        }
    }
}