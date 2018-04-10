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
using Bierbank.ViewModel;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bierbank.View
{
    /// <summary>
    /// Interaction logic for BierToevoegen.xaml
    /// </summary>
    public partial class BierToevoegen : Page
    {
        public BierToevoegen()
        {
            InitializeComponent();
        }

        private void KnopToevoegen_Click(object sender, RoutedEventArgs e)
        {
            double percentage;

            //waarden opvragen
            string naam = textBoxNaam.Text;
            string soort = textBoxSoort.Text;
            string percentageInvoer = textBoxPercentage.Text;
            string brouwerij = textBoxBrouwerij.Text;
            string image = textBoxImage.Text;

            if(double.TryParse(percentageInvoer, out percentage))
            {
                BierToevoegenModel.ToevoegenBier(naam, soort, percentage, brouwerij, image);
                textBoxNaam.Text = "";
                textBoxSoort.Text = "";
                textBoxPercentage.Text = "";
                textBoxBrouwerij.Text = "";
                textBoxImage.Text = "";
                Popup.IsOpen = true;
            }
            else
            {
                textBoxPercentage.Text = "Error, gelieve een correct percentage in te voeren!";
                textBoxPercentage.Foreground = Brushes.Red;
            }
        }

        private void KnopClosePopup_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = false;
        }
    }
}
