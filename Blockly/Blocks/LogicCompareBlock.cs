using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class LogicCompareBlock : ConditionBlock
    {
        public LogicCompareBlock() : base("logic_compare")
        { }

        public Block getInput(int id)
        {
            return inputs[id];
        }
        public List<Block> getAllInput()
        {
            return inputs;
        }

        public String getOperator()
        {
            
            if (Value.Contains("=")) return "eq";
            else if (Value.Contains("≠")) return "ne";
            else if (Value.Contains("<")) return "lt";
            else if (Value.Contains("≤")) return "le";
            else if (Value.Contains(">")) return "gt";
            else if (Value.Contains("≥")) return "ge";
          
            return "";
        }

        public override Condition GetCondition()
        {
            List<Block> inputBlocks = getAllInput();
            Condition condition = new Condition();

            condition.Operator = getOperator();

            for (int index = 0; index < inputBlocks.Count; index++)
            {
                Block inputBlock = inputBlocks[index];
                if (inputBlock == null) return null;

                if (inputBlock.Type == "math_number")
                {
                    if (index == 0) condition.Left = new ConditionInput(Convert.ToInt32(inputBlock.Value));
                    else condition.Right = new ConditionInput(Convert.ToInt32(inputBlock.Value));
                }
                else if (inputBlock.Type == "node_input")
                {
                    NodeInputBlock nodeBlock = Block.convert<NodeInputBlock>(inputBlock);
                    if (index == 0) condition.Left = nodeBlock.getInput();
                    else condition.Right = nodeBlock.getInput();
                }
            }

            return condition;
        }


        public override void Accept(IBlockVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
