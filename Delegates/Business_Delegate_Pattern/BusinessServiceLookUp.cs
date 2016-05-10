using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
    public  class BusinessServiceLookUp
    {
        public IMessagingService GetBusinessService(string serviceType)
        {
            if (serviceType.Equals("SMS"))
            {
                return new SMSMessagingService();
            }
            else
            {
                    return new MailMessagingService();
            }
        }
    }
}
