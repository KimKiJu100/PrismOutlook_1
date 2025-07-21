using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using System;

namespace PrismOutlook.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private DelegateCommand<string> _navigateCommand;
        private readonly IRegionManager _regionManager;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand<string>(ExcuteNavigateCommand));

        public MainWindowViewModel(IRegionManager regionManager, IApplicationCommands applicationCommands)
        {
            this._regionManager = regionManager;
            applicationCommands.NavigateCommand.RegisterCommand(NavigateCommand);
        }

        private void ExcuteNavigateCommand(string navigationPath)
        {
            if (string.IsNullOrEmpty(navigationPath))
                throw new ArgumentNullException();
            this._regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }
    }
}
