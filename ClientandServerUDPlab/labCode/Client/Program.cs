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
        }
    }
}