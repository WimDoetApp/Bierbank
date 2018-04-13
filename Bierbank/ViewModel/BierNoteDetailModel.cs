using Bierbank.Extensions;
using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    public class BierNoteDetailModel : BaseViewModel
    {
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
            LeesGegevens();
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
            ds.UpdateBierNotes(SelectedBierNote);

            //refresh
            BierNotesHerladen();
        }

        //biernote verwijderen
        private void DeleteBierNote()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteBierNotes(SelectedBierNote);

            //refresh
            BierNotesHerladen();
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
