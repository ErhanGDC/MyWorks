using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
    public class Caller
    {
        BusinessMessagingDelegate _businessService;

        public Caller(BusinessMessagingDelegate businessService)
        {
            _businessService = businessService;
        }

        public void Do(string message)
        {
            _businessService.Do(message);
        }
    }
}
