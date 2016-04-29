// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="NavigationElementViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'NavigationElementViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------

namespace Documentania.Infrastructure.ViewModels
{
    using System;

    using Documentania.Infrastructure.Interfaces;

    using Prism.Commands;
    using Prism.Regions;

    public class NavigationElementViewModel
    {
        private readonly IRegionManager regionManager;

        private readonly Type type;

        INavigationExecution instance;

        public NavigationElementViewModel(IRegionManager regionManager, Type type)
        {
            this.regionManager = regionManager;
            this.type = type;
            this.instance = (INavigationExecution)Activator.CreateInstance(this.Type);
            this.instance.SetRegionManager(this.regionManager);
        }

        public string Titel => this.instance.Title;

        public Type Type => this.type;

        public DelegateCommand NavigateCommand
        {
            get
            {
                return new DelegateCommand(
                    () =>
                        {
                            var methodInfo = this.Type.GetMethod("NavigateTo");
                            methodInfo.Invoke(this.instance, null);
                        });
            }
        }
    }
}