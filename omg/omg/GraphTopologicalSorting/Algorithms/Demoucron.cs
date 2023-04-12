namespace omg.GraphTopologicalSorting.Algorithms
{
    internal class Demoucron : ITopologicalSortingAlgorythm
    {
        public int[] Process(int[,] adjacencyMatrix)
        {
            var nodesCount = adjacencyMatrix.GetLength(0);
            var nodesLevels = new int[nodesCount];
            var trackArray = new int[nodesCount];

            // initial track array
            for (int i = 0; i < nodesCount; i++)
            {
                var columnSum = 0;
                for (int j = 0; j < nodesCount; j++)
                {
                    columnSum += adjacencyMatrix[j, i];
                }
                trackArray[i] = columnSum;
            }

            //algorythm steps
            var sortedNodes = 0;
            var level = 0;

            while (sortedNodes < nodesCount)
            {
                var currentZeroSumNodesIndexes = new List<int>();
                for (int i = 0; i < trackArray.Length; i++)
                {
                    if (trackArray[i] == 0)
                        currentZeroSumNodesIndexes.Add(i);

                }
                foreach (int i in currentZeroSumNodesIndexes)
                {
                    trackArray[i] = -1;

                    for (int j = 0; j < nodesCount; j++)
                        trackArray[j] -= adjacencyMatrix[i, j];

                    nodesLevels[i] = level;
                    sortedNodes++;
                }
                level++;
            }

            return nodesLevels;
        }
    }
}
