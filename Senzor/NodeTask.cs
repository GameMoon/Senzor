using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senzor.Components
{
    public class NodeTask
    {
        public String nodeId { get; set; }
        public int threshHold { get; set; }
        public int inputChannel { get; set; }

        public  string operation { get; set; }

        public NodeTask(string nodeId,  int inputChannel, int threshHold, string operation)
        {
            this.nodeId = nodeId;
            this.threshHold = threshHold;
            this.inputChannel = inputChannel;
            this.operation = operation;
        }
        public string getString()
        {
            return String.Format("NodeID: {0}, InputChannel: {1}, ThreshHold: {2}, Operator: {3}", nodeId, inputChannel, threshHold,operation);
        }
    }
}
