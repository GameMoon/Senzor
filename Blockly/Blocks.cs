using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class Blocks
    {
        private List<Block> _blocks = new List<Block>();

        public Blocks(List<Block> blocks)
        {
            AttachMultiple(blocks);
        }

        public void AttachMultiple(List<Block> blocks)
        {
            foreach(var newBlock in blocks)
            {
                Attach(newBlock);
            }
        }
        public void Attach(Block block)
        {
            if (block == null) return;
           _blocks.Add(block);
        }

        public void Accept(IBlockVisitor visitor)
        {
            foreach (var block in _blocks)
            {
                block.Accept(visitor);
            }
        }
    }
}
