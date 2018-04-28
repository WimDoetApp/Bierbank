using Bierbank.Extensions;
using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            //invoercontrole
            var error = false;

            if (Lijst.Naam == null || Lijst.Naam == "")
            {
                MessageBox.Show("Lijst moet ingevuld zijn!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (ds.LijstBestaat(Lijst))
            {
                MessageBox.Show("Lijst bestaat al!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                error = true;
            }

            if (!error)
            {
                ds.InsertLijsten(Lijst);

                MessageBox.Show("Lijst succesvol toegevoegd!", "Success!", MessageBoxButton.OK);

                //refresh
                LijstenHerladen();
            }
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
