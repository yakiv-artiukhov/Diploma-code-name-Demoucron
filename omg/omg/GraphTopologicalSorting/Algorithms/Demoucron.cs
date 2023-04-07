namespace omg.GraphTopologicalSorting.Algorithms
{
    internal class Demoucron : ITopologicalSortingAlgorythm
    {


        public int[] Process(int[][] adjacencyMatrix)
        {
            return Process(TransformMatrixToArray(adjacencyMatrix));
        }

        public int[] Process(int[] adjacencyMatrixArray)
        {
            var vertexCount = (int)Math.Sqrt(adjacencyMatrixArray.Length);
            var vertexesLevelArray = new int[vertexCount];
            var trackArray = new int[vertexCount];

            // initial track array
            for (int i = 0; i < vertexCount; i++)
            {
                var columnSum = 0;
                for (int j = 0; j < vertexCount; j++)
                {
                    columnSum += adjacencyMatrixArray[i + vertexCount * j];
                }
                trackArray[i] = columnSum;
            }

            //algorythm steps
            var sortedVertex = 0;
            var level = 0;

            while (sortedVertex < vertexCount)
            {
                var currentZeroSumVertexIndexes = new List<int>();
                for (int i = 0; i < trackArray.Length; i++)
                {
                    if (trackArray[i] == 0)
                        currentZeroSumVertexIndexes.Add(i);

                }
                foreach (int index in currentZeroSumVertexIndexes)
                {
                    trackArray[index] = -1;

                    for (int j = index * vertexCount; j < index * vertexCount + vertexCount; j++)
                        trackArray[j % vertexCount] -= adjacencyMatrixArray[j];
                    
                    vertexesLevelArray[index] = level;
                    sortedVertex++;
                }
                level++;
            }

            return vertexesLevelArray;
        }

        private static int[] TransformMatrixToArray(int[][] matrix)
        {
            if (matrix == null || matrix.Length < 1)
                return Array.Empty<int>();

            var matrixArray = new int[matrix.Length * matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix[i].Length; j++)
                    matrixArray[i * matrix.Length + j] = matrix[i][j];

            return matrixArray;
        }

    }
}
