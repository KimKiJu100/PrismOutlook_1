using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modeuls.Mail.Menus;
using PrismOutlook.Modeuls.Mail.ViewModels;
using PrismOutlook.Modeuls.Mail.Views;
using PrismOutlook.Service;
using PrismOutlook.Service.Interfaces;

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
            //삭제해야되나?
            //this._regionManager.RegisterViewWithRegion(RegionNames.RibbonRegion, typeof(HomeTab));
            this._regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(MailGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ViewModelLocationProvider.Register<MailGroup, MailGroupViewModel>();

            containerRegistry.RegisterForNavigation<MailList, MailListViewModel>();

            //서비스 등록
            containerRegistry.RegisterSingleton<IMailService,MailService>();
        }
    }
}