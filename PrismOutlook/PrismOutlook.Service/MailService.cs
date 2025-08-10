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
        //더미 데이터 추가 API 데이터 모음
        static List<MailMessage> InboxItems = new List<MailMessage>
        {
            new MailMessage()
            {
                Id =1,
                From = "goodkkj96@gmail.com",
                To = new ObservableCollection<string>(){ "",""},
                Subject = "This the Test E-mail",
                Body = "This the body of an E-mail",
                DataSent = DateTime.Now
            },
            new MailMessage()
            {
                Id =2,
                From = "goodkkj96@gmail.com",
                To = new ObservableCollection<string>(){ "",""},
                Subject = "This the Test E-mail2",
                Body = "This the body of an E-mail2",
                DataSent = DateTime.Now.AddDays(-1)
            },
            new MailMessage()
            {
                Id =3,
                From = "goodkkj96@gmail.com",
                To = new ObservableCollection<string>(){ "",""},
                Subject = "This the Test E-mail3",
                Body = "This the body of an E-mail3",
                DataSent = DateTime.Now.AddDays(-2)
            }
        };

        static List<MailMessage> SentItems = new List<MailMessage>();
        static List<MailMessage> DeleteItems = new List<MailMessage>();

        public IList<MailMessage> GetInboxItems()
        {
            return InboxItems;
        }

        public IList<MailMessage> GetSentItems()
        {
            return SentItems;
        }

        public IList<MailMessage> GetDeleteItems()
        {
            return DeleteItems;
        }
    }
}
