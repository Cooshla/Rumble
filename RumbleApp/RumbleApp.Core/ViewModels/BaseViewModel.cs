using JamnationApp.Core.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace JamnationApp.Core.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged, ITapLockMixin
    {
        TapLockMixinVars ITapLockMixin.TapLockMixinVars { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetObservableProperty<T>(
            ref T field,
            T value,
            [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
        }
        protected bool IsInternetConnection()
        {
            
            return true;
            /*
            bool returnValue = !(DeviceInfo.Connectivity.InternetReachability == Acr.DeviceInfo.NetworkReachability.NotReachable);

            if (!returnValue)
                App.UserDialogService.AlertAsync("You are currently offline, please connect to the internet and try again");

            return returnValue;*/
        }
    }
}
