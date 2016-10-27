using BlankXamarinApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankXamarinApp.Core.ViewModels
{
    public class MainPageViewModel
    {
        private IPageFactory PageFac { get; set; }
        private IAppNavigation Navi { get; set; }

        public MainPageViewModel(IPageFactory _page, IAppNavigation _navi)
        {
            PageFac = _page;
            Navi = _navi;
        }
    }
}
