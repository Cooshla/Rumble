using RumbleApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs;

namespace RumbleApp.Core.ViewModels.Guide
{
    public class GuideViewModel : BaseViewModel, ITapLockMixin
    {
        TapLockMixinVars ITapLockMixin.TapLockMixinVars { get; set; }
        private readonly IAppNavigation _navi;
        private readonly IPageFactory _page;
        public string OtherOutfit { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public bool Skipped { get; set; }

        public RelayCommand SkipPagesCommand { get { return new RelayCommand(() => { GoToSkipPages(); }, () => CanSkipPagesRun); } }

        public RelayCommand<object> NextPageCommand
        {
            get
            {
                return new RelayCommand<object>((nextPageInt) => { GoToNextPage(nextPageInt); },
(nextPageInt) => CanNextPageRun);
            }
        }

        //public ICommand NotificationCommand { get { return new SimpleCommand (Notifications); } }
        private bool canSkipPagesRun;

        public bool CanSkipPagesRun
        {
            get { return !canSkipPagesRun; }
            set
            {
                canSkipPagesRun = value;
                OnPropertyChanged("CanSkipPagesRun");
                SkipPagesCommand.RaiseCanExecuteChanged();
            }
        }

        private bool canNextPageRun;

        public bool CanNextPageRun
        {
            get { return !canNextPageRun; }
            set
            {
                canNextPageRun = value;
                OnPropertyChanged("CanNextPageRun");
                NextPageCommand.RaiseCanExecuteChanged();
            }
        }

        private int currentPageInt { get; set; }

        public bool[] PageVisible { get; set; }

        public string AppVersion { get; set; }

        public GuideViewModel(IAppNavigation navi, IPageFactory page)
        {
            App.PageOpenedDateTime = DateTime.UtcNow;
            _navi = navi;
            _page = page;
            
            SetPageVisibility();

            Skipped = false;
            Adults = 0;
            Children = 0;
            OtherOutfit = string.Empty;
        }

        private void SetPageVisibility()
        {
            PageVisible = new bool[] { true, false, false, false };
            OnPropertyChanged("PageVisible");
            currentPageInt = 0;
        }

        private void GoToNextPage(object nextPage)
        {
            CanNextPageRun = true;
            var nextPageInt = Convert.ToInt16(nextPage);
            Device.BeginInvokeOnMainThread(() =>
            {
                PageVisible[currentPageInt] = !PageVisible[currentPageInt];
                PageVisible[nextPageInt] = !PageVisible[nextPageInt];
                currentPageInt++;
                OnPropertyChanged("PageVisible");
            });
            CanNextPageRun = false;
        }

        private async void GoToSkipPages()
        {
            CanSkipPagesRun = true;
            Settings.IsFirstRun = false;
            await _navi.PopModal();            
        }

    }
}
