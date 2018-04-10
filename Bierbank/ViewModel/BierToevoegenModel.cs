using Bierbank.Model;
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
        public static void ToevoegenBier(string naam, string soort, double percentage, string brouwerij, string image)
        {
            Biertjes biertje = new Biertjes();
            biertje.Naam = naam;
            biertje.Soort = soort;
            biertje.Percentage = percentage;
            biertje.Brouwerij = brouwerij;
            biertje.Image = image;

            BierDataService bierDS = new BierDataService();
            bierDS.InsertBiertje(biertje);
        }
    }
}
