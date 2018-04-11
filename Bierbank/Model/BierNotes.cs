using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bierbank.Model
{
    public class BierNotes : BaseModel
    {
        private int id;
        private int bierId;
        private string onderwerp;
        private string beschrijving;
        private Biertjes biertje;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                NotifyPropertyChanged();
            }
        }

        public int BierId
        {
            get
            {
                return bierId;
            }
            set
            {
                bierId = value;
                NotifyPropertyChanged();
            }
        }

        public string Onderwerp
        {
            get
            {
                return onderwerp;
            }
            set
            {
                onderwerp = value;
                NotifyPropertyChanged();
            }
        }

        public string Beschrijving
        {
            get
            {
                return beschrijving;
            }
            set
            {
                beschrijving = value;
                NotifyPropertyChanged();
            }
        }

        public Biertjes Biertje
        {
            get
            {
                return biertje;
            }
            set
            {
                biertje = value;
                NotifyPropertyChanged();
            }
        }
    }
}