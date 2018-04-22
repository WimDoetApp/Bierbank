using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Bierbank.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //datacontext
        private string frameSource;
        public string FrameSource
        {
            get
            {
                return frameSource;
            }
            set
            {
                frameSource = value;
                NotifyPropertyChanged();
            }
        }
    }
}
