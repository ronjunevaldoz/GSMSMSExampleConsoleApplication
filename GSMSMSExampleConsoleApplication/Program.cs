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


            Console.Read();
        }
    }
}
