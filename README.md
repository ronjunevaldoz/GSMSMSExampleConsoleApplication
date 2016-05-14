# GSMSMSExampleConsoleApplication
C# Application - Send and Receive SMS using GSM Offline
## Getting Started
Basic example on how to send and receive sms using gsm device.
Here is the tutorial link on youtube: https://www.youtube.com/watch?v=de881SCWXMs&list=PLfj229q5dYim6mwtdqjKlPDV5_bbWfsDz
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
if(sms.IsDeviceFound) { // if (com != null) {
  Console.WriteLine(com.ToString()); // will print portDescription portName same behaviors as Console.WriteLine(portDescription + " " + portName);
}
Console.WriteLine(sms.IsDeviceFound);
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
if(sms.IsConnected) {
  sms.Read();
}
```
### Send (send sms)
```C#
GSMsms sms = new GSMsms();
if(sms.IsConnected) {
  sms.Send("NUMBER HERE", "MESSAGE HERE");
}
```
