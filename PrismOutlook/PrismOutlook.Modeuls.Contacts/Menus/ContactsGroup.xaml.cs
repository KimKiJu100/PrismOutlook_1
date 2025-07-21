using Infragistics.Windows.OutlookBar;
using PrismOutlook.Core;
using System;

namespace PrismOutlook.Modeuls.Contacts.Menus
{
    /// <summary>
    /// ContactsGroup.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactsGroup : OutlookBarGroup, IOutlookBarGroup
    {
        public ContactsGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath => "ViewA";

    }
}
