namespace DemoucronHeadless.TopologicalSorting;

internal interface ITopologicalSortingAlgorythm
{
    public int[] Process(int[,] adjacencyMatrix);
}

