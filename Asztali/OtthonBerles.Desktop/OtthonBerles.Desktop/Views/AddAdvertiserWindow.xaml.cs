using OtthonBerles.DBLayer;
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
using System.Windows.Shapes;

namespace OtthonBerles.Views
{

    public partial class AddAdvertiserWindow : Window
    {
        public AddAdvertiserWindow()
        {
            InitializeComponent();
        }

        private void addAdvertiserpageButton_Click(object sender, RoutedEventArgs e)
        {
           
            if(advertiserFullNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("A Név nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (advertiserEmailTextBox.Text.Length == 0)
            {
                MessageBox.Show("Az email cím nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (advertiserPasswordTextBox.Text.Length == 0)
            {
                MessageBox.Show("A jelszó nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (advertiserCompanyNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("A Cég név nem lehet üres!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            bool answer = AdvertisersDA.AddAdvertiser(advertiserFullNameTextBox.Text, advertiserEmailTextBox.Text, advertiserPasswordTextBox.Text, advertiserCompanyNameTextBox.Text);
            if (answer)
            {
                MessageBox.Show("Hírdető sikeresen hozzáadva.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Hiba lépett fel.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
