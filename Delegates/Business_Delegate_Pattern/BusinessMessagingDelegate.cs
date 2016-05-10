using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
   public class BusinessMessagingDelegate
    {
       BusinessServiceLookUp lookUpService=new BusinessServiceLookUp();
       IMessagingService businesService;

       public string ServiceType { get; set; }

       public void Do(string message)
       {
           businesService = lookUpService.GetBusinessService(ServiceType);
           businesService.SendMessage(message);
       }
    }
}
