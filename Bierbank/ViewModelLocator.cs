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
        private static BierDetailModel bierDetailModel = new BierDetailModel();
        private static BierToevoegenModel bierToevoegenModel = new BierToevoegenModel();

        public static BierenOverzichtModel MenuWindowViewModel
        {
            get
            {
                return menuWindowViewModel;
            }
        }

        public static BierDetailModel BierDetailModel
        {
            get
            {
                return bierDetailModel;
            }
        }

        public static BierToevoegenModel BierToevoegenModel
        {
            get
            {
                return bierToevoegenModel;
            }
        }
    }
}
