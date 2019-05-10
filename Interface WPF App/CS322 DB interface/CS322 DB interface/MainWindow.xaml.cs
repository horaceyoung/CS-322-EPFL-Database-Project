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
using MySql.Data.MySqlClient;


namespace Proj
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] table_names { get; set; }
<<<<<<< HEAD
        List<String> Verification = new List<String>();
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "Country", "Score" };
=======
        public string[] VerificationName { get; set; }
        public MySqlConnection airbnbConnection;

        public MainWindow()
        {
            InitializeComponent();
            DatabaseConnect();
            table_names = new string[] { "Listing", "Host", "City", "Country", "Room Type", "Property Type" };
            VerificationName = new string[] { "telephone", "email"};
>>>>>>> 39b09d16839ddb5adbf41d6980c5a309d908bb77
            DataContext = this;

        }   
    
        

        private void Bttn_srch_Click(object sender, EventArgs e){
            
            String textB_srch_value =  TextB_srch.Text;
            // ..........................................
        }

        private void Bttn_dlet_Click(object sender, EventArgs e){

            String textB_dlet_value =  TextB_dlet.Text;
            // ..........................................
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

<<<<<<< HEAD
=======
        private void DatabaseConnect()
        {

            // try catch for test only can delt
            try{
                string connectionString = "Server=localhost;DATABASE=airbnb;UID==root;PASSWORD=yh19981118";
                airbnbConnection = new MySqlConnection(connectionString);
                airbnbConnection.Open();
                MessageBox.Show("DB connection seccessful","Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }

        }

        private void DatabaseClose()
        {
            airbnbConnection.Close();
        }
>>>>>>> 39b09d16839ddb5adbf41d6980c5a309d908bb77
    }
}