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
    public class BierToevoegenModel : BaseViewModel
    {
        //geselecteerde biernote
        private Biertjes selectedBiertje;
        public Biertjes SelectedBiertje
        {
            get
            {
                if(selectedBiertje == null)
                {
                    selectedBiertje = new Biertjes();
                }
                return selectedBiertje;
            }
            set
            {
                selectedBiertje = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertCommand { get; set; }

        public BierToevoegenModel()
        {
            KoppelenCommands();
        }
 
        private void KoppelenCommands()
        {
            InsertCommand = new BaseCommand(ToevoegenBiertje);
        }

        //toevoegen bier
        private void ToevoegenBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.InsertBiertje(SelectedBiertje);

            //refresh
            BierenHerladen();
        }

        //bieren herladen
        private void BierenHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Biertjes> biertjes = ds.GetBiertjes();
            Messenger.Default.Send<ObservableCollection<Biertjes>>(biertjes);
        }
    }
}
