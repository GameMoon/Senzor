using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class Blocks
    {
        private List<Block> _blocks = new List<Block>();

        public void Attach(Block block)
        {
            _blocks.Add(block);
        }
        public void Accept(IVisitor visitor)
        {
            foreach (var block in _blocks) visitor.Visit(block);
        }
    }
}
