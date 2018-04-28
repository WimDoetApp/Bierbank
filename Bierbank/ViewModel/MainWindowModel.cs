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
    public class MainWindowModel : BaseViewModel
    {
        //datacontext
        private string frameSource;
        public string FrameSource
        {
            get
            {
                return frameSource;
            }
            set
            {
                frameSource = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand BierNotesCommand { get; set; }
        public ICommand LijstenCommand { get; set; }
        public ICommand HomeCommand { get; set; }
        public ICommand HerlaadCommand { get; set; }

        private void KoppelenCommands()
        {
            BierNotesCommand = new BaseCommand(BierNotesWeergeven);
            LijstenCommand = new BaseCommand(LijstenWeergeven);
            HomeCommand = new BaseCommand(HomeWeergeven);
            HerlaadCommand = new BaseCommand(AllesHerladen);
        }

        public MainWindowModel()
        {
            //frame ontvangen
            Messenger.Default.Register<string>(this, OnFrameSourceReceived);
            //Als het frame leeg is
            if(FrameSource == null)
            {
                FrameSource = "BierenOverzicht.xaml";
            }
            KoppelenCommands();
        }

        private void OnFrameSourceReceived(string frameSource)
        {
            FrameSource = frameSource;
        }

        //naar de pagina biernotes gaan
        private void BierNotesWeergeven()
        {
            FrameSource = "BierNotesOverzicht.xaml";

            //refresh
            BierDataService ds = new BierDataService();
            ObservableCollection<BierNotes> bierNotes = ds.GetBierNotes();
            Messenger.Default.Send<ObservableCollection<BierNotes>>(bierNotes);
        }

        //naar de pagina LijstenOverzicht gaan
        private void LijstenWeergeven()
        {
            FrameSource = "LijstenOverzicht.xaml";

            //refresh
            BierDataService ds = new BierDataService();
            ObservableCollection<Lijsten> lijsten = ds.GetLijsten();
            Messenger.Default.Send<ObservableCollection<Lijsten>>(lijsten);
        }

        //naar de pagina BierenOverzicht gaan
        private void HomeWeergeven()
        {
            FrameSource = "BierenOverzicht.xaml";

            //refresh
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();
            Messenger.Default.Send<ObservableCollection<Biertjes>>(biertjes);
        }

        //de tabellen refreshen
        private void AllesHerladen()
        {
            BierDataService ds = new BierDataService();

            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();
            ObservableCollection<BierNotes> bierNotes = ds.GetBierNotes();
            ObservableCollection<Lijsten> lijsten = ds.GetLijsten();

            Messenger.Default.Send<ObservableCollection<Biertjes>>(biertjes);
            Messenger.Default.Send<ObservableCollection<BierNotes>>(bierNotes);
            Messenger.Default.Send<ObservableCollection<Lijsten>>(lijsten);
        }
    }
}
