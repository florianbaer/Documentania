using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentania.Infrastructure.ViewModels
{
    using Documentania.Infrastructure.Configuration;
    using Documentania.Interfaces;

    using Prism.Commands;
    using Prism.Regions;

    public class NavigationElementViewModel
    {
        private readonly IRegionManager regionManager;

        private readonly NavigationElement model;

        public NavigationElementViewModel(IRegionManager regionManager, NavigationElement model)
        {
            this.regionManager = regionManager;
            this.model = model;
        }

        public string Titel => this.model.Title;

        public string Type => this.model.Type;

        public DelegateCommand NavigateCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            this.regionManager.RequestNavigate(RegionNames.ContentRegion, this.Type);
                        });
            }
        }
    }
}
