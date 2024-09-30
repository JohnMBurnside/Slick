using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
namespace Slick.Classes
{
    public class DawnDuskCalc
    {
        private static readonly string apiUrl = "https://api.sunrise-sunset.org/json";
        public DawnDuskCalc()
        {
            // Check internet connection
            if(PingAPI())
            {

                GetInfo();
            }
            else
                Debug.WriteLine("No connection");
        }
        private bool PingAPI()
        {
            try
            {
                using (Ping ping = new Ping())
                {
                    PingReply reply = ping.Send("104.21.38.135", 1000);
                    return reply.Status == IPStatus.Success;
                }
            }
            catch
                { return false; }
        }
        private void GetInfo()
        {
            
        }
    }
}
