using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Bierbank.Model
{
    public class BierInLijst : BaseModel
    {
        private int id;
        private int bierId;
        private int lijstId;

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

        public int LijstId
        {
            get
            {
                return lijstId;
            }
            set
            {
                lijstId = value;
                NotifyPropertyChanged();
            }
        }
    }
}