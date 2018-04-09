using Bierbank.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bierbank
{
    class ViewModelLocator
    {

        private static BierenOverzichtModel menuWindowViewModel = new BierenOverzichtModel();

        public static BierenOverzichtModel MenuWindowViewModel
        {
            get
            {
                return menuWindowViewModel;
            }
        }
    }
}
