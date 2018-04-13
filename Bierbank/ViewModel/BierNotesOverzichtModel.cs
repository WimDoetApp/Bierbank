using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bierbank.Model;
using Bierbank.Extensions;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    class BierNotesOverzichtModel : BaseViewModel
    {
        //alle biernotes
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

        public ICommand WeergevenCommand { get; set; }

        public BierNotesOverzichtModel()
        {
            //lijsten ontvangen
            Messenger.Default.Register<ObservableCollection<BierNotes>>(this, OnBierNotesReceived);
            //Als er via messenger geen lijsen ontvangen worden, gaan we ze uit de databank halen
            if (BierNotes == null)
            {
                LeesGegevens();
            }
            OphalenBierenBijNotes();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
        }

        //biernotes ophalen
        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotes();
        }

        //biernotes ontvangen
        private void OnBierNotesReceived(ObservableCollection<BierNotes> bierNotes)
        {
            BierNotes = bierNotes;
        }

        //details over de gekozen biernote weergeven
        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
            }
        }

        //Bieren aan de juiste notes linken
        private void OphalenBierenBijNotes()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();

            foreach(BierNotes BierNote in BierNotes)
            {
                foreach(Biertjes biertje in biertjes)
                {
                    if(biertje.Id == BierNote.BierId)
                    {
                        BierNote.Biertje = biertje;
                    }
                }
            }
        }
    }
}
