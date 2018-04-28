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
    public class LijstenOverzichtModel : BaseViewModel
    {
        //alle lijsten
        private ObservableCollection<Lijsten> lijsten;
        public ObservableCollection<Lijsten> Lijsten
        {
            get
            {
                return lijsten;
            }
            set
            {
                lijsten = value;
                NotifyPropertyChanged();
            }
        }

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

        //zoeken op lijsten naam
        private string search;
        public string Search
        {
            get
            {
                return search;
            }
            set
            {
                search = value;
                NotifyPropertyChanged();
                GetResults(search);
            }
        }

        public ICommand WeergevenCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

        public LijstenOverzichtModel()
        {
            //lijsten ontvangen
            Messenger.Default.Register<ObservableCollection<Lijsten>>(this, OnLijstenReceived);
            //Als er via messenger geen lijsen ontvangen worden, gaan we ze uit de databank halen
            if (Lijsten == null)
            {
                LeesGegevens();
            }
            KoppelenCommands();
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Lijsten = ds.GetLijsten();
        }

        //lijsten ontvangen
        private void OnLijstenReceived(ObservableCollection<Lijsten> lijsten)
        {
            Lijsten = lijsten;
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierInLijstWeergeven);
            ToevoegenCommand = new BaseCommand(LijstToevoegenWeergeven);
        }

        //bieren in de gekozen lijst weergeven
        private void BierInLijstWeergeven()
        {
            if (SelectedLijst != null)
            {
                Messenger.Default.Send<Lijsten>(SelectedLijst);
                Messenger.Default.Send<string>("BierInLijstOverzicht.xaml");
            }
        }

        //Naar de pagina LijstToevoegen gaan
        private void LijstToevoegenWeergeven()
        {
            Messenger.Default.Send<string>("LijstToevoegen.xaml");
        }

        //resultaten zoekquery ophalen
        private void GetResults(string search)
        {
            BierDataService ds = new BierDataService();
            Lijsten = ds.GetLijsten();

            ObservableCollection<Lijsten> nieuweLijsten = new ObservableCollection<Lijsten>();

            Task.Factory.StartNew(() =>
            {
                foreach (Lijsten lijst in Lijsten)
                {
                    if (lijst.Naam.ToLower().Contains(search.ToLower()) || lijst.Naam.ToLower().StartsWith(search.ToLower()) || lijst.Naam.ToLower().EndsWith(search.ToLower()))
                    {
                        nieuweLijsten.Add(lijst);
                    }
                }

                return nieuweLijsten;
            }).ContinueWith(task =>
            {
                Lijsten = task.Result;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
