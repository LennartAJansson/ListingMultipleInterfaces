namespace UsingMultipleInterfaces.ViewModels
{
    using System.Collections.Generic;

    using Microsoft.Toolkit.Mvvm.ComponentModel;

    using UsingMultipleInterfaces.Services;

    public class MainViewModel : ObservableObject
    {
        private readonly IInterfaceService interfaceService;

        public IEnumerable<string?>? Interfaces
        {
            get => interfaces;
            set => SetProperty(ref interfaces, value);
        }
        private IEnumerable<string?>? interfaces;

        public MainViewModel(IInterfaceService interfaceService)
        {
            this.interfaceService = interfaceService;
            Interfaces = this.interfaceService.GetInterfaceVersions("UsingMultipleInterfaces.Interfaces.");
        }
    }
}
