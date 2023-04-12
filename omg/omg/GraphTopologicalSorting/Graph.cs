using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omg.GraphTopologicalSorting
{
    internal class Graph
    {
        public List<Node> Nodes { get; set; }

        public List<Edge> Edges { get; set; }

        public int[,] AdjacencyMatrix { get; set; }

        public Graph(List<Node> nodes, List<Edge> edges)
        {
            Nodes = nodes ?? new List<Node>();
            Edges = edges ?? new List<Edge>();

            BuildAdjacencyMatrix(Nodes, Edges);
        }

        public Graph(int[,] adjacencyMatrix)
        {
            AdjacencyMatrix = adjacencyMatrix ?? new int[,] { };

            Nodes = new List<Node>();
            Edges = new List<Edge>();

            BuildNodesEdges(AdjacencyMatrix);
        }

        private Graph BuildNodesEdges(int[,] adjacencyMatrix)
        {
            if (adjacencyMatrix == null) return new Graph(new List<Node>(), new List<Edge>());
            Nodes ??= new List<Node>();
            Edges ??= new List<Edge>();

            var nodesCount = adjacencyMatrix.GetLength(0);

            for (int i = 0; i < nodesCount; i++)
            {
                Nodes.Add(new Node() { Id = i.ToString(), Label = i, Level = -1 });
                for (int j = 0; j < nodesCount; j++)
                    if (adjacencyMatrix[i, j] == 1)
                        Edges.Add(new Edge() { Id = string.Empty, Label = -1, From = i, To = j, Arrows = "to" });
            }

            return new Graph(Nodes, Edges);
        }

        private void BuildAdjacencyMatrix(List<Node> nodes, List<Edge> edges)
        {
            if (nodes == null || edges == null)
                AdjacencyMatrix = new int[,] { };
            else
            {
                AdjacencyMatrix = new int[nodes.Count, nodes.Count];

                for (int i = 0; i < edges.Count; i++)
                    AdjacencyMatrix[edges[i].From, edges[i].To] = 1;
            }
        }
    }


    public class Node
    {
        public string Id { get; set; }

        public int Label { get; set; }

        public int Level { get; set; }
    }

    public class Edge
    {
        public string Id { get; set; }

        public int Label { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public string Arrows { get; set; }
    }
}
