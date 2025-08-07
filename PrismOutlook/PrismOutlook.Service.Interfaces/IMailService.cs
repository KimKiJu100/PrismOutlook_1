using PrismOutlook.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismOutlook.Service.Interfaces
{
    public interface IMailService
    {
        IList<MailMessage> GetInboxItems();
    }
}
