using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bierbank.Model
{
    public class Lijsten : BaseModel
    {
        private int id;
        private string naam;

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
    }
}