
using System;
using System.Collections.Generic;

namespace Blockly.Blocks
{
    public abstract class Block
    {
        public String Id { get; set; }
        public String Type { get; set; }
        public String ParentId { get; set; }
        public String Value { get; set; }

        public List<String> InputIds
        {
            get { return inputIds; }
            set { inputIds = value; }
        }
        public List<String> inputIds;

        public List<Block> Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }
        public List<Block> inputs;

        public Block(string type) => Type = type;

        public static T convert<T>(Block b)
        {
            T customBlock;
            customBlock = AutoMapper.Mapper.Map<T>(b);
            return customBlock;
        }
        public abstract void Accept(IBlockVisitor visitor);
    }
}
