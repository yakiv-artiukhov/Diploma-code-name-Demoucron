namespace DemoucronHeadless.TopologicalSorting;

internal class GraphTopologicalSorting
{
    public static Graph OrderGraphVerticesByLevels(Graph graph, ITopologicalSortingAlgorythm algorythm)
    {
        if (graph == null) throw new ArgumentNullException(nameof(graph), "graph can not be null");
        if (algorythm == null) throw new ArgumentNullException(nameof(algorythm), $"algorythm cannot be null");

        var nodesLevels = algorythm.Process(graph.AdjacencyMatrix);
        for (int i = 0; i < nodesLevels.Length; i++)
        {
            var node = graph.Nodes.Where(x => x.Id == i).FirstOrDefault();
            if (node != null)
                node.Level = nodesLevels[i];
        }

        return graph;
    }

    public static void SetGraphInformationFlows(Graph graph) 
    {
        if (graph == null) throw new ArgumentNullException(nameof(graph), "graph can not be null");

        for (int i = 0; i < graph.Edges.Count; i++)
            graph.Edges[i].Label = i.ToString();
    }
}

