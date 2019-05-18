using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class NodeBlock : CustomBlock
    {

        public NodeBlock(List<string[]> nodes) : base("node")
        {
            if (nodes == null) return;
            foreach(var node in nodes)
            {
                _options.Add(node);
            }
        }
    }
}
