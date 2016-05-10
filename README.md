# GSMSMSExampleConsoleApplication
```C# Application``` - Send and Receive SMS using GSM Offline
## Getting Started
Basic example on how to send and receive sms using gsm device
### List (list all GSM Devices)
```C#
GSMsms sms = new GSMsms();
List<GSMcom> coms = sms.List(); // returns all gsm devices
foreach(GSMcom com in coms ) {
  string portName = com.portName;
  string portDescription = com.portDescription;
  Console.WriteLine(portDescription + " " + portName);
}
```
### Search (get first GSM Device)
```C#
GSMsms sms = new GSMsms();
GSMcom com = sms.Search(); // return first gsm device found
Console.WriteLine(com.ToString()); // will print portDescription portName same behaviors as Console.WriteLine(portDescription + " " + portName);
```
### Connect (open serial port via first gsm device found)
```C#
GSMsms sms = new GSMsms();
sms.Connect();
```
### Disconnect (close and dispose serial port)
```C#
GSMsms sms = new GSMsms();
sms.Disconnect();
```
### Read (read sms)
```C#
GSMsms sms = new GSMsms();
if(sms.isConnected) {
  sms.Read();
}
```
### Send (send sms)
```C#
GSMsms sms = new GSMsms();
if(sms.isConnected) {
  sms.Send("NUMBER HERE", "MESSAGE HERE");
}
```
