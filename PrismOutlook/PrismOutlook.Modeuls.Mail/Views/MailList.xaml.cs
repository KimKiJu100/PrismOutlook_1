using PrismOutlook.Core;
using PrismOutlook.Modeuls.Mail.Menus;
using System.Windows.Controls;

namespace PrismOutlook.Modeuls.Mail.Views
{
    /// <summary>
    /// Interaction logic for MailList
    /// </summary>
    /// 

    [DependentViewAttribute(RegionNames.RibbonRegion,typeof(HomeTab))]
    public partial class MailList : UserControl
    {
        public MailList()
        {
            InitializeComponent();
        }
    }
}
