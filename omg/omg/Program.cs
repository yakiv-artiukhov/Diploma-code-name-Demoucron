using omg.TopologicalSorting;
using omg.TopologicalSorting.Algorithms;
using omg.TopologicalSorting.Models;
using omg.TopologicalSorting.Utiles;
using System.Net.Security;

namespace omg
{
    internal class Program
    {
        private const string APP_DATA_PATH = "C:\\Users\\38067\\source\\repos\\dimploma-code-name-demoucron\\app\\app-data\\";
        private const string PICKED_UNORDERED_GRAPH_FILENAME = "picked-unordered-graph.json";
        private static readonly string PICKED_ORDERED_GRAPH_FILENAME = "picked-ordered-graph.json";

        static void Main()
        {
            var demoucron = new Demoucron();

            var graph = ImportGraphFromJson(PICKED_UNORDERED_GRAPH_FILENAME, APP_DATA_PATH);
            var orderedGraph =  GraphTopologicalSorting.OrderGraphVerticesByLevels(graph, demoucron);
            if (orderedGraph != null )
                ExportGraphToJson(orderedGraph, PICKED_ORDERED_GRAPH_FILENAME, APP_DATA_PATH);

            //Console.WriteLine();
        }


        public static Graph ImportGraphFromJson(string name, string path = "")
        {
            var fullPath = path + name;
            using StreamReader streamReader = new(fullPath);
            var graphJson = streamReader.ReadToEnd();

            if (graphJson == null)
                return new Graph(new List<Node>(), new List<Edge>());

            var visGraph = graphJson.DeserializeFromString<VisGraphModel>() ?? new VisGraphModel() { Nodes = new List<NodeModel>(), Edges = new List<EdgeModel>() };
            return GraphUtiles.VisGraphModelToGraph(visGraph);
        }

        public static void ExportGraphToJson(Graph graph, string name, string path = "")
        {
            var visGraph = GraphUtiles.GraphToVisGraphModel(graph);
            var visGraphJson = visGraph.SerializeObject();

            var fullPath = path + name;

            using StreamWriter streamWriter = new(fullPath);
            streamWriter.WriteLine(visGraphJson);
        }











        public static void DisplayArray(int[] array)
        {
            Console.WriteLine(string.Join(",", array));
        }

        public static int[] StrToArray(string str)
        {
            var array = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                array[i] = Int32.Parse(str[i].ToString());
            }

            return array;
        }
    }
}