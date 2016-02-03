using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SecurityExample
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        [SecurityCritical]
        public Key GetTVRoomKey() { return null; }

       // [SecuritySafeCritical]
        //public void WatchTV()
        //{
        //    new TVPermission().Demand();
        //    using (Key key = GetTVRoomKey())
        //        PrisonGuard.OpenDoor(key);
        //}
    }

}
