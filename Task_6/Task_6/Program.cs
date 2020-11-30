using System;
using System.Text;

namespace Task_6
{
    class MyArray
    {
        private static int numberOfRows;
        private static int numberOfColumns;
        private static int maxValue;
        private static int maxValueIndex;
        private static int[,] myArray;

        public static void ArraySizeInput()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Input the number of rows: ");
                    numberOfRows = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input the number of columns: ");
                    numberOfColumns = Convert.ToInt32(Console.ReadLine());
                    if (numberOfColumns < 1 || numberOfRows < 1) { throw new ArgumentException(); };
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void FormArray()
        {
            myArray = new int[numberOfRows, numberOfColumns];
 
            Random random = new Random();
            Console.WriteLine(" ");
            Console.WriteLine("Your array:");
            Console.WriteLine(" ");
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    myArray[i, j] = random.Next(100);
                    Console.Write("{0,3}", myArray[i, j]);
                }
                Console.WriteLine();
            }
        }

        static public void MaxValueAndIndex(int[,] array)
        {
            int[] maxs = new int[array.GetLength(0)];
            Console.WriteLine(" ");
            for (int i = 0; i < maxs.Length; i++)
            {
                for (int a = 0; a < array.GetLength(1); a++)
                    if (array[i, a] > maxs[i])
                        maxs[i] = array[i, a];
                maxValue = maxs[i];
                Console.WriteLine("Max element in the {0} line is: {1}.", i + 1, maxValue);
                for (int k = 0; k < numberOfRows; k++)
                {
                    for (int j = 0; j < numberOfColumns; j++)
                    {
                        if (myArray[k, j] == maxValue)
                        {
                            Console.WriteLine("The index is: {" + k + "}" + "{" + j + "}");
                        }
                    }
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                MyArray.ArraySizeInput();
                MyArray.FormArray();
                MyArray.MaxValueAndIndex(myArray);
            }
        }
    }
}
