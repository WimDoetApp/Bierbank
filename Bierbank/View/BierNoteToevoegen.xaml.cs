﻿using System;
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
    /// Interaction logic for BierNoteToevoegen.xaml
    /// </summary>
    public partial class BierNoteToevoegen : Page
    {
        public BierNoteToevoegen()
        {
            InitializeComponent();
        }

        private void KnopToevoegen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Note succesvol toegevoegd!", "Success!", MessageBoxButton.OK);
        }
    }
}
