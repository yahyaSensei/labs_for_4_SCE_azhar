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
        }
    }
}