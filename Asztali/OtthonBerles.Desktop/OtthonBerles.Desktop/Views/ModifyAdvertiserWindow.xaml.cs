using Microsoft.Win32;
using OtthonBerles.DBLayer;
using OtthonBerles.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace OtthonBerles.Views
{
    public partial class ModifyAdvertiserWindow : Window
    {

        public bool ModificationSuccessful { get; private set; }

        private Advertiser advertiser;
        private DataGrid dataGrid;

        public ModifyAdvertiserWindow(Advertiser advertiser, DataGrid dataGrid)
        {
            InitializeComponent();
            this.advertiser = advertiser;
            this.dataGrid = dataGrid;


            advertiserFullNameTextBox.Text = advertiser.FullName;
            advertiserEmailTextBox.Text = advertiser.Email;
            advertiserPasswordTextBox.Text = advertiser.Password;
            advertiserCompanyNameTextBox.Text = advertiser.CompanyName;
        }
        private void modifyAdvertiserpageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(advertiserFullNameTextBox.Text) ||
                    string.IsNullOrWhiteSpace(advertiserEmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(advertiserPasswordTextBox.Text) ||
                    string.IsNullOrWhiteSpace(advertiserCompanyNameTextBox.Text))
                {
                    MessageBox.Show("Töltse ki az összes mezőt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

 
                if (GetAdvertiserID() == 0)
                {
                    MessageBox.Show("Válasszon hírdetőt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

            
                bool success = AdvertisersDA.UpdateAdvertiser(
                    GetAdvertiserID(),
                    advertiserFullNameTextBox.Text,
                    advertiserEmailTextBox.Text,
                    advertiserPasswordTextBox.Text,
                    advertiserCompanyNameTextBox.Text);

                if (success)
                {
                    MessageBox.Show("Hírdető sikeresen módósítva.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (dataGrid != null)
                    {
                        dataGrid.ItemsSource = AdvertisersDA.RetrieveAllAdvertisers();
                    }

                    ModificationSuccessful = true; 
                    Close(); 
                }
                else
                {
                    MessageBox.Show("Módosítás sikertelen.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba lépett fel: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private int GetAdvertiserID()
        {
            int advertiserID = 0; 

            if (dataGrid != null && dataGrid.SelectedItem is Advertiser selectedAdvertiser)
            {
                advertiserID = selectedAdvertiser.Id;
            }

            return advertiserID;
        }
    }
}