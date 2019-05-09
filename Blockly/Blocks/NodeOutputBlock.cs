using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class NodeOutputBlock : CustomBlock
    {
        public NodeOutputBlock() : base("node_output")
        {

        }
        public String getNodeID()
        {
            foreach (var block in inputs)
            {
                if (block != null && block.Type == "node") return block.Value;
            }
            return null;
        }
        public int getOutputChannel()
        {
            foreach (var block in inputs)
            {
                if (block != null && block.Type == "output_selector") return Int32.Parse(block.Value);
            }
            return -1;
        }

        public int getState()
        {
            foreach (var block in inputs)
            {
                if (block != null && block.Type == "logic_boolean")
                {
                    if (block.Value == "TRUE") return 1;
                    else return 0;
                }
            }
            return -1;
        }

        public Statement getStatement()
        {
            Statement stm = new Statement();
            stm.Channel = getOutputChannel();
            stm.NodeID = getNodeID();
            stm.State = getState();
            return stm;
        }

        public override void Accept(IBlockVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
