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

        public ICommand WeergevenCommand { get; set; }

        public BierNotesOverzichtModel()
        {
            LeesGegevens();
            OphalenBierenBijNotes();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotes();
        }

        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
            }
        }

        private void OphalenBierenBijNotes()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();

            foreach(BierNotes BierNote in BierNotes)
            {
                foreach(Biertjes Biertje in Biertjes)
                {
                    if(Biertje.Id == BierNote.BierId)
                    {
                        BierNote.Biertje = Biertje;
                    }
                }
            }
        }
    }
}
