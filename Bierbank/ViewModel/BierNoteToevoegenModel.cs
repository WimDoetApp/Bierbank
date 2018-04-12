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
            BierDataService ds = new BierDataService();
            ds.InsertBierNotes(BierNote);
        }
    }
}
