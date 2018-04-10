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

        public ICommand UpdateCommand { get; set; }

        public BierDetailModel()
        {
            Messenger.Default.Register<Biertjes>(this, OnBiertjeRecieved);

            UpdateCommand = new BaseCommand(UpdateBiertje);
        }

        private void OnBiertjeRecieved(Biertjes biertje)
        {
            SelectedBiertje = biertje;
        }

        private void KoppelenCommands()
        {
            UpdateCommand = new BaseCommand(UpdateBiertje);
        }

        private void UpdateBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateBiertje(SelectedBiertje);
        }
    }
}
