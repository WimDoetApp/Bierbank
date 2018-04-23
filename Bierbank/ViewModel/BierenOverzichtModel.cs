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
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.Text.RegularExpressions;

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

        //zoeken op bier naam
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
        public ICommand BierNotesCommand { get; set; }
        public ICommand ToevoegenCommand { get; set; }

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
            BierDataService ds = new BierDataService();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierDetailWeergeven);
            ToevoegenCommand = new BaseCommand(BierToevoegenWeergeven);
        }

        //naar de detailpagina van een bier gaan
        private void BierDetailWeergeven()
        {
            if (SelectedBiertje != null)
            {
                Messenger.Default.Send<Biertjes>(SelectedBiertje);
                Messenger.Default.Send<string>("BierDetail.xaml");
            }
        }

        //naar de pagina om bieren toe te voegen gaan
        private void BierToevoegenWeergeven()
        {
            Messenger.Default.Send<string>("BierToevoegen.xaml");
        }

        //resultaten zoekquery ophalen
        private void GetResults(string search)
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();

            ObservableCollection<Biertjes> nieuweBiertjes = new ObservableCollection<Biertjes>();

            Task.Factory.StartNew(() =>
            {
                foreach (Biertjes biertje in Biertjes)
                {
                    if (biertje.Naam.ToLower().Contains(search.ToLower()) || biertje.Naam.ToLower().StartsWith(search.ToLower()) || biertje.Naam.ToLower().EndsWith(search.ToLower())
                    || biertje.Soort.ToLower().Contains(search.ToLower()) || biertje.Soort.ToLower().StartsWith(search.ToLower()) || biertje.Soort.ToLower().EndsWith(search.ToLower()))
                    {
                        nieuweBiertjes.Add(biertje);
                    }
                }

                return nieuweBiertjes;
            }).ContinueWith(task =>
            {
                Biertjes = task.Result;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }

}
