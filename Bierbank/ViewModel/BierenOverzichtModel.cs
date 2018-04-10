using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bierbank.Model;
using Bierbank.View;
using System.Windows.Input;
using Bierbank.Extensions;
using System.Windows;
using System.Windows.Controls;

namespace Bierbank.ViewModel
{
    public class BierenOverzichtModel : BaseViewModel
    {
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

        public ICommand WeergevenCommand { get; set; }

        public BierenOverzichtModel()
        {
            LeesGegevens();
            KoppelenCommands();
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierDetailWeergeven);
        }

        private void BierDetailWeergeven()
        {
            if (SelectedBiertje != null)
            {
                Messenger.Default.Send<Biertjes>(SelectedBiertje);
            }
        }
    }

}
