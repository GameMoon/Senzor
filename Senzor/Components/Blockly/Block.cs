
using System;
using System.Collections.Generic;

namespace Senzor.Components.Blockly
{
    public class Block
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String ParentId { get; set; }
        public String Value { get; set; }
    
        public List<String> ChildrenIds
        {
            get { return childrenIds; }
            set { childrenIds = value;}
        }
        public List<String> childrenIds;
        public List<Block> Children
        {
            get { return children; }
            set { children = value; }
        }
        public List<Block> children;

        public Block(string type) => Type = type;

        public static T convert<T>(Block b)
        {
            T logicCompareBlock;
            logicCompareBlock = AutoMapper.Mapper.Map<T>(b);
            return logicCompareBlock;
        }
    }
}
