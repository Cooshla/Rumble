using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace JamnationApp.Core.Models
{
    public class GuidePages
    {
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public FormattedString LabelText { get; set; }
        public string NextText { get; set; }
        public ImageSource ImageUrl { get; set; }

        public ICommand CommandFunction { get; set; }
        public ICommand CloseCommand { get; set; }


    }
}
