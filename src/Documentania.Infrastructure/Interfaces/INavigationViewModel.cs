// // --------------------------------------------------------------------------------------------------------------------
// // <copyright file="INavigationViewModel.cs" company="BaerDev">
// // Copyright (c) BaerDev. All rights reserved.
// // </copyright>
// // <summary>
// // The file 'INavigationViewModel.cs'.
// // </summary>
// // --------------------------------------------------------------------------------------------------------------------
namespace Documentania.Infrastructure.Interfaces
{
    using Prism.Commands;

    public interface INavigationViewModel
    {
        DelegateCommand NavigateCommand { get; }

        string Title { get; }
    }
}