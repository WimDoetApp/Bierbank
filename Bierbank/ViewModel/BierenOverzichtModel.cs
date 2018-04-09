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

        public BierenOverzichtModel()
        {
            LeesGegevens();
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }
    }

}
