using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockly.Blocks;

namespace Blockly
{
    public interface IBlockVisitor
    {
        void Visit(ControlsIfBlock block);
        void Visit(ConditionBlock block);
        void Visit(NodeOutputBlock block);
        void Visit(Block block);
    }
}
