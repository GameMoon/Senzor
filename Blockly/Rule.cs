using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockly
{
    public class Rule
    {
        public List<Condition> Conditions { get { return conditions;  } set { conditions = value;  } }
        public List<Statement> Statements { get { return statements;  } set { statements = value;  } }

        [NonSerialized]
        public List<Condition> conditions = new List<Condition>();

        [NonSerialized]
        public List<Statement> statements = new List<Statement>();

    }
}
