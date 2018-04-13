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

        public ICommand WeergevenCommand { get; set; }

        public BierenOverzichtModel()
        {
            //bieren ontvangen
            Messenger.Default.Register<ObservableCollection<Biertjes>>(this, OnBiertjesReceived);
            //Als er via messenger geen bieren ontvangen worden, gaan we ze uit de databank halen
            if (Biertjes == null)
            {
                LeesGegevens();
            }
            KoppelenCommands();
        }

        //ohpalen bieren
        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        //bieren ontvangen
        private void OnBiertjesReceived(ObservableCollection<Biertjes> biertjes)
        {
            Biertjes = biertjes;
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierDetailWeergeven);
        }

        //naar de detailpagina van een bier gaan
        private void BierDetailWeergeven()
        {
            if (SelectedBiertje != null)
            {
                Messenger.Default.Send<Biertjes>(SelectedBiertje);
            }
        }
    }

}
