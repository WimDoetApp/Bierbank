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

namespace Bierbank.View
{
    /// <summary>
    /// Interaction logic for BierInLijstOverzicht.xaml
    /// </summary>
    public partial class BierInLijstOverzicht : Page
    {
        public BierInLijstOverzicht()
        {
            InitializeComponent();
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Page bierDetailView = new BierDetail();
            NavigationService.Navigate(bierDetailView);
        }

        private void KnopVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            LijstenOverzicht lijstenOverzicht = new LijstenOverzicht();
            NavigationService.Navigate(lijstenOverzicht);
        }
    }
}
