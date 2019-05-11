using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class ListMessage : NodeMessage
    {
        public ListMessage(string nodeID, byte[] payload = null) : base(nodeID, "LIST", payload)
        {
        }

        public override void Process(INodeManager nodeManager)
        {
            //throw new NotImplementedException();
        }
    }
}
