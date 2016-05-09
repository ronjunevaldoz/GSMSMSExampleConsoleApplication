using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Management;

namespace GSMSMSExampleConsoleApplication
{
    class GSMsms
    {
        private SerialPort gsmPort = null;
        private bool IsDeviceFound { get; set; } = false;
        public bool IsConnected { get; set; } = false;

        public GSMsms ()
        {
            gsmPort = new SerialPort();
        }

        public GSMcom[] List()
        {
            List<GSMcom> gsmCom = new List<GSMcom>();
            ConnectionOptions options = new ConnectionOptions();
            options.Impersonation = ImpersonationLevel.Impersonate;
            options.EnablePrivileges = true;
            string connString = $@"\\{Environment.MachineName}\root\cimv2";
            ManagementScope scope = new ManagementScope(connString,options);
            scope.Connect();

            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_POTSModem");
            ManagementObjectSearcher search = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection collection = search.Get();

            foreach(ManagementObject obj in collection)
            {
                string portName = obj["AttachedTo"].ToString();
                string portDescription = obj["Description"].ToString();

                if(portName != "")
                {
                    GSMcom com = new GSMcom();
                    com.Name = portName;
                    com.Description = portDescription;
                    gsmCom.Add(com);
                }
            }


            return gsmCom.ToArray();
        }

        public GSMcom Search()
        {
           
            //foreach (GSMcom com in List())
            //{
            //    Console.WriteLine(com.Description + " " + com.Name);
            //}
            // or better way using enumerator

            IEnumerator enumerator = List().GetEnumerator();
            GSMcom com = enumerator.MoveNext() ? (GSMcom) enumerator.Current : null;

            if(com == null)
            {
                IsDeviceFound = false;
                Console.WriteLine("No GSM device found!");
                //Disconnect();
            }
            else
            {
                IsDeviceFound = true;
                Console.WriteLine(com.ToString());
                //Connect();
            }

            return com;
        }

        public bool Connect()
        {
            if (gsmPort == null || IsConnected || gsmPort.IsOpen)
            {
                IsConnected = false;
            } else
            {
                GSMcom com = Search();
                if (com != null)
                {
                    try
                    {
                        gsmPort.PortName = com.Name;
                        gsmPort.BaudRate = 9600;
                        gsmPort.Parity = Parity.None;
                        gsmPort.DataBits = 8;
                        gsmPort.StopBits = StopBits.One;
                        gsmPort.Handshake = Handshake.RequestToSend;
                        gsmPort.DtrEnable = true;    // Data-terminal-ready
                        gsmPort.RtsEnable = true;    // Request-to-send
                        gsmPort.NewLine = Environment.NewLine;
                        gsmPort.Open();
                        IsConnected = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        IsConnected = false;
                    }
                } else
                {
                    IsConnected = false;
                }
               
            }
            return IsConnected;
        }

        public void Disconnect()
        {

        }


    }
}