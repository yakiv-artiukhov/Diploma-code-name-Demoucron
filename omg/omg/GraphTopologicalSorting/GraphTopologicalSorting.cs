using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace omg.GraphTopologicalSorting
{
    internal class GraphTopologicalSorting
    {
        public static Graph OrderGraphVerticesByLevels(Graph graph, ITopologicalSortingAlgorythm algorythm)
        {
            if (graph == null) throw new ArgumentNullException(nameof(graph), "graph can not be null");
            if (algorythm == null) throw new ArgumentNullException(nameof(algorythm), $"algorythm cannot be null");

            var nodesLevels = algorythm.Process(graph.AdjacencyMatrix);
            for (int i = 0; i < nodesLevels.Length; i++)
            {
                var node = graph.Nodes.Where(x => x.Label == i).FirstOrDefault();
                if (node != null)
                    node.Level = nodesLevels[i];
            }

            return graph;
        }
    }
}
