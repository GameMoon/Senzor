using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public abstract class DefaultBlock : Block
    {
        public DefaultBlock(string type) : base(type) { }
        public override void Accept(IBlockVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
