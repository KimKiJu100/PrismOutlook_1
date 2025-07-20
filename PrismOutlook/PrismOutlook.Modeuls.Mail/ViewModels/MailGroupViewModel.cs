using Prism.Mvvm;
using PrismOutlook.Business;
using System.Collections.ObjectModel;

namespace PrismOutlook.Modeuls.Mail.ViewModels
{
    public class MailGroupViewModel:BindableBase
    {
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items 
        {
            get { return _items; }
            set { SetProperty(ref _items, value); } 
        }
        public MailGroupViewModel()
        {
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();
            var root = new NavigationItem { Caption = "Personal Folder", NavigationPath = "Mail List" };
            root.Items = new ObservableCollection<NavigationItem>();
            root.Items.Add(new NavigationItem { Caption = "Inbox", NavigationPath = "" });
            root.Items.Add(new NavigationItem { Caption = "Delete", NavigationPath = "" });
            root.Items.Add(new NavigationItem { Caption = "Sent", NavigationPath = "" });

            Items.Add(root);
        }
    }
}
