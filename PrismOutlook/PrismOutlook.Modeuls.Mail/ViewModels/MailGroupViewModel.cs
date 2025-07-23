using Prism.Commands;
using Prism.Mvvm;
using PrismOutlook.Business;
using PrismOutlook.Core;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrismOutlook.Modeuls.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
        private IApplicationCommands _applicationCommands;
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items 
        {
            get { return _items; }
            set { SetProperty(ref _items, value); } 
        }

        private DelegateCommand<NavigationItem> _selectedCommand;
        public DelegateCommand<NavigationItem> SelectedCommand =>
            _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteCommandName));

        void ExecuteCommandName(NavigationItem navigationItem)
        {
            if(navigationItem != null)
                _applicationCommands.NavigateCommand.Execute(navigationItem.NavigationPath);

        }
        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            _applicationCommands = applicationCommands;
            GenerateMenu();
        }

        private void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();
            var root = new NavigationItem { Caption = "Personal Folder", NavigationPath = "MailList" };
            root.Items = new ObservableCollection<NavigationItem>();
            root.Items.Add(new NavigationItem { Caption = "Inbox", NavigationPath = "MailList?id=Inbox" });
            root.Items.Add(new NavigationItem { Caption = "Delete", NavigationPath = "MailList?id=Delete" });
            root.Items.Add(new NavigationItem { Caption = "Sent", NavigationPath = "MailList?id=Sent" });

            Items.Add(root);
        }
    }
}
