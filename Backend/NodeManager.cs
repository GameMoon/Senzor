using Blockly;
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
        private List<Rule> rules = new List<Rule>();
        private RuleManager _ruleManager;

        Timer pollingTimer;

        public NodeManager(IUDPSocket udpSocket)
        {
            _ruleManager = new RuleManager(this);
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
        public void AddRule(Rule rule)
        {
            rules.Add(rule);
        }
        public void DeleteRule(int index)
        {
            rules.RemoveAt(index);
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
        public List<Rule> GetAllRules()
        {
            return rules;
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
        
        private void ProcessRules()
        {
            foreach(var rule in rules)
            {
                try
                {
                    _ruleManager.check(rule);
                }
                catch (NullReferenceException e) { System.Diagnostics.Debug.WriteLine("Node not found"); }
            }   
        }
      

        public void Update(Object source, ElapsedEventArgs e)
        {
            ParseMessage();
            Mainteance();
            ProcessRules();
            //_udpSocket.Send("hello there");
            //System.Diagnostics.Debug.WriteLine("test");
        }
    }
}
