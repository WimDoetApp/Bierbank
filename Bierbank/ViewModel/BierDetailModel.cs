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
    public class BierDetailModel : BaseViewModel
    {
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

        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand WeergevenCommand { get; set; }

        public BierDetailModel()
        {
            Messenger.Default.Register<Biertjes>(this, OnBiertjeRecieved);
            KoppelenCommands();
        }

        private void OnBiertjeRecieved(Biertjes biertje)
        {
            SelectedBiertje = biertje;

            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotesBijBier(biertje.Id);
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBiertje);
            DeleteCommand = new BaseCommand(VerwijderBiertje);
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
        }

        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
            }
        }

        private void UpdateBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateBiertje(SelectedBiertje);
        }

        private void VerwijderBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteBiertje(SelectedBiertje);
        }
    }
}
