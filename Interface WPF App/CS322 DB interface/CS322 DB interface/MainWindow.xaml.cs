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
using System.Globalization;

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
        public string[] table_numberSelection { get; set; }
        public string[] table_BedroomNumber { get; set; }
        public string[] table_RoomType { get; set; }
        public string[] table_accommodates { get; set; }
        public List<Listing> listingList = new List<Listing>();
        public List<Host> hostList = new List<Host>();

        public MySqlConnection airbnbConnection;

        List<String> Verification = new List<String>();
        public MainWindow()
        {
            InitializeComponent();

            table_names = new string[] { "Listing", "Host", "Country", "Score" };
            table_BedroomNumber = new string[] { "1", "2", "3", "4", "5" };
            table_queries = new string[] { "Select cheapest listing on certain date in certain neighborhood", "Average price of houses with certain number of bedrooms, with certain room type", "Cheapest house available at certain date, with certain number of accommodates" };
            table_regionChoice = new string[] { "El Raval", "El Poblenou", "L'Antiga Esquerra de l'Eixample", "El Born", "Prenzlauer Berg"};
            table_RoomType = new string[] { "Entire home/apt", "Private room", "Shared room" };
            table_numberSelection = new string[] {"0","1","2","3","4","5","6"};
            table_accommodates = new string[] { "0", "1", "2", "3", "4", "5", "6" };
            DataContext = this;

            DisplayListing.ItemsSource = listingList;
            

            DatabaseConnect();
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
            switch (selectQuery.SelectedItem)
            {
                case "Select cheapest listing on certain date in certain neighborhood":
                    newQuerySelection(sender, e);
                    firstQuery.Visibility = Visibility.Visible;
                    secondQuery.Visibility = Visibility.Collapsed;
                    thirdQuery.Visibility = Visibility.Collapsed;
                    break;
                case "Average price of houses with certain number of bedrooms, with certain room type":
                    newQuerySelection(sender, e);
                    firstQuery.Visibility = Visibility.Collapsed;
                    secondQuery.Visibility = Visibility.Visible;
                    thirdQuery.Visibility = Visibility.Collapsed;

                    break;
                case "Cheapest house available at certain date, with certain number of accommodates":
                    newQuerySelection(sender, e);
                    firstQuery.Visibility = Visibility.Collapsed;
                    secondQuery.Visibility = Visibility.Collapsed;
                    thirdQuery.Visibility = Visibility.Visible;
             
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
                    string hostURL = hostUrlInput.Text;
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
                    foreach (CheckBox box in verificationCheckBox)
                    {
                        if (box.IsChecked == true)
                        {
                            verificationCheck += "'" + box.Content.ToString() + "', ";
                        }
                    }
                    verificationCheck += "]";



                    string insertHostCommandString = "INSERT INTO Host_table(host_id, host_url, host_name, host_since, host_about, " +
                        "host_response_time, host_response_rate, host_thumbnail_url, host_picture_url, host_neighborhood, host_verifications)" +
                        "Values(" + hostHostID + ", " +
                        "'" + hostURL + "', " +
                        "'" + hostName + "', " +
                        "'" + hostSince + "', " +
                        "'" + hostAbout + "', " +
                        "'" + responseTime + "', " +
                        responseRate + ", " +
                        "'" + hostThumbnailURL + "', " +
                        "'" + hostPictureURL + "', " +
                        hostNeighborhood + ", " +
                        "'" + verificationCheck + "')";
                    MySqlCommand InsertHostCommand = new MySqlCommand(insertHostCommandString, airbnbConnection);
                    rows = InsertHostCommand.ExecuteNonQuery();
                    MessageBox.Show("success" + " number of rows affected: " + rows.ToString());
                    break;
                case "Country":
                    string getMaxCountryString = "SELECT MAX(country_id) from country";
                    MySqlCommand getMaxCountryCommand = new MySqlCommand(getMaxCountryString, airbnbConnection);
                    string maxCountry = getMaxCountryCommand.ExecuteScalar().ToString();
                    string targetCountryNo = (System.Convert.ToInt32(maxCountry) + 1).ToString();
                    string countryName = countryInput.Text;

                    string insertCountryCommandString = "INSERT INTO country(country_id, country_name) " +
                        "VALUES(" + targetCountryNo + ", " + "'" + countryName + "'" + ")";
                    MySqlCommand insertCountryCommand = new MySqlCommand(insertCountryCommandString, airbnbConnection);
                    rows = insertCountryCommand.ExecuteNonQuery();
                    MessageBox.Show("success" + " number of rows affected: " + rows.ToString());
                    break;
                case "Score":
                    string scoreListingID = ScoreListingID.Text;
                    string ratingScore = RatingScore.Text;
                    string accuracyScore = AccuracyScore.Text;
                    string cleanlinessScore = CleanlinessScore.Text;
                    string checkInScore = CheckInScore.Text;
                    string commScore = CommScore.Text;
                    string locScore = LocScore.Text;
                    string valueScore = ValScore.Text;
                    string insertScoreCommandString = "INSERT INTO score(listing_id, review_scores_rating, review_scores_accuracy, review_scores_clean, " +
                        "review_scores_checkin, review_scores_communication, review_scores_location, review_scores_value)" +
                        "VALUES(" +
                        scoreListingID + ", " +
                        ratingScore + ", " +
                        accuracyScore + ", " +
                        cleanlinessScore + ", " +
                        checkInScore + ", " +
                        commScore + ", " +
                        locScore + ", " +
                        valueScore +
                        ")";
                    MySqlCommand insertScoreCommand = new MySqlCommand(insertScoreCommandString, airbnbConnection);
                    rows = insertScoreCommand.ExecuteNonQuery();
                    MessageBox.Show("success" + " number of rows affected: " + rows.ToString());
                    break;
                default:
                    break;
            }
        }

        private void AUD(string sql_stmt, string mode)
        {
            MySqlCommand cmd = new MySqlCommand(sql_stmt, airbnbConnection);
            MySqlDataReader rd = cmd.ExecuteReader();
            switch (mode)
            {
                case "Listing":
                    while (rd.Read())
                    {
                        int listing_id = (System.Convert.ToInt32(rd["listing_id"]));
                        string listing_url = (rd["listing_url"].ToString());
                        string listing_name = (rd["listing_name"].ToString());
                        string summary = (rd["summary"].ToString());
                        string space = (rd["space"].ToString());
                        string listing_description = (rd["listing_description"].ToString());
                        string neighborhood_overview = (rd["neighborhood_overview"].ToString());
                        string notes = (rd["notes"].ToString());
                        string transit = (rd["transit"].ToString());
                        string access = (rd["access"].ToString());
                        string interaction = (rd["interaction"].ToString());
                        string house_rules = (rd["house_rules"].ToString());
                        string picture_url = (rd["picture_url"].ToString());
                        int host_id = (System.Convert.ToInt32(rd["host_id"]));
                        string neighborhood = (rd["neighborhood"].ToString());
                        double latitude = (System.Convert.ToDouble(rd["latitude"].ToString()));
                        double longitude = (System.Convert.ToDouble(rd["longitude"].ToString()));
                        int minimum_nights = (System.Convert.ToInt32(rd["minimum_nights"]));
                        int maximum_nights = (System.Convert.ToInt32(rd["maximum_nights"]));
                        Listing listing = new Listing(listing_id, listing_url, listing_name, summary, space, listing_description, neighborhood_overview,
                            notes, transit, access, interaction, house_rules, picture_url, host_id, neighborhood, latitude, longitude, minimum_nights, maximum_nights);
                        listingList.Add(listing);
                    }
                    rd.Close();
                    break;
                case "Host":
                    while (rd.Read())
                    {
                        Host host = new Host();
                        host.host_id = (System.Convert.ToInt32(rd["host_id"]));
                        host.host_url = (rd["host_url"].ToString());
                        host.host_name = (rd["host_name"].ToString());
                        host.host_since = (rd["host_since"].ToString());
                        host.host_about = (rd["host_about"].ToString());
                        host.host_response_time = (rd["host_response_time"].ToString());
                        host.host_response_rate = (rd["host_response_rate"].ToString());
                        host.host_thumbnail_url = (rd["host_thumbnail_url"].ToString());
                        host.host_picture_url = (rd["host_picture_url"].ToString());
                        host.host_neighborhood = (System.Convert.ToInt32(rd["host_neighborhood"].ToString()));
                        host.host_verifications = (rd["host_verifications"].ToString());
                        hostList.Add(host);
                    }
                    rd.Close();
                    break;
                    
                default:
                    break;
            }
        }

        private void BttnSrchClick(object sender, RoutedEventArgs e)
        {

            string tableName = ComboB_srch.Text;
            string textB_srch_value = TextB_srch.Text;

            switch (tableName)
            {
                case "Listing":
                    string sql = "SELECT * FROM Listing L WHERE L.listing_id LIKE '%" + textB_srch_value + "%' OR "
                                + "L.listing_url LIKE '%" + textB_srch_value + "%' OR "
                                + "L.listing_name LIKE '%" + textB_srch_value + "%' OR "
                                + "L.summary LIKE '%" + textB_srch_value + "%' OR "
                                + "L.space LIKE '%" + textB_srch_value + "%' OR "
                                + "L.listing_description LIKE '%" + textB_srch_value + "%' OR "
                                + "L.neighborhood_overview LIKE '%" + textB_srch_value + "%' OR "
                                + "L.notes LIKE '%" + textB_srch_value + "%' OR "
                                + "L.transit LIKE '%" + textB_srch_value + "%' OR "
                                + "L.access LIKE '%" + textB_srch_value + "%' OR "
                                + "L.interaction LIKE '%" + textB_srch_value + "%' OR "
                                + "L.house_rules LIKE '%" + textB_srch_value + "%' OR "
                                + "L.picture_url LIKE '%" + textB_srch_value + "%' OR "
                                + "L.host_id LIKE '%" + textB_srch_value + "%' OR "
                                + "L.neighborhood LIKE '%" + textB_srch_value + "%' OR "
                                + "L.latitude LIKE '%" + textB_srch_value + "%' OR "
                                + "L.longitude LIKE '%" + textB_srch_value + "%' OR "
                                + "L.minimum_nights LIKE '%" + textB_srch_value + "%' OR "
                                + "L.maximum_nights LIKE '%" + textB_srch_value + "%'";
                    this.AUD(sql, "Listing");









                    break;
                case "Host":
                    sql = "SELECT * FROM Host_table H WHERE H.host_id LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_url LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_name LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_since LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_about LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_response_time LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_response_rate LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_thumbnail_url LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_picture_url LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_neighborhood LIKE '%" + textB_srch_value + "%' OR "
                                        + "H.host_verifications LIKE '%" + textB_srch_value + "%'";
                    this.AUD(sql, "Host");
                    break;
                default:
                    break;

            }


        }

        private void moreListingInfo_Click(object sender, RoutedEventArgs e)
        {
            Listing lst = DisplayListing.SelectedItem as Listing;

            MessageBox.Show("Listing ID:" + Convert.ToString(lst.listing_id)+"\nListing url:"+lst.listing_url + "\nListing name:" + lst.listing_name + "\nListing Summary:" + lst.summary + "\nListing Description:" + lst.listing_description + "\nListing Neighbourhood Overview:" + lst.neighborhood_overview
                +"\nListing Notes:" + lst.notes + "\nListing Transit Info:" + lst.transit + "\nListing Access:" + lst.access + "\nListing Interaction Info:" + lst.interaction + "\nListing House Rule:" + lst.house_rules + "\nListing Picture:" + lst.picture_url + "\nListing Picture:" + lst.picture_url + "\nListing Host ID:" + Convert.ToString(lst.host_id)
                + "\nListing Neighbourhood:" + lst.neighborhood + "\nListing Latitude:" + Convert.ToString(lst.latitude) + "\nListing Longtitude:" + Convert.ToString(lst.longitude) + "\nListing Min. Nights:" + Convert.ToString(lst.minimum_nights) + "\nListing Max. Nights:" + Convert.ToString(lst.maximum_nights));


        //    string             public int listing_id;
        //public string listing_url;
        //public string listing_name;
        //public string summary;
        //public string space;
        //public string listing_description;
        //public string neighborhood_overview;
        //public string notes;
        //public string transit;
        //public string access;
        //public string interaction;
        //public string house_rules;
        //public string picture_url;
        //public int host_id;
        //public string neighborhood;
        //public double latitude;
        //public double longitude;
        //public int minimum_nights;
        //public int maximum_nights;
    }


        private void querySubmitBtn_clicked(object sender, RoutedEventArgs e) {

        
        }

        private void Bttn_query_Click(object sender, RoutedEventArgs e)
        {

            string tableName = selectQuery.Text;
            MySqlCommand cmd;
            DisplayQueryResult.Visibility = Visibility.Visible;
            switch (tableName)
            {
                case "Average price of houses with certain number of bedrooms, with certain room type":
                    string sql;
                    string query_bed = bedroomNumber.Text;
                    string query_type = RoomType.Text;
                    sql = "select avg(P.price) from room_type R, House_Details H, Price P where H.listing_id=P.listing_id and H.room_type=R.room_type_id and R.room_type_name='"
                    + query_type + "' and " + "H.bedrooms=" + query_bed;
                    cmd = new MySqlCommand(sql, airbnbConnection);
                    MessageBox.Show(sql);
                    DataTable dt2 = new DataTable();
                    dt2.Load(cmd.ExecuteReader());
                    DisplayQueryResult.DataContext = dt2;
                    break;

                case "Cheapest house available at certain date, with certain number of accommodates":
                    string sql1;
                    string query_ds = DateStart.Text;
                    string result_ds = DateConvert(query_ds);
                    string query_de = DateEnd.Text;
                    string result_de = DateConvert(query_de);
                    string query_ac = accommodates.Text;
                    sql1 = "select H.listing_id from calendar C, House_Details H, Price P where H.listing_id = C.listing_id and (C.calendar_date between '"
                    + result_ds + "' and '" + result_de + "') and C.availability = 't' and H.accommodates="
                           + query_ac + " and P.listing_id=H.listing_id order by P.price asc limit 1;";
                    cmd = new MySqlCommand(sql1, airbnbConnection);
                    MessageBox.Show(sql1);
                    DataTable dt3 = new DataTable();
                    dt3.Load(cmd.ExecuteReader());
                    DisplayQueryResult.DataContext = dt3;
                    break;

                case "Select cheapest listing on certain date in certain neighborhood":
                    string query_date =firstQueryDate.Text;
                    string result = DateConvert(query_date);
                    string query_neigh = firstQueryNeigh.Text;
                    sql = "select L.listing_id, C.price from calendar C, listing L, neighborhood N where C.calendar_date='"
                    + result + "' and C.availability='t' and L.neighborhood=N.neighborhood_id and L.listing_id=C.listing_id and N.neighborhood_name='"
                    + query_neigh + "' order by price asc limit 1";
                    cmd = new MySqlCommand(sql, airbnbConnection);
                    MessageBox.Show(sql);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    DisplayQueryResult.DataContext = dt;
                    break;
            }

        }


        private string DateConvert(string date)
        {
            List<String> values = date.Split('/').ToList();
            string result = values[2] + "-" + values[1] + "-" + values[0];
            return result;
        }


        private void Bttn_dlet_Click(object sender, RoutedEventArgs e)
        {

            string tableName = ComboB_dlet.Text;
            string textB_dlet_value = TextB_dlet.Text;

            switch (tableName)
            {
                case "Listing":
                    string sql = "DELETE FROM Listing WHERE Listing.listing_id = " + textB_dlet_value;
                    MySqlCommand cmd = new MySqlCommand(sql, airbnbConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case "Host":
                    sql = "DELETE FROM Host_table WHERE Host_table.host_id = " + textB_dlet_value;
                    cmd = new MySqlCommand(sql, airbnbConnection);
                    MessageBox.Show(sql);
                    cmd.ExecuteNonQuery();
                    break;
                case "Country":
                    sql = "DELETE FROM Country WHERE Country.country_id = " + textB_dlet_value;
                    cmd = new MySqlCommand(sql, airbnbConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case "Score":
                    sql = "DELETE FROM Score WHERE Score.score_id = " + textB_dlet_value;
                    cmd = new MySqlCommand(sql, airbnbConnection);
                    cmd.ExecuteNonQuery();
                    break;
            }

        }

        private void TabablzControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }



        public class Listing
        {
            public int listing_id;
            public string listing_url;
            public string listing_name;
            public string summary;
            public string space;
            public string listing_description;
            public string neighborhood_overview;
            public string notes;
            public string transit;
            public string access;
            public string interaction;
            public string house_rules;
            public string picture_url;
            public int host_id;
            public string neighborhood;
            public double latitude;
            public double longitude;
            public int minimum_nights;
            public int maximum_nights;

            public Listing() { }

            public Listing(int listing_id,
            string listing_url, string listing_name, string summary, string space, string listing_description, string neighborhood_overview,
            string notes, string transit, string access, string interaction, string house_rules, string picture_url, int host_id, string neighborhood,
            double latitude, double longitude, int minimum_nights, int maximum_nights)
            {
                this.listing_id = listing_id;
                this.listing_url = listing_url;
                this.listing_name = listing_name;
                this.summary = summary;
                this.space = space;
                this.listing_description = listing_description;
                this.neighborhood_overview = neighborhood_overview;
                this.notes = notes;
                this.transit = transit;
                this.access = access;
                this.interaction = interaction;
                this.house_rules = house_rules;
                this.picture_url = picture_url;
                this.host_id = host_id;
                this.neighborhood = neighborhood;
                this.latitude = latitude;
                this.longitude = longitude;
                this.minimum_nights = minimum_nights;
                this.maximum_nights = maximum_nights;
            }
        }

        public class Host
        {
            public int host_id;
            public string host_url;
            public string host_name;
            public string host_since;
            public string host_about;
            public string host_response_time;
            public string host_response_rate;
            public string host_thumbnail_url;
            public string host_picture_url;
            public int host_neighborhood;
            public string host_verifications;

            public Host() { }
        }
    }
}

