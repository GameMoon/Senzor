using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly.Blocks
{
    public class ControlsIfBlock : DefaultBlock
    {
        public ControlsIfBlock() : base("controls_if")
        { }

        public override void Accept(IBlockVisitor visitor)
        {
            visitor.Visit(this);
        }
        public Rule getRule()
        {
            var rule = new Rule();
            rule.Conditions = GetConditions();
            rule.Statements = GetStatements();
            return rule;
        }
        public List<Condition> GetConditions()
        {
            Blocks inputBlocks = new Blocks(this.Inputs);
            ConditionVisitor conditionVisitor = new ConditionVisitor();
            inputBlocks.Accept(conditionVisitor);
            return conditionVisitor.GetConditions();
        }
        public List<Statement> GetStatements()
        {
            Blocks inputBlocks = new Blocks(this.Inputs);
            StatementVisitior statementVisitior = new StatementVisitior();
            inputBlocks.Accept(statementVisitior);
            return statementVisitior.GetStatements();
        }
    }
}
