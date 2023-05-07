using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace omg.TopologicalSorting
{
    internal interface ITopologicalSortingAlgorythm
    {
        public int[] Process(int[,] adjacencyMatrix);
    }
}
