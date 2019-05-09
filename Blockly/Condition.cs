using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class Condition
    {
        public String Operator { get; set; }
        public ConditionInput Left { get; set; }
        public ConditionInput Right { get; set; }
    }
}
