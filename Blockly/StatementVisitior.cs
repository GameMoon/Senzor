using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockly.Blocks;

namespace Blockly
{
    public class StatementVisitior : IBlockVisitor
    {
        List<Statement> statements = new List<Statement>();

        public void Visit(ControlsIfBlock block)
        {
        }

        public void Visit(ConditionBlock block)
        {
        }

        public void Visit(NodeOutputBlock block)
        {
            var newStatement = block.getStatement();
            if(newStatement != null)
             statements.Add(newStatement);
        }

        public void Visit(Block block)
        {
        }

        public List<Statement> GetStatements()
        {
            return statements;
        }
    }
}
