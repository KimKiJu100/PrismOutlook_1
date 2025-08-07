using PrismOutlook.Business;
using PrismOutlook.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Service
{
    public class MailService : IMailService
    {
        //더미 데이터 추가 
        static List<MailMessage> InboxItems = new List<MailMessage>
        {
            new MailMessage()
            {
                Id =1,
                From = "goodkkj96@gmail.com",
                To = new ObservableCollection<string>(){ "",""},
            },
        };

        public IList<MailMessage> GetInboxItems()
        {
            throw new NotImplementedException();
        }

    }
}
