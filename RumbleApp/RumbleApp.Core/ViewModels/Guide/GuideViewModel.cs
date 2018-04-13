using JamnationApp.Core.Interfaces;
using JamnationApp.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.ViewModels.Guide
{
    public class GuideViewModel : BaseViewModel
    {
        private readonly IAppNavigation Navi;
        private readonly IPageFactory PageFac;

        public ObservableCollection<GuidePages> GuideScreens { get; set; }
        public ICommand CloseCommand { get { return new Command(this.Close); } }
        public GuideViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
            

            GuideScreens = new ObservableCollection<GuidePages>();
            GuideScreens.Add(new GuidePages()
            {
                ImageUrl = ImageSource.FromFile("GuideImage1.png"),
                BackgroundColor = Color.FromHex("#7C4ECD"),
                TextColor = Color.White,
                LabelText = "Guide1",
                NextText = "Next",
                CommandFunction = new Command(() => { NextPage(1); }),
                CloseCommand = this.CloseCommand
            });

            GuideScreens.Add(new GuidePages()
            {
                ImageUrl = ImageSource.FromFile("GuideImage1.png"),
                BackgroundColor = Color.FromHex("#7C4ECD"),
                TextColor = Color.White,
                LabelText = "Guide1",
                NextText = "Next",
                CommandFunction = new Command(() => { NextPage(2); }),
                CloseCommand = this.CloseCommand
            });

            GuideScreens.Add(new GuidePages()
            {
                ImageUrl = ImageSource.FromFile("GuideImage1.png"),
                BackgroundColor = Color.FromHex("#7C4ECD"),
                TextColor = Color.White,
                LabelText = "Guide1",
                NextText = "Finish",
                CommandFunction = new Command(() => { NextPage(3); }),
                CloseCommand = this.CloseCommand
            });


        }

        private void Close()
        {
            Navi.PopModal();
        }

        private void NextPage(int currentPage)
        {
            switch (currentPage)
            {
                case 3:
                    Navi.PopModal();
                    break;
                default:
                    MessagingCenter.Send<GuideViewModel, int>(this, Messages.Walkthrough, currentPage);
                    break;
            }
        }

    }
}
