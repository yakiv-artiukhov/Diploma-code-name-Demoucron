using omg.GraphTopologicalSorting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace omg.GraphTopologicalSorting.Utiles
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
            var graph = new Graph(new List<Node>(), new List<Edge>());

            if (visGraph == null) return graph;

            foreach (var node in visGraph.Nodes)
                graph.Nodes.Add(new Node()
                {
                    Id = node.Id,
                    Label = Int32.Parse(node.Label),
                    Level = Int32.Parse(node.Level),
                });

            foreach (var egde in visGraph.Edges)
                graph.Edges.Add(new Edge()
                {
                    Id = egde.Id,
                    Label = Int32.Parse(egde.Label),
                    From = Int32.Parse(egde.From),
                    To = Int32.Parse(egde.To),
                    Arrows = egde.Arrows,
                });

            return graph;
        }
    }
}
