﻿using Bierbank.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bierbank.ViewModel
{
    public class BierToevoegenModel : BaseViewModel
    {
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

        private void ToevoegenBiertje()
        {
            BierDataService ds = new BierDataService();
            ds.InsertBiertje(SelectedBiertje);
        }
    }
}
