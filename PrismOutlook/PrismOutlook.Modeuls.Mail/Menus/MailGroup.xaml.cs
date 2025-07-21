using Infragistics.Windows.OutlookBar;
using PrismOutlook.Core;

namespace PrismOutlook.Modeuls.Mail.Menus
{
    /// <summary>
    /// MailGroup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath => "MailList";
    }
}
