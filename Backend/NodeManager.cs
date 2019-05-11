using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Text;
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
            int index = nodes.FindIndex(f => f.Id == node.Id);
            if(index < 0) this.nodes.Add(node);
        } 
        public Node GetNode(string nodeid)
        {
            int index = nodes.FindIndex(f => f.Id == nodeid);
            if (index < 0) return null;
            return nodes[index];
        }

        public List<Node> GetAll()
        {
            return nodes;
        }
        public void SendMessage(NodeMessage msg)
        {
            _udpSocket.Send(msg.CreateString());
        }

        private void ParseMessage()
        {
            foreach(byte[] message in _udpSocket.GetMessages())
            {
                NodeMessage nodeMessage = NodeMessage.Parse(message);
                if (nodeMessage == null) continue;
                nodeMessage.Process(this);

               System.Diagnostics.Debug.WriteLine("Command: " + nodeMessage.Command);
               System.Diagnostics.Debug.WriteLine("NodeID: " + nodeMessage.NodeID);
               System.Diagnostics.Debug.WriteLine("Payload: " + BitConverter.ToString(nodeMessage.Payload));
            }
        }
        private void Mainteance()
        {
            SendMessage(new PingMessage());
            
        }
        

        public void Update(Object source, ElapsedEventArgs e)
        {
            ParseMessage();
            Mainteance();
            //_udpSocket.Send("hello there");
            //System.Diagnostics.Debug.WriteLine("test");
        }
    }
}
