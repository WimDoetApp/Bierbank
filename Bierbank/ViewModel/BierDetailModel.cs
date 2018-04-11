using Bierbank.Extensions;
using Bierbank.Model;
using System;
using System.Collections.Generic;
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

        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BierDetailModel()
        {
            Messenger.Default.Register<Biertjes>(this, OnBiertjeRecieved);
            KoppelenCommands();
        }

        private void OnBiertjeRecieved(Biertjes biertje)
        {
            SelectedBiertje = biertje;
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBiertje);
            DeleteCommand = new BaseCommand(VerwijderBiertje);
        }

        private void UpdateBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateBiertje(SelectedBiertje);
        }

        private void WijzigBiertje()
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
