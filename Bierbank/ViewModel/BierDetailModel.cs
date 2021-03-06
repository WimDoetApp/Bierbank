﻿using Bierbank.Extensions;
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
    public class BierDetailModel : BaseViewModel
    {
        //variabelen
        private string fullPath;
        private bool savePath = false;

        private string bierNaam = "";

        //images
        private string root;
        public string Root
        {
            get
            {
                if (root == null)
                {
                    root = ImageRoot;
                }
                return root;
            }
        }

        //het biertje waarvoor we details weergeven
        private Biertjes selectedBiertje;
        public Biertjes SelectedBiertje
        {
            get
            {
                return selectedBiertje;
            }
            set
            {
                selectedBiertje = value;
                NotifyPropertyChanged();
            }
        }

        //alle biernotes bij gekozen bier
        private ObservableCollection<BierNotes> bierNotes;
        public ObservableCollection<BierNotes> BierNotes
        {
            get
            {
                return bierNotes;
            }
            set
            {
                bierNotes = value;
                NotifyPropertyChanged();
            }
        }

        //de geselecteerde biernote
        private BierNotes selectedBierNote;
        public BierNotes SelectedBierNote
        {
            get
            {
                return selectedBierNote;
            }
            set
            {
                selectedBierNote = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand WeergevenCommand { get; set; }
        public ICommand ImageUploadCommand { get; set; }

        public BierDetailModel()
        {
            Messenger.Default.Register<Biertjes>(this, OnBiertjeReceived);
            KoppelenCommands();
        }

        //ontvangen gekozen bier
        private void OnBiertjeReceived(Biertjes biertje)
        {
            SelectedBiertje = biertje;
            bierNaam = biertje.Naam;

            //alle biernotes bij dit bier ophalen
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotesBijBier(biertje.Id);
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBiertje);
            DeleteCommand = new BaseCommand(VerwijderBiertje);
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
            ImageUploadCommand = new BaseCommand(UploadenFoto);
        }

        //details over de gekozen biernote weergeven
        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
                Messenger.Default.Send<string>("BierNoteDetail.xaml");
            }
        }

        //foto uploaden
        private void UploadenFoto()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Selecteer een foto";
            fileDialog.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "Portable Network Graphic (*.png)|*.png";

            if (fileDialog.ShowDialog() == true)
            {
                fullPath = fileDialog.FileName;
                string path = System.IO.Path.GetFileName(fullPath);
                SelectedBiertje.Image = path;
                savePath = true;
            }
        }

        //bier aanpassen
        private void UpdateBiertje()
        {
            BierDataService ds = new BierDataService();
            //invoercontrole
            var error = false;

            if(SelectedBiertje.Naam == "")
            {
                MessageBox.Show("Naam moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if(SelectedBiertje.Percentage <= 0)
            {
                MessageBox.Show("Percentage moet een komma getal zijn! Bv. 5% = 0.05", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (SelectedBiertje.Naam != bierNaam && ds.BiertjeBestaat(SelectedBiertje))
            {
                MessageBox.Show("Dit bier bestaat al!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (!error)
            {
                if (savePath)
                {
                    //image toevoegen aan de database
                    string destinationPath = ImageRoot + SelectedBiertje.Image;
                    //als de image nog niet in de resources staat voegen we ze toe
                    if (!File.Exists(destinationPath))
                    {
                        File.Copy(fullPath, destinationPath, true);
                    }

                    savePath = false;
                }

                ds.UpdateBiertje(SelectedBiertje);

                MessageBox.Show("De gegevens zijn aangepast", "Bier gewijzigd!", MessageBoxButton.OK);

                //refresh
                BierenHerladen();
            }
        }

        //bier verwijderen
        private void VerwijderBiertje()
        {
            //Bier verwijderen
            if (MessageBox.Show("Bent u hier zeker van?", "verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                BierDataService ds = new BierDataService();

                //checken of er biernotes horen bij dit bier
                foreach (BierNotes bierNote in BierNotes)
                {
                    if (bierNote.BierId == SelectedBiertje.Id)
                    {
                        if (MessageBox.Show("De bijhorende biernote " + bierNote.Onderwerp + " zal verwijdert worden! Als u op nee klikt, zal deze aan het eerste bier in de databank worden toegewezen", "verwijderen", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            ds.DeleteBierNotes(bierNote);
                        }
                        else
                        {
                            bierNote.BierId = 0;
                            ds.UpdateBierNotes(bierNote);
                        }
                    }
                }

                ds.DeleteBierUitAlleLijsten(SelectedBiertje.Id);

                ds.DeleteBiertje(SelectedBiertje);

                //refresh
                BierenHerladen();
                BierNotesHerladen();
                Messenger.Default.Send<string>("BierenOverzicht.xaml");
            }
        }

        //bieren herladen
        private void BierenHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();
            Messenger.Default.Send<ObservableCollection<Biertjes>>(biertjes);
        }

        //biernotes herladen
        private void BierNotesHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<BierNotes> bierNotes = ds.GetBierNotes();
            Messenger.Default.Send<ObservableCollection<BierNotes>>(bierNotes);
        }
    }
}
