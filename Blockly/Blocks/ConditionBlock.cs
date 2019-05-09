using Blockly.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public abstract class ConditionBlock : Block
    {
        public ConditionBlock(string type) : base(type)
        {
        }

        public abstract Condition GetCondition();
    }
}
