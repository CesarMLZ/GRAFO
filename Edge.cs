using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2
{
    internal class Edge
    {
        //Attributes
        public Node initialNode;
        public Node finalNode;
        public int weight;
        public Edge(Node initialNode, Node finalNode, int weight)
        {
            if (initialNode.data == finalNode.data)
            {
                Console.WriteLine("+++++Connecting a node with itself is forbitten.+++++");
                return;
            }
            //Assigning edge values.
            this.initialNode = initialNode;
            this.finalNode = finalNode;
            this.weight = weight;

            this.initialNode.children.Add(finalNode);
            this.finalNode.father.Add(initialNode);
        }
        public Edge()
        {

        }
    }
}