using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockly.Blocks;

namespace Blockly
{
    public class RuleVisitor : IBlockVisitor
    {
        public List<Rule> rules = new List<Rule>();

        public void Visit(ControlsIfBlock b)
        {
            rules.Add(b.getRule());
        }

        public void showRules()
        {
            foreach (Rule rule in rules)
            {
                Console.WriteLine(JsonConvert.SerializeObject(rule));
            }
        }

        public void Visit(Block block)
        {
        }

        public void Visit(ConditionBlock block)
        {
        }

        public void Visit(NodeOutputBlock block)
        {
        }
    }
}
