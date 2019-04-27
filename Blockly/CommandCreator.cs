using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Blockly
{
    public class CommandCreator
    {
        private List<Block> blocks;
        //private List<NodeTask> tasks = new List<NodeTask>();
        public void setBlocks(List<Block> blocks) => this.blocks = blocks;
        public void generateCommands()
        {
          //  tasks.Clear();
            //visitor minta
          //  foreach(Block block in blocks)
           // {
               //printBlock(block);
               //Input parsing
              /* if (block.Type == "logic_compare")
               {
                    LogicCompareBlock logicBlock = Block.convert<LogicCompareBlock>(block);
                    int threshHold = logicBlock.getThreshHoldValue();
                    NodeInputBlock inputBlock = logicBlock.getNodeInput();
                    if(inputBlock != null) {
                        tasks.Add(new NodeTask(
                            inputBlock.getNodeID(),
                            inputBlock.getInputChannel(),
                            threshHold,
                            logicBlock.getOperator()
                            ));
                    }
               }*/
            //}
        }
        private void printBlock(Block block)
        {
            string blockParams = JsonConvert.SerializeObject(block);
            Console.WriteLine(blockParams);
        }
        public void showCommands()
        {
          /*  foreach(var task in tasks)
                Console.WriteLine(task.getString());*/
            
        }
    }
}
