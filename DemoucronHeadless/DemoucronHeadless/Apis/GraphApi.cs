using DemoucronHeadless.Models;
using DemoucronHeadless.TopologicalSorting;
using DemoucronHeadless.TopologicalSorting.Algorithms;
using DemoucronHeadless.Utiles;

namespace DemoucronHeadless.Apis;

public class GraphApi
{
    public static async Task<IResult> GetSavedUnorderedGraph()
    {
        using StreamReader streamReader = new(Constants.LocalApp.APP_DATA_PATH + Constants.LocalApp.PICKED_UNORDERED_GRAPH_FILENAME);
        var graphJson = streamReader.ReadToEnd();

        if (graphJson == null)
            return TypedResults.NotFound(new Graph(new List<Node>(), new List<Edge>()));

        var visGraph = graphJson.DeserializeFromString<VisGraphModel>() ?? new VisGraphModel() { Nodes = new List<NodeModel>(), Edges = new List<EdgeModel>() };
        return TypedResults.Ok(visGraph);
    }

    public static async Task<IResult> SortGraph(VisGraphModel visGraph)
    {
        if (visGraph == null) return TypedResults.NotFound();

        var graph = GraphUtiles.VisGraphModelToGraph(visGraph);

        var demoucron = new Demoucron();
        var sortedGraph = GraphTopologicalSorting.OrderGraphVerticesByLevels(graph, demoucron);
        var sortedVisGraph = GraphUtiles.GraphToVisGraphModel(sortedGraph);

        return TypedResults.Ok(sortedVisGraph);
    }

    public static async Task<IResult> SetInformationFlows(VisGraphModel visGraph)
    {
        if (visGraph == null) return TypedResults.NotFound();

        var graph = GraphUtiles.VisGraphModelToGraph(visGraph);
        GraphTopologicalSorting.SetGraphInformationFlows(graph);
        var sortedVisGraph = GraphUtiles.GraphToVisGraphModel(graph);

        return TypedResults.Ok(sortedVisGraph);
    }
}

