using System.Runtime.CompilerServices;
using System.ComponentModel;
using System;
using System.Diagnostics;

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

        //images
        private string imageRoot;
        public string ImageRoot
        {
            get
            {
                if(imageRoot == null)
                {
                    imageRoot = GetDestinationPath();
                }
                return imageRoot;
            }
            set
            {
                imageRoot = value;
                NotifyPropertyChanged();
            }
        }

        //pad van de foto folder
        private static String GetDestinationPath()
        {
            //root pad van de app vinden
            String root = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

            //naar gekozen folder gaan
            root = String.Format(root + @"\Images\");

            return root;
        }
    }
}
