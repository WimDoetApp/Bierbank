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
        private static BierNoteToevoegenModel bierNoteToevoegenModel = new BierNoteToevoegenModel();
        private static BierNoteDetailModel bierNoteDetailModel = new BierNoteDetailModel();

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

        public static BierNoteToevoegenModel BierNoteToevoegenModel
        {
            get
            {
                return bierNoteToevoegenModel;
            }
        }

        public static BierNoteDetailModel BierNoteDetailModel
        {
            get
            {
                return bierNoteDetailModel;
            }
        }
    }
}
