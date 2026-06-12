# Table of Contents

- [1. Client and Server Lab](#client-and-server-lab)
- [2. react Lab](#react-Lab)
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


# react Lab



```JS 

import React, { useState, useEffect } from "react";

  

function App() {

  const [employee, setemployee] = useState([]);

  const [newname, setnewname] = useState("");

  useEffect(() => {

    fetch("https://jsonplaceholder.typicode.com/users")

      .then((response) => response.json())

      .then((data) => setemployee(data));

  }, []);

  

  const addemployee = () => {

    fetch("https://jsonplaceholder.typicode.com/users", {

      method: "POST",

      headers: { "Content-Type": "application/json" },

      body: JSON.stringify({ name: newname }),

    })

      .then((res) => res.json())

      .then((newEmp) => {

        setemployee([...employee, newEmp]);

        setnewname("");

      });

  };

  

  return (

    <p>

      {employee.map((emp) => (

        <p key={emp.id}>{emp.name}</p>

      ))}

      <input value={newname} onChange={(e) => setnewname(e.target.value)} />

      <button onClick={addemployee}>add</button>

    </p>

  );

}

  

export default App;
```
