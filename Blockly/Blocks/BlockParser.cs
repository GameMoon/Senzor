using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class BlockParser
    {
        public static T createObject<T>(JToken jBlock)
        {
            return jBlock.ToObject<T>();
        } 

        public static Block parse(JToken jBlock)
        {
            string type = jBlock["type"].ToString();
            if (type == "controls_if") return createObject<ControlsIfBlock>(jBlock);
            else if (type == "logic_compare") return createObject<LogicCompareBlock>(jBlock);
            else if (type == "logic_boolean") return createObject<LogicBooleanBlock>(jBlock);
            else if (type == "logic_operation") return createObject<LogicOperationBlock>(jBlock);
            else if (type == "math_number") return createObject<MathNumberBlock>(jBlock);
            else if (type == "node") return createObject<NodeBlock>(jBlock);
            else if (type == "node_input") return createObject<NodeInputBlock>(jBlock);
            else if (type == "sensor") return createObject<SensorBlock>(jBlock);
            else if (type == "node_output") return createObject<NodeOutputBlock>(jBlock);
            else if (type == "output_selector") return createObject<OutputSelectorBlock>(jBlock);
            else return null;
        }


    }
}
