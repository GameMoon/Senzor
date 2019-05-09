using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Backend
{
    public class NodeManager : INodeManager
    {
        private readonly IUDPSocket _udpSocket;
        private List<Node> nodes = new List<Node>();
        Timer pollingTimer;

        public NodeManager(IUDPSocket udpSocket)
        {
            _udpSocket = udpSocket;
            pollingTimer = new Timer(1000);
            pollingTimer.Elapsed += Update;
            pollingTimer.AutoReset = true;
            pollingTimer.Enabled = true;
        }
        public void AddNode(Node node)
        {
            this.nodes.Add(node);
        }

        public List<Node> GetAll()
        {
            return nodes;
        }
        public void parseMessages()
        {
            foreach(byte[] message in _udpSocket.GetMessages())
            {
                NodeMessage nodeMessage = NodeMessage.Parse(message);
                if (nodeMessage == null) continue;
                System.Diagnostics.Debug.WriteLine("Command: " + nodeMessage.Command);
                System.Diagnostics.Debug.WriteLine("NodeID: " + nodeMessage.NodeID);
                System.Diagnostics.Debug.WriteLine("Payload: " + Encoding.ASCII.GetString(nodeMessage.Payload));
            }
        }

        public void Update(Object source, ElapsedEventArgs e)
        {
            parseMessages();
            //_udpSocket.Send("hello there");
            //System.Diagnostics.Debug.WriteLine("test");
        }
    }
}
