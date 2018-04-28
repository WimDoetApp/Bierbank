using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bierbank.Extensions;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    class BierNotesOverzichtModel : BaseViewModel
    {
        //alle biernotes
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

        //geselecteerde biernote
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

        //zoeken op biernote naam
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

        public BierNotesOverzichtModel()
        {
            //lijsten ontvangen
            Messenger.Default.Register<ObservableCollection<BierNotes>>(this, OnBierNotesReceived);
            //Als er via messenger geen lijsen ontvangen worden, gaan we ze uit de databank halen
            if (BierNotes == null)
            {
                LeesGegevens();
            }
            OphalenBierenBijNotes();
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            WeergevenCommand = new BaseCommand(BierNoteDetailWeergeven);
            ToevoegenCommand = new BaseCommand(BierNoteToevoegenWeergeven);
        }

        //biernotes ophalen
        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotes();
        }

        //biernotes ontvangen
        private void OnBierNotesReceived(ObservableCollection<BierNotes> bierNotes)
        {
            BierNotes = bierNotes;
            OphalenBierenBijNotes();
        }

        //details over de gekozen biernote weergeven
        private void BierNoteDetailWeergeven()
        {
            if (SelectedBierNote != null)
            {
                Messenger.Default.Send<BierNotes>(SelectedBierNote);
                Messenger.Default.Send<string>("BierNoteDetail.xaml");
            }
        }

        //naar de pagina BierNoteToevoegen gaan
        private void BierNoteToevoegenWeergeven()
        {
            Messenger.Default.Send<string>("BierNoteToevoegen.xaml");
        }

        //Bieren aan de juiste notes linken
        private void OphalenBierenBijNotes()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();

            foreach(BierNotes BierNote in BierNotes)
            {
                foreach(Biertjes biertje in biertjes)
                {
                    if(biertje.Id == BierNote.BierId)
                    {
                        BierNote.Biertje = biertje;
                    }
                }
            }
        }

        //resultaten zoekquery ophalen
        private void GetResults(string search)
        {
            BierDataService ds = new BierDataService();
            BierNotes = ds.GetBierNotes();
            OphalenBierenBijNotes();

            ObservableCollection<BierNotes> nieuweBierNotes = new ObservableCollection<BierNotes>();

            Task.Factory.StartNew(() =>
            {
                foreach (BierNotes bierNote in BierNotes)
                {
                    if (bierNote.Onderwerp.ToLower().Contains(search.ToLower()) || bierNote.Onderwerp.ToLower().StartsWith(search.ToLower()) || bierNote.Onderwerp.ToLower().EndsWith(search.ToLower())
                    || bierNote.Biertje.Naam.ToLower().Contains(search.ToLower()) || bierNote.Biertje.Naam.ToLower().StartsWith(search.ToLower()) || bierNote.Biertje.Naam.ToLower().EndsWith(search.ToLower()))
                    {
                        nieuweBierNotes.Add(bierNote);
                    }
                }

                return nieuweBierNotes;
            }).ContinueWith(task =>
            {
                BierNotes = task.Result;
            }, System.Threading.CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
