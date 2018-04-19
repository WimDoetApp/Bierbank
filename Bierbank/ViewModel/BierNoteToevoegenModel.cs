using Bierbank.Extensions;
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
    public class BierNoteToevoegenModel : BaseViewModel
    {
        //lege biernote
        private BierNotes bierNote;
        public BierNotes BierNote
        {
            get
            {
                if (bierNote == null)
                {
                    bierNote = new BierNotes();
                }
                return bierNote;
            }
            set
            {
                bierNote = value;
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

        public ICommand InsertCommand { get; set; }

        public BierNoteToevoegenModel()
        {
            KoppelenCommands();
            LeesGegevens();
        }

        private void KoppelenCommands()
        {
            InsertCommand = new BaseCommand(ToevoegenBiernote);
        }

        //ophalen bieren
        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        //toevoegen biernote
        private void ToevoegenBiernote()
        {
            //invoercontrole
            var error = false;

            if (BierNote.Onderwerp == null || BierNote.Onderwerp == "")
            {
                MessageBox.Show("Onderwerp moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (BierNote.Beschrijving == null ||BierNote.Beschrijving == "")
            {
                MessageBox.Show("Beschrijving moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (!error)
            {
                BierDataService ds = new BierDataService();
                ds.InsertBierNotes(BierNote);

                MessageBox.Show("Note succesvol toegevoegd!", "Success!", MessageBoxButton.OK);

                //refresh
                BierNotesHerladen();
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
