using Blockly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class RuleManager
    {
        INodeManager _nodeManager;
        public RuleManager(INodeManager nodeManager)
        {
            _nodeManager = nodeManager;
        }
        public void check(Rule rule)
        {
            if (checkConditions(rule.Conditions))
            {
                setStatements(rule.Statements);
            }
        }
        private void setStatements(List<Statement> statements)
        {
            foreach(var statement in statements)
            {
                activate(statement);
            }
        }
        private void activate(Statement statement)
        {
             _nodeManager.SendMessage(WriteMessage.SetPin(statement.NodeID, statement.Channel,statement.State));
        }

        private bool checkConditions(List<Condition> conditions)
        {
            foreach (var condition in conditions)
            {
                if (!isMet(condition)) return false;
            }
            return true;
        }

        private bool isMet(Condition con)
        {
            int valueA = GetValue(con.Left);
            int valueB = GetValue(con.Right);

            if (con.Operator == "lt") return valueA < valueB;
            else if (con.Operator == "le") return valueA <= valueB;
            else if (con.Operator == "gt") return valueA > valueB;
            else if (con.Operator == "ge") return valueA >= valueB;
            else if (con.Operator == "eq") return valueA == valueB;
            else if (con.Operator == "ne") return valueA != valueB;
            else return false;
        }

        private int GetValue(ConditionInput nodeInput)
        {
            if (nodeInput.NodeID == null) return nodeInput.Value;
            else return _nodeManager.GetNode(nodeInput.NodeID).GetInput(nodeInput.Channel);
        }
    }
}
