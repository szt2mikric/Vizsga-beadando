using Microsoft.Win32;
using OtthonBerles.DBLayer;
using System;
using System.IO;
using System.Windows;

namespace OtthonBerles.Views
{
    public partial class AddPropertyWindow : Window
    {
        public AddPropertyWindow()
        {
            InitializeComponent();
        }

        private byte[] imageData;

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

        private void addPropertypageButton_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(propertyEmailTextBox.Text))
            {
                MessageBox.Show("Az e-mail nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(propertyCityTextBox.Text))
            {
                MessageBox.Show("A város nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(propertyTypeTextBox.Text))
            {
                MessageBox.Show("A típus nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(selectedImagePathTextBox.Text))
            {
                MessageBox.Show("A kép nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(propertyOthersTextBox.Text))
            {
                MessageBox.Show("Az egyéb információk nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(propertyPossibilityOfMovingTextBox.Text))
            {
                MessageBox.Show("A költözési lehetőség nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (!int.TryParse(propertyRoomNumberTextBox.Text, out int roomNumber))
            {
                MessageBox.Show("A szobaszám érvénytelen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            if (!int.TryParse(propertyPriceTextBox.Text, out int price))
            {
                MessageBox.Show("Az ár érvénytelen!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            bool isFurnished = yesRadioButton.IsChecked == true;

            bool answer = PropertyDA.AddProperty(
                propertyCityTextBox.Text,
                propertyEmailTextBox.Text,
                propertyTypeTextBox.Text,
                roomNumber,
                price,
                isFurnished,
                propertyPossibilityOfMovingTextBox.Text,
                propertyOthersTextBox.Text,
                imageData 
             );

           
            if (answer)
            {
                MessageBox.Show("Hirdetés sikeresen hozzáadva.", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                Close(); 
            }
            else
            {
                MessageBox.Show("Hiba lépett fel.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
