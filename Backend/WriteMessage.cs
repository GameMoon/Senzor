using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class WriteMessage : NodeMessage
    {
        public WriteMessage(string nodeID, byte[] payload = null) : base(nodeID, "WRTE", payload)
        {
        }
        public static WriteMessage SetPin(string nodeid, int pin,int state)
        {
            return new WriteMessage(nodeid, new byte[] { Convert.ToByte(pin), Convert.ToByte(state) });
        }
        public override void Process(INodeManager nodeManager)
        {
            Node selected = nodeManager.GetNode(NodeID);
            if(selected != null) selected.SetOutput(Payload[0], Payload[1]);
        }
    }
}
