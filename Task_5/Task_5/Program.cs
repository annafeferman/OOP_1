using System;
using System.IO;

namespace Task_5
{
    class Program
    {
        private static int[] FileData(string path_to)
        {
            string[] fileData = File.ReadAllText(path_to).Split(" ");
            int[] arraysXAndY = new int[fileData.Length];
            for (int i = 0; i < fileData.Length; i++)
            {
                try
                {
                    arraysXAndY[i] = Convert.ToInt32(fileData[i]);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid file data!");
                }
            }
            return arraysXAndY;
        }
        private static int[] TransformedX(ref int[] x)
        {
            int[] TransformedX = new int[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    x[i] = x[i] * (-1);
                }
            }
            return TransformedX;
        }
        private static int[] ArrayZ(int[] x, int[] y, ref int[] z)
        {
            int[] ArrayZ = new int[z.Length];
            for (int i = 0; i < x.Length; i++)
            {
                z[i] = y[i] - x[i];
            }
            return ArrayZ;
        }

        static void Main(string[] args)
        {
            string PathToX = @"C:\Users\annfe\source\repos\fifth_tasl\fifth_tasl\x.txt";

            int[] x = FileData(PathToX);

            Console.WriteLine("Your array from х.txt file: ");
            Console.WriteLine(string.Join(" ", x));

            TransformedX(ref x);
            Console.WriteLine("Transformed array from х.txt file: ");
            Console.WriteLine(string.Join(" ", x));

            string PathToY = @"C:\Users\annfe\source\repos\fifth_tasl\fifth_tasl\y.txt";

            int[] y = FileData(PathToY);

            Console.WriteLine("Your array from у.txt file: ");
            Console.WriteLine(string.Join(" ", y));

            int[] z = new int[x.Length];

            ArrayZ(x, y, ref z);
            Console.WriteLine("Result array z: ");
            Console.WriteLine(string.Join(" ", z));
        }
    }
}