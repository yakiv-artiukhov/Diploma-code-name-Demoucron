using omg.GraphTopologicalSorting;
using omg.GraphTopologicalSorting.Algorithms;
using System.Net.Security;

namespace omg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var matrix = new int[4][]
            {
                new int[4] { 0, 0, 1, 1},
                new int[4] { 0, 0, 1, 0 },
                new int[4] { 0, 0, 0, 0 },
                new int[4] { 0, 0, 1, 0 }
            };

            var matrix1 = new int[23 * 23]
            {
                0,1,1,0,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,0,0,0,0,0,0,0,0,
            };

            var matrix2 = StrToArray("0000000001010000000000000000000000100000000000000000000010000000010000000000000000000000000010000000011000000001000000000000000011101010000000000100000000000000000000000000000000000000000000000000000000000100000001000000000000000000000000000000000000001000000000000000000000000000000010000000000010000000000100000000000100000000000000110001000000001000000000000001000010000000000000000000000000000000010000000000100001000000000000000000000000000000000000000001000000000000000000000100000000000000000000000000000000000000000000000");


            var demoucron = new Demoucron();
            var graphTopologicalSorting = new GraphTopologicalSorting.GraphTopologicalSorting(matrix2, demoucron);
            var graphVerticesByLevels = graphTopologicalSorting.OrderGraphVerticesByLevels();

            //var vertexLevelsArray = Demoucron.Process(matrix);
            //var vertexLevelsArray = Demoucron.Process(matrix1);
            var vertexLevelsArray = demoucron.Process(matrix2);

            DisplayArray(vertexLevelsArray);
            Console.WriteLine();
            DisplayGraphByLevels(graphVerticesByLevels);
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

        public static void DisplayGraphByLevels(Dictionary<int, List<int>> graphVerticesByLevels)
        {
            foreach (var level in graphVerticesByLevels)
            {
                Console.WriteLine($"Level {level.Key}: {String.Join(", ", level.Value)}");
            }
        }
    }
}