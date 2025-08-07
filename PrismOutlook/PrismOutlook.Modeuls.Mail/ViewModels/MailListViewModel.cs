using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Core;
using System;
using System.Collections.ObjectModel;
using System.Net.Mail;
using System.Windows;

namespace PrismOutlook.Modeuls.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private string _title = "Default";
        public string Title 
        {
            get { return _title; }
            set { SetProperty(ref _title, value); } 
        }

        private ObservableCollection<MailMessage> _filedMessage;
        public ObservableCollection<MailMessage> FiledMessage
        {
            get { return _filedMessage; }
            set { SetProperty(ref _filedMessage, value); }
        }

        public MailListViewModel()
        {
            
        }
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //딕셔너리의 키의 값을 찾는다.
            Title = navigationContext.Parameters.GetValue<string>("id");
        }
    }
}
