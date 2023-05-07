using DemoucronHeadless.Models;
using DemoucronHeadless.TopologicalSorting;

namespace DemoucronHeadless.Utiles;

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
                Level = node.Level,
            });

        foreach (var egde in graph.Edges)
            visGraph.Edges.Add(new EdgeModel()
            {
                Id = egde.Id,
                Label = egde.Label.ToString(),
                From = egde.From,
                To = egde.To,
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
                Label = node.Label,
                Level = node.Level,
            });

        foreach (var egde in visGraph.Edges)
            edges.Add(new Edge()
            {
                Id = egde.Id,
                Label = "",
                From = egde.From,
                To = egde.To,
                Arrows = "to",
            });

        return new Graph(nodes, edges);
    }
}
