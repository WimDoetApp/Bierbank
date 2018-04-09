using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bierbank.Model
{
    public class Biertjes : BaseModel
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
    }
}
