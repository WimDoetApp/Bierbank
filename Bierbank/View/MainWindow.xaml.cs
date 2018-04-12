using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoBack)
            {
                frame.NavigationService.GoBack();
            }
        }

        private void ButtonForward_Click(object sender, RoutedEventArgs e)
        {
            if (frame.NavigationService.CanGoForward)
            {
                frame.NavigationService.GoForward();
            }
        }

        private void KnopBierNotes_Click(object sender, RoutedEventArgs e)
        {
            BierNotesOverzicht bierNotesOverzicht = new BierNotesOverzicht();
            frame.NavigationService.Navigate(bierNotesOverzicht);
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BierenOverzicht bierenOverzicht = new BierenOverzicht();
            frame.NavigationService.Navigate(bierenOverzicht);
        }

        private void KnopLijsten_Click(object sender, RoutedEventArgs e)
        {
            LijstenOverzicht lijstenOverzicht = new LijstenOverzicht();
            frame.NavigationService.Navigate(lijstenOverzicht);
        }
    }
}
