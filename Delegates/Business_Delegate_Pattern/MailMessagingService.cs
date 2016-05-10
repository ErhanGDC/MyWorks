using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
  public  class MailMessagingService :IMessagingService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
