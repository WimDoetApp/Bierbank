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

        private static BierenOverzichtModel bierenOverzichtModel = new BierenOverzichtModel();
        private static BierDetailModel bierDetailModel = new BierDetailModel();
        private static BierToevoegenModel bierToevoegenModel = new BierToevoegenModel();
        private static BierNotesOverzichtModel bierNotesOverzichtModel = new BierNotesOverzichtModel();
        private static BierNoteToevoegenModel bierNoteToevoegenModel = new BierNoteToevoegenModel();
        private static BierNoteDetailModel bierNoteDetailModel = new BierNoteDetailModel();
        private static LijstenOverzichtModel lijstenOverzichtModel = new LijstenOverzichtModel();
        private static LijstToevoegenModel lijstToevoegenModel = new LijstToevoegenModel();
        private static BierInLijstOverzichtModel bierInLijstOverzichtModel = new BierInLijstOverzichtModel();

        public static BierenOverzichtModel BierenOverzichtModel
        {
            get
            {
                return bierenOverzichtModel;
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

        public static BierNotesOverzichtModel BierNotesOverzichtModel
        {
            get
            {
                return bierNotesOverzichtModel;
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

        public static LijstenOverzichtModel LijstenOverzichtModel
        {
            get
            {
                return lijstenOverzichtModel;
            }
        }

        public static LijstToevoegenModel LijstToevoegenModel
        {
            get
            {
                return lijstToevoegenModel;
            }
        }

        public static BierInLijstOverzichtModel BierInLijstOverzichtModel
        {
            get
            {
                return bierInLijstOverzichtModel;
            }
        }
    }
}
