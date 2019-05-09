using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Backend
{
    public class UDPSocket : IUDPSocket
    {
        private Task listenerTask;
        private List<byte[]> messages = new List<byte[]>();
        private readonly object messageLock = new object();
        private UdpClient udpClient = new UdpClient();

        public UDPSocket()
        {
            udpClient.Connect(IPAddress.Parse("192.168.0.255"), 1360);

            listenerTask = new Task(() => Listen());
            listenerTask.Start();
        }
        ~UDPSocket() { udpClient.Close(); }

        private void Listen()
        {
            UdpClient recvClient = new UdpClient(1360);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                    byte[] receiveBytes = recvClient.Receive(ref endPoint);
                    lock (messageLock)
                    {
                        messages.Add(receiveBytes);
                    }
                    string receiveString = Encoding.ASCII.GetString(receiveBytes);
                    System.Diagnostics.Debug.WriteLine(receiveString);
            }
        }
        public void Send(string message)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            udpClient.Send(sendBytes, sendBytes.Length);
        }

        public List<byte[]> GetMessages()
        {
            List<byte[]> tempMessage;
            lock (messageLock)
            {
                tempMessage = new List<byte[]>(messages);
                messages.Clear();
            }
            return tempMessage;
        }
    }
}
