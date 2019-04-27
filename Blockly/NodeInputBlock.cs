using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class NodeInputBlock : Block
    {
        public NodeInputBlock() : base("node_input")
        {

        }
        public String getNodeID()
        {
            foreach(var block in children)
            {
                if (block.Type == "sensor") return block.Value;
            }
            return null;
        }
        public int getInputChannel()
        {
            foreach(var block in children)
            {
                if (block.Type == "sensor") return Int32.Parse(block.Value);
            }
            return -1;
        }
    }
}
