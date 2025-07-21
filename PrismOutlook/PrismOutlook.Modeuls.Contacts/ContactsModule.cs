using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Modeuls.Contacts.Menus;
using PrismOutlook.Modeuls.Contacts.ViewModels;
using PrismOutlook.Modeuls.Contacts.Views;

namespace PrismOutlook.Modeuls.Contacts
{
    public class ContactsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ContactsModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            this._regionManager.RegisterViewWithRegion(RegionNames.OutlookGroupRegion, typeof(ContactsGroup));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
        }
    }
}