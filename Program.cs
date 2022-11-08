using ConsoleApp2;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {

        Graph graph = new Graph();

        //Creating Nodes.
        Node n0 = new Node(graph);
        Node n1 = new Node(graph);
        Node n2 = new Node(graph);
        Node n3 = new Node(graph);
        Node n4 = new Node(graph);
        Node n5 = new Node(graph);
        Node n6 = new Node(graph);
        Node n7 = new Node(graph);
        Node n8 = new Node(graph);
        Node n9 = new Node(graph);
        Node n10 = new Node(graph);
        Node n11 = new Node(graph);
        Node n12 = new Node(graph);

        //Creating Edges.
        Edge e1 = new Edge(n0, n1, 5);
        Edge e2 = new Edge(n0, n2, 7);
        Edge e3 = new Edge(n0, n3, 8);
        Edge e4 = new Edge(n2, n4, 9);
        Edge e5 = new Edge(n2, n5, 4);
        Edge e6 = new Edge(n3, n6, 6);
        Edge e7 = new Edge(n3, n7, 4);
        Edge e8 = new Edge(n3, n8, 2);
        Edge e9 = new Edge(n8, n9, 1);
        Edge e10 = new Edge(n9, n10, 9);
        Edge e11 = new Edge(n9, n11, 4);

        Edge e12 = new Edge(n1, n12, 12);
        Edge e13 = new Edge(n4, n12, 15);
        Edge e14 = new Edge(n5, n12, 6);
        Edge e15 = new Edge(n6, n12, 9);
        Edge e16 = new Edge(n7, n12, 10);
        Edge e17 = new Edge(n10, n12, 6);
        Edge e18 = new Edge(n11, n12, 7);

        //Adding nodes to the graph.
        graph.insertNode(n0);
        graph.insertNode(n1);
        graph.insertNode(n2);
        graph.insertNode(n3);
        graph.insertNode(n4);
        graph.insertNode(n5);
        graph.insertNode(n6);
        graph.insertNode(n7);
        graph.insertNode(n8);
        graph.insertNode(n9);
        graph.insertNode(n10);
        graph.insertNode(n11);
        graph.insertNode(n12);

        //Adding edges to the graph.
        graph.insertEdge(e1);
        graph.insertEdge(e2);
        graph.insertEdge(e3);
        graph.insertEdge(e4);
        graph.insertEdge(e5);
        graph.insertEdge(e6);
        graph.insertEdge(e7);
        graph.insertEdge(e8);
        graph.insertEdge(e9);
        graph.insertEdge(e10);
        graph.insertEdge(e11);
        graph.insertEdge(e12);
        graph.insertEdge(e13);
        graph.insertEdge(e14);
        graph.insertEdge(e15);
        graph.insertEdge(e16);
        graph.insertEdge(e17);
        graph.insertEdge(e18);
        //Deleting nodes.
        //graph.deleteNode(n8);
        //graph.deleteNode(n4);
        //graph.deleteNode(n1);
        //graph.deleteNode(n3);

        //Deleting edges.
        //graph.deleteEdge(e1);
        //graph.deleteEdge(e8);

        //Print graph.
        graph.printGraphConnections();
        //graph.printGraphWeights();

        //Transverse

        graph.transverseGraphBFS(n0);
        graph.transverseGraphDFS(n0);

        //Short algorithm
        //graph.shortAlgorithm(n0, n12);
        graph.shortAlgorithmDefinitive(n0, n12);
    }
}