using System;
using System.Collections.Generic;
using System.Data;
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

        public string[] table_queries { get; set; }
        public string[] table_regionChoice { get; set; }

        public MySqlConnection airbnbConnection;

        List<String> Verification = new List<String>();
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "Country", "Score" };

            table_queries = new string[] { "Select cheapest listing on certain date", "Average price of house with certain number of certain rooms"};
            table_regionChoice = new string[] { "El Raval", "El Poblenou", "L'Antiga Esquerra de l'Eixample", "El Born" };
            DataContext = this;
        }   
    
        

        private void Bttn_srch_Click(object sender, EventArgs e)
        {

            String textB_srch_value = TextB_srch.Text;
            // ..........................................
        }

        private void Bttn_dlet_Click(object sender, EventArgs e)
        {

            String textB_dlet_value = TextB_dlet.Text;
            // ..........................................
        }

        private void QuerySelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (selectQuery.SelectedIndex) {
                case 1:
                    newQuerySelection(sender,e);
                    firstQuery.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void newQuerySelection(object sender, SelectionChangedEventArgs e)
        {
            firstQuery.Visibility = Visibility.Collapsed;
            //InsertHost.Visibility = Visibility.Collapsed;
            //InsertCountry.Visibility = Visibility.Collapsed;
        }

        private void InsertTableOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (InsertTableOption.SelectedItem.ToString())
            {
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



        private void DatabaseConnect()
        {
                string connectionstring = "SERVER=localhost;DATABASE=airbnb;UID=root;PASSWORD=yh19981118";
                airbnbConnection = new MySqlConnection(connectionstring);
                airbnbConnection.Open();
        }

        private void DatabaseClose()
        {
            airbnbConnection.Close();
        }

        public void InsertTable(object sender, RoutedEventArgs e)
        {
            string tableName;
            tableName = InsertTableOption.Text;
            switch (tableName)
            {
                case "Listing":
                    string listingID = listingIDInput.Text;
                    string listingURL = listingUrlInput.Text;
                    string listingName = listingNameInput.Text;
                    string summary = summaryInput.Text;
                    string space = spaceInput.Text;
                    string description = descriptionInput.Text;
                    string neighborhoodOverview = neighDesInput.Text;
                    string notes = notesInput.Text;
                    string transitInfo = transitInput.Text;
                    string accessInfo = accessInput.Text;
                    string interactionInfo = interactionInput.Text;
                    string houseRule = ruleInput.Text;
                    string pictureURL = picInput.Text;
                    string hostID = listingHostIDInput.Text;
                    string neighborhood = neighRegionInput.Text;
                    string latitude = latitudeInput.Text;
                    string longitude = longitudeInput.Text;
                    string minStay = minStayInput.Text;
                    string maxStay = maxStayInput.Text;

                    string insertListingCommandString = "INSERT INTO Listing(listing_id, listing_url, listing_name, summary, space, " +
                        "listing_description, neighborhood_overview, notes, transit, access, interaction, house_rules, picture_url, " +
                        "host_id, neighborhood, latitude, longitude, minimum_nights, maximum_nights)" +
                        "Values(" + listingID + ", " +
                        "'" + listingURL + "', " +
                        "'" + listingName + "', " +
                        "'" + summary + "', " +
                        "'" + space + "', " +
                        "'" + description + "', " +
                        "'" + neighborhoodOverview + "', " +
                        "'" + notes + "', " +
                        "'" + transitInfo + "', " +
                        "'" + accessInfo + "', " +
                        "'" + interactionInfo + "', " +
                        "'" + houseRule + "', " +
                        "'" + pictureURL + "', " +
                        hostID + ", " +
                        "'" + neighborhood + "', " +
                        latitude + ", " +
                        longitude + ", " +
                        minStay + ", " +
                        maxStay + ")";

                        MySqlCommand insertCommand = new MySqlCommand(insertListingCommandString, airbnbConnection);
                        int rows = insertCommand.ExecuteNonQuery();
                        MessageBox.Show("success" + " number of rows affected: " + rows.ToString());
                        break;
                case "Host":
                    string hostHostID = hostHostIDInput.Text;
                    string hostName = hostNameInput.Text;
                    string hostSince = sinceInput.Text;
                    string hostAbout = aboutInput.Text;
                    string responseTime = responseTimeInput.Text;
                    string responseRate = responseRateInput.Text;
                    string hostThumbnailURL = thumbnailInput.Text;
                    string hostPictureURL = hostPicInput.Text;
                    string hostNeighborhood = hostNeighReigionInput.Text;

                    List<CheckBox> verificationCheckBox = new List<CheckBox>();
                    verificationCheckBox.Add(Email);
                    verificationCheckBox.Add(Phone);
                    verificationCheckBox.Add(Reviews);
                    verificationCheckBox.Add(Jumio);
                    verificationCheckBox.Add(Offline_gov_id);
                    verificationCheckBox.Add(Gov_id);
                    verificationCheckBox.Add(Facebook);
                    verificationCheckBox.Add(EmManual_offline);
                    verificationCheckBox.Add(Work_email);
                    verificationCheckBox.Add(Selfie);
                    verificationCheckBox.Add(Identity_manual);
                    string verificationCheck = "[";
                    foreach(CheckBox box in verificationCheckBox)
                    {
                        if (box.IsChecked == true)
                        {
                            verificationCheck += "'" + box.Content.ToString() + "'";
                        }
                    }
                    verificationCheck += "]";



                    string insertHostCommandString = "INSERT INTO Host(host_url, host_name, host_since, host_about, " +
                        "host_response_time, host_response_rate, host_thumbnail_url, host_picture_url, host_neighborhood, host_verifications)" +
                        "Values(" + hostHostID + ", " +
                        "'" + hostName + "', " +
                        "'" + hostSince + "', " +
                        "'" + hostAbout + "', " +
                        "'" + responseTime + "', " +
                        "'" + responseRate + "', " +
                        "'" + hostThumbnailURL + "', " +
                        hostNeighborhood + ", " +
                        "'" + verificationCheck + "')";
                    MessageBox.Show(insertHostCommandString);
                    break;
                default:
                    break;
            }
        }

        private void AUD(String sql_stmt, int state)
        {
            String msg = "";
            MySqlCommand cmd = airbnbConnection.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;

            switch (state)
            {
                case 0:
                    msg = "Keyword searched successfully";
                    cmd.Parameters.Add("");
                    break;
                case 1:
                    msg = "Row deleted seccessfully";
                    break;

            }
            try
            {
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show(msg);
                    //this.updateDataGrid();
                }
            }
            catch (Exception ex) { }
        }

        private void Bttn_srch_Click(object sender, RoutedEventArgs e)
        {

            string tableName = ComboB_srch.Text;
            string textB_srch_value = TextB_srch.Text;

            switch (tableName)
            {
                case "Listing":
                    String sql = "SELECT * FROM Listing L WHERE L.id LIKE " + textB_srch_value
                                + "L.listing_url LIKE " + textB_srch_value
                                + "L.name LIKE " + textB_srch_value
                                + "L.summary LIKE " + textB_srch_value
                                + "L.space LIKE " + textB_srch_value
                                + "L.description LIKE " + textB_srch_value
                                + "L.neighbourhood_overview LIKE " + textB_srch_value
                                + "L.notes LIKE " + textB_srch_value
                                + "L.transit LIEK " + textB_srch_value
                                + "L.access LIKE " + textB_srch_value
                                + "L.interaction LIEK " + textB_srch_value
                                + "L.house_rules LIKE " + textB_srch_value
                                + "L.picture_url LIKE " + textB_srch_value
                                + "L.host_id LIKE " + textB_srch_value
                                + "L.neighbourhood LIKE " + textB_srch_value
                                + "L.latitude LIKE " + textB_srch_value
                                + "L.longitude LIKE " + textB_srch_value
                                + "L.minimum_nights LIKE " + textB_srch_value
                                + "L.maximum_nights LIKE " + textB_srch_value;
                    this.AUD(sql, 0);
                    Bttn_srch.IsEnabled = false;
                    Bttn_dlet.IsEnabled = true;
                    break;
                case "Host":
                    break;
                default:
                    break;

            }


        }
        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}

