using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;
using PrismOutlook.Business;
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

        public string DefaultNavigationPath {
            get {
                var node = _dataTree.SelectionSettings.SelectedNodes[0] as XamDataTreeNode;
                if (node == null) return "MailList";

                var item = _dataTree.SelectedDataItems[0] as NavigationItem;
                if (item != null)
                    return item.NavigationPath;
                    
                return "MailList";
            }
        } 
    }
}
