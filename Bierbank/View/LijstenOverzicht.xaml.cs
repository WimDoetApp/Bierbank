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
    /// Interaction logic for LijstenOverzicht.xaml
    /// </summary>
    public partial class LijstenOverzicht : Page
    {
        public LijstenOverzicht()
        {
            InitializeComponent();
        }

        private void KnopToevoegen_Click(object sender, RoutedEventArgs e)
        {
            LijstToevoegen lijstToevoegen = new LijstToevoegen();
            NavigationService.Navigate(lijstToevoegen);
        }

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BierInLijstOverzicht bierInLijstOverzicht = new BierInLijstOverzicht();
            NavigationService.Navigate(bierInLijstOverzicht);
        }
    }
}
