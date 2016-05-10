using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Delegate_Pattern
{
    public interface IMessagingService
    {
        void SendMessage(string message);
    }
}
