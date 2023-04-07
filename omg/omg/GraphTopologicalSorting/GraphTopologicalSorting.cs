using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omg.GraphTopologicalSorting
{
    internal class GraphTopologicalSorting
    {
        public List<List<int>> GraphAdjacencyMatrixList { get; set; }

        public int[][] GraphAdjacencyMatrix { get; set; }

        public int[] GraphAdjacencyMatrixArray { get; set; }

        public ITopologicalSortingAlgorythm Algorythm { get; set; }

        public GraphTopologicalSorting(int[] graphAdjacencyMatrixArray, ITopologicalSortingAlgorythm algorythm)
        {
            GraphAdjacencyMatrixArray = graphAdjacencyMatrixArray;
            Algorythm = algorythm;
        }

        public GraphTopologicalSorting(List<List<int>> graphAdjacencyMatrixList, ITopologicalSortingAlgorythm algorythm)
        {
            GraphAdjacencyMatrixList = graphAdjacencyMatrixList;
            Algorythm = algorythm;
        }

        public GraphTopologicalSorting(int[][] graphAdjacencyMatrix, ITopologicalSortingAlgorythm algorythm)
        {
            GraphAdjacencyMatrix = graphAdjacencyMatrix;
            Algorythm = algorythm;
        }



        public Dictionary<int, List<int>> OrderGraphVerticesByLevels()
        {
            var graphVerticesByLevels = new Dictionary<int, List<int>>();

            int[] verticesLevelsArray;
            if (GraphAdjacencyMatrix != null)
            {
                verticesLevelsArray = Algorythm.Process(GraphAdjacencyMatrix);
            }
            else
            {
                verticesLevelsArray = Algorythm.Process(GraphAdjacencyMatrixArray);
            }
            
            for (int i = 0; i < verticesLevelsArray.Length; i++)
            {
                if (graphVerticesByLevels.ContainsKey(verticesLevelsArray[i]))
                    graphVerticesByLevels[verticesLevelsArray[i]].Add(i);
                else
                    graphVerticesByLevels[verticesLevelsArray[i]] = new List<int>() { i };
            }

            return graphVerticesByLevels;
        }
    }
}
