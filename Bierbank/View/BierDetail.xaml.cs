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
    /// Interaction logic for BierDetail.xaml
    /// </summary>
    public partial class BierDetail : Page
    {
        public BierDetail()
        {
            InitializeComponent();
        }

        private void KnopVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = true;
        }

        private void KnopClosePopup_Click(object sender, RoutedEventArgs e)
        {
            Popup.IsOpen = false;
        }
    }
}
