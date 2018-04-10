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
            Popup.IsOpen = true;
        }

        private void KnopClosePopup_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = false;
        }
    }
}
