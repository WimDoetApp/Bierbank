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
    public class LijstToevoegenModel : BaseViewModel
    {
        //lege lijst
        private Lijsten lijst;
        public Lijsten Lijst
        {
            get
            {
                if (lijst == null)
                {
                    lijst = new Lijsten();
                }
                return lijst;
            }
            set
            {
                lijst = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand InsertCommand { get; set; }

        public LijstToevoegenModel()
        {
            KoppelenCommands();
        }

        private void KoppelenCommands()
        {
            InsertCommand = new BaseCommand(ToevoegenLijst);
        }

        //lijst toevoegen
        private void ToevoegenLijst()
        {
            BierDataService ds = new BierDataService();
            ds.InsertLijsten(Lijst);

            //refresh
            LijstenHerladen();
        }

        //lijsten herladen
        private void LijstenHerladen()
        {
            BierDataService ds = new BierDataService();
            ObservableCollection<Lijsten> lijsten = ds.GetLijsten();
            Messenger.Default.Send<ObservableCollection<Lijsten>>(lijsten);
        }
    }
}
