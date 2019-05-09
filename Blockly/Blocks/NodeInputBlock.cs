using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class NodeInputBlock : CustomBlock
    {
        public NodeInputBlock() : base("node_input")
        {

        }
        public String getNodeID()
        {
            foreach(var block in inputs)
            {
                if (block.Type == "node") return block.Value;
            }
            return null;
        }
        public int getInputChannel()
        {
            foreach(var block in inputs)
            {
                if (block.Type == "sensor") return Int32.Parse(block.Value);
            }
            return -1;
        }

        public ConditionInput getInput()
        {
            return new ConditionInput(getNodeID(), getInputChannel());
        }

    }
}
