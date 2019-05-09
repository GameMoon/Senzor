using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockly.Blocks;

namespace Blockly
{
    public class ConditionVisitor : IBlockVisitor
    {
        List<Condition> conditions = new List<Condition>();
        public List<Condition> GetConditions()
        {
            return conditions;
        }

        public void Visit(ConditionBlock block)
        {
            var newCond = block.GetCondition();
            if(newCond != null)
                conditions.Add(newCond);
        }

        public void Visit(ControlsIfBlock block)
        {
        }

        public void Visit(Block block)
        {
        }

        public void Visit(NodeOutputBlock block)
        {
        }
    }
}
