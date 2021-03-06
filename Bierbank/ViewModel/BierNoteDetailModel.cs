﻿using Bierbank.Extensions;
using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    public class BierNoteDetailModel : BaseViewModel
    {
        private string bierNoteNaam = "";

        //geselecteerde biernote
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

        //alle bieren
        private ObservableCollection<Biertjes> biertjes;
        public ObservableCollection<Biertjes> Biertjes
        {
            get
            {
                return biertjes;
            }
            set
            {
                biertjes = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BierNoteDetailModel()
        {
            Messenger.Default.Register<BierNotes>(this, OnBierNoteReceived);
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBierNote);
            DeleteCommand = new BaseCommand(DeleteBierNote);
        }

        //gekozen biernote ontvangen
        private void OnBierNoteReceived(BierNotes bierNote)
        {
            SelectedBierNote = bierNote;
            bierNoteNaam = bierNote.Onderwerp;
            LeesGegevens();
        }

        //bieren ophalen
        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        //biernote wijzigen
        private void UpdateBierNote()
        {
            BierDataService ds = new BierDataService();
            //invoercontrole
            var error = false;

            if (SelectedBierNote.Onderwerp == "")
            {
                MessageBox.Show("Onderwerp moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (SelectedBierNote.Beschrijving == "")
            {
                MessageBox.Show("Beschrijving moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (SelectedBierNote.Onderwerp != bierNoteNaam && ds.BierNoteBestaat(SelectedBierNote))
            {
                MessageBox.Show("Note bestaat al!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (!error)
            {
                ds.UpdateBierNotes(SelectedBierNote);

                MessageBox.Show("De gegevens zijn aangepast", "Note gewijzigd!", MessageBoxButton.OK);

                //refresh
                BierNotesHerladen();
            }
        }

        //biernote verwijderen
        private void DeleteBierNote()
        {
            if (MessageBox.Show("Bent u hier zeker van?", "verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                BierDataService ds = new BierDataService();
                ds.DeleteBierNotes(SelectedBierNote);

                //refresh
                BierNotesHerladen();

                Messenger.Default.Send<string>("BierNotesOverzicht.xaml");
            }
        }

        //biernotes herladen
        private void BierNotesHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<BierNotes> bierNotes = ds.GetBierNotes();

            //Bieren aan de juiste notes linken
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();

            foreach (BierNotes bierNote in bierNotes)
            {
                foreach (Biertjes biertje in biertjes)
                {
                    if (biertje.Id == bierNote.BierId)
                    {
                        bierNote.Biertje = biertje;
                    }
                }
            }

            Messenger.Default.Send<ObservableCollection<BierNotes>>(bierNotes);
        }
    }
}
