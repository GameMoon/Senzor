using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class ConditionInput
    {
        public String NodeID { get; set; }
        public int Channel { get; set; }
        public int Value { get; set; }
        public ConditionInput(int value)
        {
            Value = value;
        }

        public ConditionInput(string nodeID, int channel)
        {
            NodeID = nodeID;
            Channel = channel;
        }
    }
}
