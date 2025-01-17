using Microsoft.Win32;
using OtthonBerles.DBLayer;
using OtthonBerles.Models;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OtthonBerles.Views
{
    public partial class ModifyPropertyWindow : Window
    {
  
        public bool ModificationSuccessful { get; private set; }

        private Property property;
        private DataGrid dataGrid;
        private byte[] imageData;

       
        public ModifyPropertyWindow(Property property, DataGrid dataGrid)
        {
            InitializeComponent();
            this.property = property;
            this.dataGrid = dataGrid;

            propertyCityTextBox.Text = property.City;
            propertyEmailTextBox.Text = property.Email;
            propertyTypeTextBox.Text = property.Type_;
            propertyRoomNumberTextBox.Text = property.RoomNumber.ToString();
            propertyPriceTextBox.Text = property.Price.ToString();
            propertyOthersTextBox.Text = property.Other;
            propertyPossibilityOfMovingTextBox.Text = property.PossibilityOfMoving;
            yesRadioButton.IsChecked = property.IsFurnished;
            noRadioButton.IsChecked = !property.IsFurnished;

        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
           
                selectedImagePathTextBox.Text = openFileDialog.FileName;

                imageData = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void modifyPropertypageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
              
                if (string.IsNullOrWhiteSpace(propertyCityTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyEmailTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyTypeTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyRoomNumberTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyPriceTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyOthersTextBox.Text) ||
                    string.IsNullOrWhiteSpace(propertyPossibilityOfMovingTextBox.Text))
                {
                    MessageBox.Show("Töltse ki az összes mezőt.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

              
                if (GetPropertyID() == 0)
                {
                    MessageBox.Show("Válasszon egy ingatlant.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

             
                bool isFurnished = yesRadioButton.IsChecked == true;

             
                bool success = PropertyDA.UpdateProperty(
                    GetPropertyID(),
                    propertyCityTextBox.Text,
                    propertyEmailTextBox.Text,
                    propertyTypeTextBox.Text,
                    int.Parse(propertyRoomNumberTextBox.Text),
                    int.Parse(propertyPriceTextBox.Text),
                    isFurnished,
                    propertyPossibilityOfMovingTextBox.Text,
                    propertyOthersTextBox.Text,
                    imageData);

                if (success)
                {
                    MessageBox.Show("Ingatlan sikeresen módosítva.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            
                    if (dataGrid != null)
                    {
                        dataGrid.ItemsSource = PropertyDA.RetrieveAllProperties();
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

        private int GetPropertyID()
        {
            int propertyID = 0;

            if (dataGrid != null && dataGrid.SelectedItem is Property selectedProperty)
            {
                propertyID = selectedProperty.Id;
            }

            return propertyID;
        }

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            if (!IsNumeric(e.Text))
            {
                e.Handled = true;
            }
        }

        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
    }
}
