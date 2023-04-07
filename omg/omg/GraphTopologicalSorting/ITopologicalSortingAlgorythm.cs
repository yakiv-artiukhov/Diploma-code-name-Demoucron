using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omg.GraphTopologicalSorting
{
    internal interface ITopologicalSortingAlgorythm
    {
        public int[] Process(int[] adjacencyMatrixArray);

        public int[] Process(int[][] adjacencyMatrix);
    }
}
