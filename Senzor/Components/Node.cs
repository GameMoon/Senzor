using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senzor.Components
{
    public class Node
    {
        public int Id { get; set; }
        public List<NodeTask> tasks = new List<NodeTask>();

    }
}
