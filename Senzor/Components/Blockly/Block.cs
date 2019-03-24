
using System;
using System.Collections.Generic;

namespace Senzor.Components.Blockly
{
    public class Block
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String ParentId { get; set; }

        public List<String> Children
        {
            get { return children; }
            set { children = value;}
        }
        public List<String> children;

        public Block(string type) => Type = type;

    }
}
