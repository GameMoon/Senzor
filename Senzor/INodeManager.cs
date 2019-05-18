using Senzor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senzor
{
    public interface INodeManager
    {
        List<Node> GetAll();
        void AddUpdateFunction(Action method);
    }
}
