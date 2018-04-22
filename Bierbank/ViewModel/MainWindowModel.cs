using Bierbank.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    public class MainWindowModel : BaseViewModel
    {
        public ICommand BierNotesCommand { get; set; }
        public ICommand LijstenCommand { get; set; }
        public ICommand HomeCommand { get; set; }

        private void KoppelenCommands()
        {
            BierNotesCommand = new BaseCommand(BierNotesWeergeven);
            LijstenCommand = new BaseCommand(LijstenWeergeven);
            HomeCommand = new BaseCommand(HomeWeergeven);
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
        }

        //naar de pagina LijstenOverzicht gaan
        private void LijstenWeergeven()
        {
            FrameSource = "LijstenOverzicht.xaml";
        }

        //naar de pagina BierenOverzicht gaan
        private void HomeWeergeven()
        {
            FrameSource = "BierenOverzicht.xaml";
        }
    }
}
