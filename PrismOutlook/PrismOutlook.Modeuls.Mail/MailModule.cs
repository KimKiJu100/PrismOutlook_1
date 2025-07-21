using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modeuls.Mail.Menus;
using PrismOutlook.Modeuls.Mail.ViewModels;
using PrismOutlook.Modeuls.Mail.Views;

namespace PrismOutlook.Modeuls.Mail
{
    public class MailModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MailModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this._regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
            this._regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));

            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();

            containerRegistry.RegisterForNavigation<MailList, MailListViewModel>();
        }
    }
}