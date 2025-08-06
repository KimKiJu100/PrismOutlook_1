using Infragistics.Themes;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismOutlook.Core;
using PrismOutlook.Core.Region;
using PrismOutlook.Modeuls.Contacts;
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
        /// <summary>
        /// 어플리케이션의 시작 shell을 생성 함.
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            Infragistics.Themes.ThemeManager.ApplicationTheme = new Office2010BlueTheme();
            base.InitializeShell(shell);
        }
        /// <summary>
        /// DI 컨테이너에 싱글톤 서비스를 등록합니다.
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }

        /// <summary>
        /// 모듈 등록 함수
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<MailModule>();
            moduleCatalog.AddModule<ContactsModule>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    return base.CreateModuleCatalog();
        //}

        /// <summary>
        /// Prism은 기본 WPF 컨트롤에 대한 RegionAdapter를 자동 등록하지만, 
        /// 상용 컨트롤(Infragistics 등)은 수동으로 어댑터를 등록해야 하므로 별도로 정의합니다.
        /// </summary>
        /// <param name="regionAdapterMappings"></param>
        protected override void ConfigureRegionAdapterMappings(RegionAdapterMappings regionAdapterMappings)
        {
            base.ConfigureRegionAdapterMappings(regionAdapterMappings);
            regionAdapterMappings.RegisterMapping(typeof(XamOutlookBar), Container.Resolve<XamOutlookBarRegionAdapter>());
            regionAdapterMappings.RegisterMapping(typeof(XamRibbon), Container.Resolve<XamRibbonRegionAdapter>());
        }
        /// <summary>
        /// Region이 생성될 때 기본으로 적용될 RegionBehavior들을 구성합니다.
        /// Prism에서 제공하는 기본 동작 외에 사용자 정의 Behavior를 추가할 수 있습니다.
        /// </summary>
        /// <param name="regionBehaviors"></param>
        protected override void ConfigureDefaultRegionBehaviors(IRegionBehaviorFactory regionBehaviors)
        {
            base.ConfigureDefaultRegionBehaviors(regionBehaviors);

            regionBehaviors.AddIfMissing(DenpendentViewRegionBehavior.BehaviorKey, typeof(DenpendentViewRegionBehavior));
        }
    }
}
