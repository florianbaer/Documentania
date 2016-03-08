using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.ViewModels
{
    using Prism.Mvvm;

    internal interface IWelcomeViewModel
    {
        string Text { get; }
    }

    class WelcomeViewModel : BindableBase, IWelcomeViewModel
    {
        public string Text
        {
            get
            {
                return "HALLO";
            }
        }
    }

    public class WelcomeDesignViewModel : IWelcomeViewModel
    {
        public WelcomeDesignViewModel()
        {
            this.Text = "Welcome to my design time";
        }
        public string Text { get; }
    }
}
