# GSMSMSExampleConsoleApplication
C# ```Application``` - Send and Receive SMS using GSM Offline
## Getting Started
Basic example on how to send and receive sms using gsm device
### Search (search for GSM Devices)
```C#
GSMsms sms = new GSMsms();
sms.Search();
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
