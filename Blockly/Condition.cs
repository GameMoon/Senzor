using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class Condition
    {
        public string Operator { get; set; }
        //public string LeftJson { get => JsonConvert.SerializeObject(Left); }
        //public string RightJson { get => JsonConvert.SerializeObject(Left); }


        public ConditionInput Left { get; set; } = new ConditionInput();

        public ConditionInput Right { get; set; } = new ConditionInput();
    }
}
