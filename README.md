# Table of Contents

- [1. Client and Server Lab](#client-and-server-lab)
# client and server lab
## first step create a folder

```bash
mkdir labcode
cd labcode
```
## second step initiate projects

```bash
dotnet new console -o Server
dotnet new console -o client
```
## third step open VScode or any IDE or editor like nano

```bash
code .
```

## fourth step add codes to program.cs files in two folders

### server folder
```CS
using System;

using System.Net;

using System.Net.Sockets;

using System.Text;

  

class PacketServer

{

static void Main()

{

UdpClient client = new UdpClient(50000);

IPEndPoint receivePoint = new IPEndPoint(IPAddress.Any, 0);

  

Console.WriteLine("Server started. Waiting for packets...");

  

while (true)

{

byte[] data = client.Receive(ref receivePoint);

string strData = Encoding.ASCII.GetString(data);

Console.WriteLine($"Received from {receivePoint}: {strData}");

  

client.Send(data, data.Length, receivePoint);

Console.WriteLine("Packet echoed back.");

}}}
```

### client folder
```CS
using System;

using System.Net.Sockets;

using System.Text;

  

class PacketClient

{

static void Main()

{

UdpClient client = new UdpClient();

Console.WriteLine("Type a message and press Enter:");

  

while (true)

{

string message = Console.ReadLine();

byte[] data = Encoding.ASCII.GetBytes(message);

  

client.Send(data, data.Length, "127.0.0.1", 50000);

Console.WriteLine("Packet sent.");
}}}
```

## last step run program

open terminal or powershell or CMD in sperated windows 


### server terminal
```bash
cd Server

dotnet run
```

### client terminal

```bash
cd Client

dotnet run
```
