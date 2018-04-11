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
    public class BierNoteDetailModel : BaseViewModel
    {
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

        public ICommand WijzigenCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public BierNoteDetailModel()
        {
            Messenger.Default.Register<BierNotes>(this, OnBierNoteReceived);
            KoppelenCommands();
            LeesGegevens();
        }

        private void KoppelenCommands()
        {
            WijzigenCommand = new BaseCommand(UpdateBierNote);
            DeleteCommand = new BaseCommand(DeleteBierNote);
        }

        private void OnBierNoteReceived(BierNotes bierNote)
        {
            SelectedBierNote = bierNote;
        }

        private void LeesGegevens()
        {
            BierDataService ds = new BierDataService();
            Biertjes = ds.GetBiertjes();
        }

        private void UpdateBierNote()
        {
            BierDataService ds = new BierDataService();
            ds.UpdateBierNotes(SelectedBierNote);
        }

        private void DeleteBierNote()
        {
            BierDataService ds = new BierDataService();
            ds.DeleteBierNotes(SelectedBierNote);
        }
    }
}
