using Infragistics.Themes;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using PrismOutlook.Core;
using System.Windows;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : XamRibbonWindow
    {
        private readonly IApplicationCommands _applicationCommands; // 중앙 집중 커맨드

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();
            this._applicationCommands = applicationCommands;
        }

        private void XamOutlookBar_SelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            var group = ((XamOutlookBar)sender).SelectedGroup as IOutlookBarGroup;
            if (group != null)
            {
                //TODO
                //이벤트 변경시 뷰도 동적 변경
                _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
            }
        }
    }
}
