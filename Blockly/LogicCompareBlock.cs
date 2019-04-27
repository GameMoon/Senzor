using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockly
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
            UnicodeEncoding unicode = new UnicodeEncoding();
            
            if (Value.Contains("=")) return "eq";
            else if (Value.Contains("≠")) return "ne";

            if(children[0].Type == "node_input") { 
                if (Value.Contains("<")) return "lt";
                else if (Value.Contains("≤")) return "le";
                else if (Value.Contains(">")) return "gt";
                else if (Value.Contains("≥")) return "ge";
            }
            else
            {
                if (Value.Contains("<")) return "gt";
                else if (Value.Contains("≤")) return "ge";
                else if (Value.Contains(">")) return "lt";
                else if (Value.Contains("≥")) return "le";
            }

            return "";
        }
       
    }
}
