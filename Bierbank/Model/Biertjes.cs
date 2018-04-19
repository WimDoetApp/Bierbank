using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Bierbank.Model
{
    public class Biertjes : BaseModel, IDataErrorInfo
    {
        private int id;
        private string naam;
        private string soort;
        private double percentage;
        private string brouwerij;
        private string image;

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

        public string Naam
        {
            get
            {
                return naam;
            }
            set
            {
                naam = value;
                NotifyPropertyChanged();
            }
        }

        public string Soort
        {
            get
            {
                return soort;
            }
            set
            {
                soort = value;
                NotifyPropertyChanged();
            }
        }

        public double Percentage
        {
            get
            {
                return percentage;
            }
            set
            {
                percentage = value;
                NotifyPropertyChanged();
            }
        }

        public string Brouwerij
        {
            get
            {
                return brouwerij;
            }

            set
            {
                brouwerij = value;
                NotifyPropertyChanged();
            }
        }

        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                NotifyPropertyChanged();
            }
        }

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                switch (columnName)
                {
                    case "Naam": if (string.IsNullOrEmpty(Naam)) result = "Naam moet ingevuld zijn!"; break;
                    case "Percentage": if (Percentage <= 0) result = "Prijs moet een positief getal zijn."; break;
                };
                return result;
            }
        }
    }
}
