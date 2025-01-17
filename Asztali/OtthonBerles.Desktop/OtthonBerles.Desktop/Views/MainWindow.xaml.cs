using OtthonBerles.DBLayer;
using OtthonBerles.Helper;
using OtthonBerles.Models;
using OtthonBerles.Views;
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

namespace OtthonBerles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string userEmail;
        private readonly string userPassword;

        public MainWindow(string userEmail, string userPassword)
        {
            InitializeComponent();


            this.userEmail = userEmail;
            this.userPassword = userPassword;

            UpdateUIForUserType();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void UpdateUIForUserType()
        {

            bool isAdmin = userEmail == "admin" && userPassword == "admin";


            if (isAdmin)
            {

                tabControl.SelectedItem = Felhasznalok;
                Felhasznalok.Visibility = Visibility.Visible;
                Hirdetok.Visibility = Visibility.Visible;
                Ingatlanok.Visibility = Visibility.Visible;
            }
            else
            {

                tabControl.SelectedItem = Ingatlanok;
                Hirdetok.Visibility = Visibility.Collapsed; 
                Ingatlanok.Visibility = Visibility.Visible; 
                Felhasznalok.Visibility = Visibility.Collapsed;
            }
        }

        private void showCustomersButton_Click(object sender, RoutedEventArgs e)
        {
            customersDataGrid.ItemsSource = CustomersDA.RetrieveAllCustomers();
        }

        private void showAdvertisersButton_Click(object sender, RoutedEventArgs e)
        {
            advertisersDataGrid.ItemsSource = AdvertisersDA.RetrieveAllAdvertisers();
        }

        private void showPropertiesButton_Click(object sender, RoutedEventArgs e)
        {
            propertiesDataGrid.ItemsSource = PropertyDA.RetrieveAllProperties();
        }


        private void searchButton_Click(object sender, RoutedEventArgs e)
        {

            string searchText = emailSearchTextBox.Text.Trim();

            List<Property> filteredProperties = PropertyDA.RetrieveAllProperties().Where(p => p.Email.Contains(searchText)).ToList();

            propertiesDataGrid.ItemsSource = filteredProperties;
        }



        //private void addCustomerButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Window addCustomerWindow = new AddCustomerWindow();
        //    addCustomerWindow.Owner = this;
        //    addCustomerWindow.ShowDialog();
        //    customersDataGrid.Items.Refresh();
        //}

        //private void removeCustomerButton_Click(object sender, RoutedEventArgs e)
        //{


        //    Customer customer = (Customer)customersDataGrid.SelectedItem;

        //    if(customer == null)
        //    { 
        //        MessageBox.Show("Select customer first.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        //        return;
        //    }


        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("Ezzel törli a felhasználót az adatbázisból!\n");
        //    sb.Append("ID: " + customer.Id + "\n");
        //    sb.Append("FullName: " + customer.FullName +"\n");
        //    sb.Append("Email: " + customer.Email + "\n");
        //    sb.Append("Password: " + customer.Password + "\n");
        //    sb.Append("\nBiztosan folytatni szeretné?");


        //    MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

        //    if (result == MessageBoxResult.Yes)
        //    {
        //        bool deleted = CustomersDA.RemoveCustomer(customer.Id);
        //        if (deleted)
        //        {
        //            MessageBox.Show("Törlés sikeres!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

        //        }
        //        else
        //        {
        //            MessageBox.Show("Hiba lépett fel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}

        private void addAdvertiserButton_Click(object sender, RoutedEventArgs e)
        {
            Window addAdvertiserWindow = new AddAdvertiserWindow();
            addAdvertiserWindow.Owner = this;
            addAdvertiserWindow.ShowDialog();
            advertisersDataGrid.Items.Refresh();
        }

        private void removeAdvertiserButton_Click(object sender, RoutedEventArgs e)
        {
       

            Advertiser advertiser = (Advertiser)advertisersDataGrid.SelectedItem;

            if (advertiser == null)
            { 
                MessageBox.Show("Először válasszon Hírdetőt.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Ezzel a művelettel törli a kiválasztott felhasználót!\n");
            sb.Append("ID: " + advertiser.Id + "\n");
            sb.Append("TeljesNév: " + advertiser.FullName + "\n");
            sb.Append("Email: " + advertiser.Email + "\n");
            sb.Append("Jelszó: " + advertiser.Password + "\n");
            sb.Append("Cég náv: " + advertiser.CompanyName + "\n");
            sb.Append("\nBiztosan törölni szeretné?");


            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = AdvertisersDA.RemoveAdvertiser(advertiser.Id);
                if (deleted)
                {
                    MessageBox.Show("Hírdető sikeresen törölve.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    MessageBox.Show("Hiba lépett fel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void addPropertyButton_Click(object sender, RoutedEventArgs e)
        {
            Window addPropertyWindow = new AddPropertyWindow();
            addPropertyWindow.Owner = this;
            addPropertyWindow.ShowDialog();
            propertiesDataGrid.Items.Refresh();
        }

        private void removePropertyButton_Click(object sender, RoutedEventArgs e)
        {
            Property property = (Property)propertiesDataGrid.SelectedItem;

            if (property == null)
            {
                MessageBox.Show("Először válasszon ingatlant.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Ezzel a művelettel törli a kiválasztott ingatlant!\n");
            sb.Append("ID: " + property.Id + "\n");
            sb.Append("Város: " + property.City + "\n");
            sb.Append("Email: " + property.Email + "\n");
            sb.Append("Típus: " + property.Type_ + "\n");
            sb.Append("Szobák száma: " + property.RoomNumber + "\n");
            sb.Append("Ár: " + property.Price + "\n");
            sb.Append("Berendezve? " + (property.IsFurnished ? "Igen" : "Nem") + "\n");
            sb.Append("Költözési lehetőség: " + property.PossibilityOfMoving + "\n");
            sb.Append("Egyéb információk: " + property.Other + "\n");
            sb.Append("\nBiztosan törölni szeretné?");

       
            MessageBoxResult result = MessageBox.Show(sb.ToString(), "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                bool deleted = PropertyDA.RemoveProperty(property.Id);
                if (deleted)
                {
                    MessageBox.Show("Ingatlan sikeresen törölve.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                else
                {
                    MessageBox.Show("Hiba lépett fel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void modifyAdvertiserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Advertiser advertiser = (Advertiser)advertisersDataGrid.SelectedItem;


                ModifyAdvertiserWindow modifyAdvertiserWindow = new ModifyAdvertiserWindow(advertiser, advertisersDataGrid);
                modifyAdvertiserWindow.Owner = this;
                modifyAdvertiserWindow.ShowDialog();

                if (modifyAdvertiserWindow.ModificationSuccessful)
                {

                    advertisersDataGrid.ItemsSource = AdvertisersDA.RetrieveAllAdvertisers();

                }
                else
                {

                    MessageBox.Show("Failed to modify advertiser.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void modifyPropertyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Property property = (Property)propertiesDataGrid.SelectedItem;


                ModifyPropertyWindow modifyPropertyWindow = new ModifyPropertyWindow(property, propertiesDataGrid);
                modifyPropertyWindow.Owner = this;
                modifyPropertyWindow.ShowDialog();

                if (modifyPropertyWindow.ModificationSuccessful)
                {
                    propertiesDataGrid.ItemsSource = PropertyDA.RetrieveAllProperties();
                }
                else
                {

                    MessageBox.Show("Hiba lépett fel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba lépett fel: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
