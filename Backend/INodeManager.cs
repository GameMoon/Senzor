using Blockly;
using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public interface INodeManager
    {
       void AddNode(Node node);
        void AddRule(Rule rule);
       Node GetNode(string id);
       void SendMessage(NodeMessage nodeMessage);
       List<Node> GetAll();
        List<Rule> GetAllRules();

        void DeleteRule(int index);
     
    }
}
