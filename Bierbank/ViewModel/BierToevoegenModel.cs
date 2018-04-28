using Bierbank.Extensions;
using Bierbank.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Bierbank.ViewModel
{
    public class BierToevoegenModel : BaseViewModel
    {
        //variabelen
        private string fullPath;

        //geselecteerde biernote
        private Biertjes selectedBiertje;
        public Biertjes SelectedBiertje
        {
            get
            {
                if(selectedBiertje == null)
                {
                    selectedBiertje = new Biertjes();
                }
                return selectedBiertje;
            }
            set
            {
                selectedBiertje = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertCommand { get; set; }
        public ICommand ImageUploadCommand { get; set; }

        public BierToevoegenModel()
        {
            KoppelenCommands();
        }
 
        private void KoppelenCommands()
        {
            InsertCommand = new BaseCommand(ToevoegenBiertje);
            ImageUploadCommand = new BaseCommand(UploadenFoto);
        }

        //foto uploaden
        private void UploadenFoto()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Selecteer een foto";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";
            
            if(fileDialog.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(fileDialog.FileName));
                fullPath = fileDialog.FileName;
                string path = System.IO.Path.GetFileName(fullPath);
                SelectedBiertje.Image = GetDestinationPath(path, @"Images");
            }
        }

        //toevoegen bier
        private void ToevoegenBiertje()
        {
            BierDataService ds = new BierDataService();
            //invoercontrole
            var error = false;

            if (SelectedBiertje.Naam == null || SelectedBiertje.Naam == "")
            {
                MessageBox.Show("Naam moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (SelectedBiertje.Percentage <= 0)
            {
                MessageBox.Show("Percentage moet een komma getal zijn! Bv. 5% = 0.05", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (ds.BiertjeBestaat(SelectedBiertje))
            {
                MessageBox.Show("Dit bier bestaat al!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (!error)
            {
                //als er geen image geupload is --> standaard image
                if (SelectedBiertje.Image == null)
                {
                    SelectedBiertje.Image = GetDestinationPath("generic.jpg", @"Images");
                }
                else
                {
                    //image toevoegen aan de app
                    string destinationPath = SelectedBiertje.Image;
                    if (!File.Exists(destinationPath))
                    {
                        File.Copy(fullPath, destinationPath, true);
                    }
                }

                ds.InsertBiertje(SelectedBiertje);

                MessageBox.Show("Bier succesvol toegevoegd!", "Success!", MessageBoxButton.OK);

                //refresh
                BierenHerladen();
            }
        }

        //pad om foto in op te slagen vinden
        private static String GetDestinationPath(string file, string folder)
        {
            //root pad van de app vinden
            String root = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            //naar gekozen folder gaan
            root = String.Format(root + @"\{0}\" + file, folder);

            return root;
        }

        //bieren herladen
        private void BierenHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();
            Messenger.Default.Send<ObservableCollection<Biertjes>>(biertjes);
        }
    }
}
