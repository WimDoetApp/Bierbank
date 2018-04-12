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

        public ICommand WeergevenCommand { get; set; }

        public LijstenOverzichtModel()
        {
            LeesGegevens();
            KoppelenCommands();
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Lijsten = ds.GetLijsten();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierInLijstWeergeven);
        }

        //bieren in de gekozen lijst weergeven
        private void BierInLijstWeergeven()
        {
            if (SelectedLijst != null)
            {
                Messenger.Default.Send<Lijsten>(SelectedLijst);
            }
        }
    }
}
