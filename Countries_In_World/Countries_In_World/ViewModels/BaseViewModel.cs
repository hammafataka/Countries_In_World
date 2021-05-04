using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Countries_In_World.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyname = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string Propertyname = "")
        {
            if (object.Equals(storage, value))
                return false;
            storage = value;
            OnPropertyChanged(Propertyname);
            return true;

        }
        private bool isBusy;

        public bool Isbusy
        {
            get { return isBusy; }
            set => SetProperty(ref isBusy, value);
        }


    }
}
