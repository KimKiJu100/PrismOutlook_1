﻿using Prism.Ioc;
using Prism.Modularity;
using PrismOutlook.Modeuls.Mail;
using PrismOutlook.Views;
using System.Windows;

namespace PrismOutlook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return base.CreateModuleCatalog();
        //}
    }
}
