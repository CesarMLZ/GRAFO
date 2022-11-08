using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Node
    {
        //Attributes
        public int data;
        public List<Node> children = new List<Node>();
        public List<Node> father = new List<Node>();
        public Node(Graph graph)
        {
            //Assign automatically the node data starting with 0 and then increasing 1 by 1.
            data = graph.assignNodeData;
            graph.assignNodeData++;
        }
    }
}