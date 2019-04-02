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

        public NodeTask(string nodeId,  int inputChannel, int threshHold)
        {
            this.nodeId = nodeId;
            this.threshHold = threshHold;
            this.inputChannel = inputChannel;
        }
        public string getString()
        {
            return String.Format("NodeID: {0}, InputChannel: {1}, ThreshHold: {2}", nodeId, inputChannel, threshHold);
        }
    }
}
