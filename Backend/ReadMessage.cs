using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class ReadMessage : NodeMessage
    {
        public ReadMessage(string nodeID, byte[] payload = null) : base(nodeID, "READ", payload)
        {
        }

        public override void Process(INodeManager nodeManager)
        {
            for(int index = 0; index < Payload.Length; index++)
            {
                Node selected = nodeManager.GetNode(NodeID);
                if(selected != null) selected.SetInput(index, Payload[index]);
            }
        }
    }
}
