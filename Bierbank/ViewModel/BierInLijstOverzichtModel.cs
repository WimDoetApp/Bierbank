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
    public class BierInLijstOverzichtModel : BaseViewModel
    {
        //geselecteerde lijst
        private Lijsten selectedLijst;
        public Lijsten SelectedLijst
        {
            get
            {
                return selectedLijst;
            }
            set
            {
                selectedLijst = value;
                NotifyPropertyChanged();
            }
        }

        //connectie bieren en lijsten
        private ObservableCollection<BierInLijst> bierenInLijst;
        public ObservableCollection<BierInLijst> BierenInLijst
        {
            get
            {
                return bierenInLijst;
            }
            set
            {
                bierenInLijst = value;
                NotifyPropertyChanged();
            }
        }

        //bieren in de lijst
        private ObservableCollection<Biertjes> biertjesInLijst;
        public ObservableCollection<Biertjes> BiertjesInLijst
        {
            get
            {
                return biertjesInLijst;
            }
            set
            {
                biertjesInLijst = value;
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

        //geselecteerde bier
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

        //id van het bier dat we willen toevoegen aan de lijst
        private int selectedBierId;
        public int SelectedBierId
        {
            get
            {
                return selectedBierId;
            }
            set
            {
                selectedBierId = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand WeergevenCommand { get; set; }
        public ICommand InsertCommand { get; set; }
        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DeleteBierCommand { get; set; }

        public BierInLijstOverzichtModel()
        {
            Messenger.Default.Register<Lijsten>(this, OnLijstReceived);
            LeesGegevens();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierDetailWeergeven);
            InsertCommand = new BaseCommand(BierAanLijstToevoegen);
            WijzigenCommand = new BaseCommand(UpdateLijst);
            DeleteCommand = new BaseCommand(DeleteLijst);
            DeleteBierCommand = new BaseCommand(DeleteBier);
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        //gekozen lijst ontvangen
        private void OnLijstReceived(Lijsten lijst)
        {
            SelectedLijst = lijst;

            //connectie tussen bieren en lijsten via BierInLijst
            BierDataService ds = new BierDataService();
            BierenInLijst = ds.GetBierInLijstByLijstId(SelectedLijst.Id);

            //lijst van bierIds
            List<int> bierIdsList = new List<int>();

            foreach(BierInLijst BierInLijst in BierenInLijst)
            {
                bierIdsList.Add(BierInLijst.BierId);
            }

            if (bierIdsList.Any())
            {
                string bierIds = string.Join(",", bierIdsList.ToArray());

                //bieren ophalen
                BiertjesInLijst = ds.GetBiertjesInLijst(bierIds);
            }
            else
            {
                BiertjesInLijst = new ObservableCollection<Biertjes>();
            }
        }

        //naar de detailpagina van een bier gaan
        private void BierDetailWeergeven()
        {
            if (SelectedBiertje != null)
            {
                Messenger.Default.Send<Biertjes>(SelectedBiertje);
            }
        }

        //bier aan lijst toevoegen
        private void BierAanLijstToevoegen()
        {
            BierDataService ds = new BierDataService();
            ds.InsertBierInLijst(SelectedBierId, SelectedLijst.Id);
        }
        
        //lijst aanpassen
        private void UpdateLijst()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateLijsten(SelectedLijst);
        }

        //lijst verwijderen
        private void DeleteLijst()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteLijsten(SelectedLijst);
        }

        //bier uit lijst verwijderen
        private void DeleteBier()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteBierInLijst(SelectedBiertje.Id, SelectedLijst.Id);
        }
    }
}
