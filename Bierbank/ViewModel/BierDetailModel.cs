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

        public BierDetailModel()
        {
            Messenger.Default.Register<Biertjes>(this, OnBiertjeRecieved);
            KoppelenCommands();
        }

        //ontvangen gekozen bier
        private void OnBiertjeRecieved(Biertjes biertje)
        {
            SelectedBiertje = biertje;

            //alle biernotes bij dit bier ophalen
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotesBijBier(biertje.Id);
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBiertje);
            DeleteCommand = new BaseCommand(VerwijderBiertje);
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
        }

        //details over de gekozen biernote weergeven
        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
            }
        }

        //bier aanpassen
        private void UpdateBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateBiertje(SelectedBiertje);
        }

        //bier verwijderen
        private void VerwijderBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteBiertje(SelectedBiertje);
        }
    }
}
