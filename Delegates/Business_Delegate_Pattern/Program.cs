using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
             BusinessMessagingDelegate bsnDelegate=new BusinessMessagingDelegate();
            bsnDelegate.ServiceType = "SMS";

            Caller client=new Caller(bsnDelegate);

            string smsMesssage = "Son 4 hanesi 1111 olan kartınız dönem borcu -1000 Liradır. Bu kez ödeme bizden.";
            string emailMessage = "Son 4 hanesi 1111 olan kartınızı dönem ekstresi ektedir. Açınız şaşırınız.";
           
            client.Do(smsMesssage);

            bsnDelegate.ServiceType = "EMAIL";
            client.Do(emailMessage);
        }
    }
}
