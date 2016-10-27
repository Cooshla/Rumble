using RumbleApp.Core.Interfaces;
using RumbleApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RumbleApp.Core.ViewModels
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
