using Infragistics.Controls.Menus;
using Infragistics.Windows.OutlookBar;
using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Modeuls.Mail.ViewModels;
using System.Windows;

namespace PrismOutlook.Modeuls.Mail.Menus
{
    /// <summary>
    /// MailGroup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MailGroup : OutlookBarGroup, IOutlookBarGroup
    {
        private NavigationItem _selectedItem;
        public MailGroup()
        {
            InitializeComponent();
            _dataTree.Loaded += _dataTree_Loaded;
        }
        private void _dataTree_Loaded(object sender, RoutedEventArgs e)
        {
            _dataTree.Loaded -= _dataTree_Loaded;

            var perentNode = _dataTree.Nodes[0];
            var nodeToSelect = perentNode.Nodes[0];
            nodeToSelect.IsSelected = true;
        }

        public string DefaultNavigationPath {
            get {
                var node = _dataTree.SelectionSettings.SelectedNodes[0] as XamDataTreeNode;
                if (node == null) return "MailList?folder=Default";

                var item = _dataTree.SelectedDataItems[0] as NavigationItem;
                if (item != null)
                    return item.NavigationPath;
                    
                return $"MailList?{FolderParameters.FolderKey}={FolderParameters.Inbox}";
            }
        } 
    }
}
