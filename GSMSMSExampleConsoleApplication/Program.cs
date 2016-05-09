using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSMSMSExampleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            GSMsms sms = new GSMsms();

            //sms.Search();
            sms.Connect();
            Console.WriteLine(sms.IsConnected);
            //sms.Disconnect();
            //Console.WriteLine(sms.IsConnected);
            // I will plug my gsm device

            // Replug gsm device or sim card
            if (sms.IsConnected)
            {
                //sms.Read();
                sms.Send("222", "BAL"); // THIS IS NOT RECOMMENDED, SOMETIMES GLOBE RESPONSE IS TAKING TOO LONG, I JUST USE THIS BECAUSE I DONT HAVE CREDIT
            }

            Console.Read();
        }
    }
}
