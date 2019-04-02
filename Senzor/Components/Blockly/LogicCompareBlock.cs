using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senzor.Components.Blockly
{
    public class LogicCompareBlock : Block
    {
        public LogicCompareBlock() : base("logic_compare")
        {
            
        }
        public NodeInputBlock getNodeInput()
        {
            foreach(var block in children)
            {
                if (block.Type == "node_input") return Block.convert<NodeInputBlock>(block);
            }
            return null;
        }
        public int getThreshHoldValue()
        {
            foreach(var block in children)
            {
                if (block.Type == "math_number") return Int32.Parse(block.Value);
            }
            return -1;
        }

        public String getOperator()
        {
            if (Value.Contains("=")) return "eq";
            else if (Value.Contains("≠")) return "nequs";
            else if (Value.Contains("<")) return "lt";
            else if (Value.Contains("≤‏")) return "lt";
            else if (Value.Contains(">")) return "lt";
            else if (Value.Contains("≥")) return "lt";
            else return "";


        }
       
    }
}
