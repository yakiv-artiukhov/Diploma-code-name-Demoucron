using omg.TopologicalSorting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace omg.TopologicalSorting.Utiles
{
    internal class GraphUtiles
    {
        public static VisGraphModel GraphToVisGraphModel(Graph graph)
        {
            if (graph == null) return new VisGraphModel();

            var visGraph = new VisGraphModel()
            {
                Nodes = new List<NodeModel>(),
                Edges = new List<EdgeModel>(),
            };

            foreach (var node in graph.Nodes)
                visGraph.Nodes.Add(new NodeModel()
                {
                    Id = node.Id,
                    Label = node.Label.ToString(),
                    Level = node.Level.ToString(),
                });

            foreach (var egde in graph.Edges)
                visGraph.Edges.Add(new EdgeModel()
                {
                    Id = egde.Id,
                    Label = egde.Label.ToString(),
                    From = egde.From.ToString(),
                    To = egde.To.ToString(),
                    Arrows = egde.Arrows,
                });

            return visGraph;
        }

        public static Graph VisGraphModelToGraph(VisGraphModel visGraph)
        {
            if (visGraph == null) return null;

            var nodes = new List<Node>();
            var edges = new List<Edge>();

            foreach (var node in visGraph.Nodes)
                nodes.Add(new Node()
                {
                    Id = node.Id,
                    Label = Int32.Parse(node.Label ?? "-1"),
                    Level = Int32.Parse(node.Level ?? "-1"),
                });

            foreach (var egde in visGraph.Edges)
                edges.Add(new Edge()
                {
                    Id = egde.Id,
                    Label = Int32.Parse(egde.Label ?? "-1"),
                    From = Int32.Parse(egde.From ?? "-1"),
                    To = Int32.Parse(egde.To ?? "-1"),
                    Arrows = "to",
                });

            return new Graph(nodes, edges);
        }
    }
}
