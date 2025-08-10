using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismOutlook.Business;
using PrismOutlook.Core;
using PrismOutlook.Service.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace PrismOutlook.Modeuls.Mail.ViewModels
{
    public class MailListViewModel : ViewModelBase
    {
        private readonly IMailService _mailService;

        private string _title = "Default";
        public string Title 
        {
            get { return _title; }
            set { SetProperty(ref _title, value); } 
        }

        private ObservableCollection<MailMessage> _messages;

        public ObservableCollection<MailMessage> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        private MailMessage _selectedMessage;
        public MailMessage SelectedMessage
        {
            get { return _selectedMessage; }
            set { SetProperty(ref _selectedMessage, value); }
        }

        public MailListViewModel(IMailService mailService)
        {
            this._mailService = mailService;
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
            var folder = navigationContext.Parameters.GetValue<string>(FolderParameters.FolderKey);
            switch (folder)
            {
                case FolderParameters.Inbox:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetInboxItems());
                    break;
                case FolderParameters.Deleted:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetDeleteItems());
                    break;
                case FolderParameters.Sent:
                    Messages = new ObservableCollection<MailMessage>(_mailService.GetSentItems());
                    break;
                default:
                    break;
            }
        }
    }
}
