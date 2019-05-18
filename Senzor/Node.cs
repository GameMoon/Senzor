using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senzor.Components
{
    public class Node
    {
        public string Id { get; set; }
        public List<NodeTask> tasks = new List<NodeTask>();
        public int[] input = new int[4];
        public int[] output = new int[4];

        public Node(string id) => Id = id;
        public void SetInput(int index, int value) { input[index] = value; }
        public int GetInput(int index) { return input[index]; }

        public void SetOutput(int index, int value) { output[index] = value; }
        public int GetOutput(int index) { return output[index];}

        public int[] GetInputAll() { return input; }
        public int[] GetOutputAll() { return output; }
       
    }
}
