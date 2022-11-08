using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Graph
    {
        //Attributes

        public List<Node> nodesList = new List<Node>();
        private List<Edge> edgesList = new List<Edge>();

        public int assignNodeData = 0;

        public int shortest = 0;

        public List<Node> nodeShortPath = new List<Node>();

        public List<Edge> shortestPathC = new List<Edge>();
        public bool firstTime = true;

        public int[] shortestPath = new int[10];

        //Methods
        public void insertNode(Node node)
        {
            //Adding the node into the list of nodes.
            foreach (Node nodes in nodesList)
            {
                if (node == nodes)
                {
                    Console.WriteLine("++++Cannot insert the same node more than two times+++++");
                    return;
                }
            }
            nodesList.Add(node);
        }
        public void deleteNode(Node node)
        {
            for (int i = 0; i < nodesList.Count; i++)
            {
                for (int k = 0; k < nodesList[i].children.Count; k++)
                {
                    if (nodesList[i].children[k] == node)
                    {
                        nodesList[i].children.RemoveAt(k);
                    }
                }
            }
            //Removing the node into the list of nodes.
            for (int i = 0; i < nodesList.Count; i++)
            {

                if (nodesList[i] == node)
                {
                    for (int k = 0; k > node.children.Count; k++)
                    {
                        nodesList[i].children.RemoveAt(k);
                    }
                    for (int k = 0; k < edgesList.Count; k++)
                    {
                        if (edgesList[k].initialNode == node || edgesList[k].finalNode == node)
                        {
                            edgesList.RemoveAt(k);
                        }
                    }
                    nodesList.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine("++++Node cannot be erased because it was already deleted++++");
        }
        public void insertEdge(Edge edge)
        {
            //Adding the edge into the list of edges.
            edgesList.Add(edge);
        }
        public void deleteEdge(Edge edge)
        {
            for (int i = 0; i < nodesList.Count; i++)
            {
                if (edge.initialNode == nodesList[i])
                {
                    for (int k = 0; k < nodesList[i].children.Count; k++)
                    {
                        if (edge.finalNode == nodesList[i].children[k])
                        {
                            nodesList[i].children.RemoveAt(k);
                        }
                    }
                }
            }
            //Remove into the list of edges the parameter edge inserted.
            for (int i = 0; i < edgesList.Count; i++)
            {
                if (edgesList[i] == edge)
                {
                    edgesList.RemoveAt(i);
                    return;
                }
            }
            Console.WriteLine("++++Edge cannot be erased because it was already deleted++++");
        }
        public void printGraphConnections()
        {
            int zeroCounter = 0;

            //Print first 2 lines.
            Console.WriteLine("Connections");
            Console.Write("   ");
            foreach (Node node in nodesList)
            {
                Console.Write(node.data + "  ");
            }
            Console.WriteLine();
            Console.Write("  ");
            foreach (Node node in nodesList)
            {
                Console.Write("---");
            }
            Console.WriteLine();

            //Transversing all nodes.
            for (int i = 0; i < nodesList.Count; i++)
            {
                Console.Write(nodesList[i].data + "| ");

                //Checking edges at nodes position.
                for (int j = 0; j < nodesList.Count; j++)
                {
                    foreach (Edge edge in edgesList)
                    {
                        if (edge.initialNode.data == nodesList[i].data && edge.finalNode.data == nodesList[j].data)
                        {
                            Console.Write(1 + "  ");
                            zeroCounter = zeroCounter + 1;
                        }
                    }
                    if (zeroCounter <= 0)
                    {
                        Console.Write(0 + "  ");
                    }
                    else
                    {
                        zeroCounter = zeroCounter - 1;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void printGraphWeights()
        {
            int zeroCounter = 0;

            //Print first 2 lines.
            Console.WriteLine("----------Weights matrix---------");
            Console.Write("   ");
            foreach (Node node in nodesList)
            {
                Console.Write(node.data + "  ");
            }
            Console.WriteLine();
            Console.Write("  ");
            foreach (Node node in nodesList)
            {
                Console.Write("---");
            }
            Console.WriteLine();

            //Transversing all nodes and edges to print them.
            for (int i = 0; i < nodesList.Count; i++)
            {
                Console.Write(nodesList[i].data + "| ");
                for (int j = 0; j < nodesList.Count; j++)
                {
                    foreach (Edge edge in edgesList)
                    {
                        if (edge.initialNode.data == nodesList[i].data && edge.finalNode.data == nodesList[j].data)
                        {
                            Console.Write(edge.weight + "  ");
                            zeroCounter = zeroCounter + 1;
                        }
                    }
                    if (zeroCounter <= 0)
                    {
                        Console.Write(0 + "  ");
                    }
                    else
                    {
                        zeroCounter = zeroCounter - 1;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public void transverseGraphBFS(Node node)
        {
            int[] values = new int[nodesList.Count];

            values[0] = node.data;

            foreach (Node nodes in node.children)
            {
                transverseGraphBFS(nodes, values);
            }
            Console.Write("\n" + "Transverse BFS method: (");
            for (int i = 0; i < values.Length; i++)
            {
                if (values.Length - 1 == i)
                {
                    Console.Write(values[i] + ")");
                }
                else
                {
                    Console.Write(values[i] + ", ");
                }

            }
        }
        public void transverseGraphBFS(Node node, int[] values)
        {
            if (!values.Contains(node.data))
            {
                for (int i = 1; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }

            foreach (Node nodes in node.children)
            {
                transverseGraphBFS(nodes, values);
            }
        }
        public void transverseGraphDFS(Node node)
        {
            int[] values = new int[nodesList.Count];

            foreach (Node nodes in node.children)
            {
                transverseGraphDFS(nodes, values);
            }

            if (!values.Contains(node.data))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }

            Console.Write("\n" + "Transverse DFS method: (");
            for (int i = 0; i < values.Length; i++)
            {
                if (values.Length - 1 == i)
                {
                    Console.Write(values[i] + ")");
                }
                else
                {
                    Console.Write(values[i] + ", ");
                }

            }
        }
        public void transverseGraphDFS(Node node, int[] values)
        {
            foreach (Node nodes in node.children)
            {
                transverseGraphDFS(nodes, values);
            }

            if (!values.Contains(node.data))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i] == 0)
                    {
                        values[i] = node.data;
                        break;
                    }
                }
            }
        }
        public void shortAlgorithm(Node initialNode, Node goal)
        {
            int maxNumb = 30000000;
            Edge edgeIn = new Edge();
            if (initialNode == goal)
            {
                Console.WriteLine("+++++ You are already in the node that are you searching for. ++++++");
                return;
            }
            foreach (Edge edges in edgesList)
            {
                if (edges.initialNode == initialNode)
                {

                    if (maxNumb > edges.weight)
                    {
                        maxNumb = edges.weight;
                        edgeIn = edges;
                        //Console.WriteLine(edges.weight);
                        //Edge bestPath = new Edge(initialNode, nodesChildren, edges.weight);
                    }

                }
            }
            Console.WriteLine(maxNumb);
            nodeShortPath.Add(edgeIn.initialNode);
            nodeShortPath.Add(edgeIn.finalNode);
            shortAlgorithm(edgeIn, goal);

            Console.Write("\n" + "Shortest path: (");
            int i = 0;
            foreach (Node nodes in nodeShortPath)
            {
                if (nodeShortPath.Count - 1 <= i)
                {
                    Console.Write(nodes.data + ")");
                }
                else
                {
                    Console.Write(nodes.data + ", ");
                }

                i++;
            }
        }
        public void shortAlgorithm(Edge edgeIn, Node goal)
        {
            int maxNumb = 30000;
            if (edgeIn.finalNode == goal)
            {
                Console.WriteLine("Process finished");
                return;
            }
            ///
            if (edgeIn.finalNode.children == null)
            {
                //Una nueva función debe comparar ahora los nodes iniciales en vez de los finales.
                shortAlgorithmInitial(edgeIn, goal, maxNumb);
                return;
            }
            ///
            foreach (Edge edges in edgesList)
            {
                if (edges.initialNode == edgeIn.finalNode)
                {

                    if (maxNumb > edges.weight)
                    {
                        maxNumb = edges.weight;
                        edgeIn = edges;
                        //Console.WriteLine(edges.weight);
                        //Edge bestPath = new Edge(initialNode, nodesChildren, edges.weight);
                    }

                }
            }
            Console.WriteLine(maxNumb);

            nodeShortPath.Add(edgeIn.finalNode);

            shortAlgorithm(edgeIn, goal);
        }
        public void shortAlgorithmDefinitive(Node initialNode, Node goal)
        {
            List<Edge> pathOfEdges = new List<Edge>();

            foreach (Edge edges in edgesList)
            {
                if (edges.initialNode == initialNode)
                {
                    pathOfEdges.Add(edges);

                    foreach (Node nodeChildren in initialNode.children)
                    {
                        if (nodeChildren == edges.finalNode)
                        {
                            shortAlgorithmDefinitive(nodeChildren, goal, pathOfEdges);
                        }
                    }
                    pathOfEdges.Remove(edges);

                }
            }
            Console.Write("\n" + "\n" + "Shortest definitive path : (");
            for (int i = 0; i < shortestPath.Length; i++)
            {
                if (i == shortestPath.Length - 1)
                {
                    Console.Write(shortestPath[i] + ")");
                }
                else
                {
                    Console.Write(shortestPath[i] + ", ");
                }

            }

        }
        public void shortAlgorithmDefinitive(Node nodeChildren, Node goal, List<Edge> pathOfEdges)
        {
            if (nodeChildren == goal)
            {
                if (firstTime == true)
                {
                    foreach (Edge edge in pathOfEdges)
                    {
                        for (int i = 0; i < shortestPath.Length; i++)
                        {
                            if (shortestPath[i] == 0)
                            {
                                shortestPath[i] = edge.weight;
                                break;
                            }
                        }
                    }
                    //shortestPath = pathOfEdges;
                    firstTime = false;
                }
                else if (pathSum(shortestPath) > pathSum(pathOfEdges))
                {
                    for (int j = 0; j < shortestPath.Length; j++)
                    {
                        if (shortestPath[j] != 0)
                        {
                            shortestPath[j] = 0;
                        }

                    }
                    foreach (Edge edge in pathOfEdges)
                    {
                        for (int i = 0; i < shortestPath.Length; i++)
                        {
                            if (shortestPath[i] == 0)
                            {
                                shortestPath[i] = edge.weight;
                                break;
                            }
                        }
                    }
                    //shortestPath = pathOfEdges;
                }
                return;
            }

                    foreach (Edge edges in edgesList)
                    {
                        if (edges.initialNode == nodeChildren)
                        {
                            pathOfEdges.Add(edges);

                            foreach (Node nodeChildrens in nodeChildren.children)
                            {
                                if (nodeChildrens == edges.finalNode)
                                {
                                    shortAlgorithmDefinitive(nodeChildrens, goal, pathOfEdges);
                                }
                            }
                            pathOfEdges.Remove(edges);

                        }
                    }
                }
                public int pathSum(List<Edge> path)
                {
                    int pathResult = 0;
                    foreach (Edge edge in path)
                    {
                        pathResult = edge.weight + pathResult;
                    }
                    return pathResult;
                }
                public int pathSum(int[] path)
                {
                    int pathResult = 0;
                    for (int i = 0; i < path.Length; i++)
                    {
                        pathResult = path[i] + pathResult;
                    }
                    return pathResult;
                }
                public void shortAlgorithmInitial(Edge edgeIn, Node goal, int maxNumb)
                {
                    if (edgeIn.finalNode == goal)
                    {
                        Console.WriteLine("Process finished");
                        return;
                    }

                    foreach (Edge edges in edgesList)
                    {
                        if (edges.initialNode == edgeIn.initialNode)
                        {
                            foreach (Node nodesChildren in edgeIn.initialNode.children)
                            {
                                if (maxNumb > edges.weight)
                                {
                                    maxNumb = edges.weight;
                                    edgeIn = edges;
                                    //Console.WriteLine(edges.weight);
                                    //Edge bestPath = new Edge(initialNode, nodesChildren, edges.weight);
                                }
                            }
                        }
                    }
                    Console.WriteLine(maxNumb);
                    shortAlgorithm(edgeIn, goal);
                }
            }
        }
    

