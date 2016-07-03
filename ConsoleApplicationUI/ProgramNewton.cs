using System;
using ClassLibraryLogicNewton;

namespace ConsoleApplicationUINewton
{
    class ProgramNewton
    {
        static void Main(string[] args)
        {
            #region Static Example
            double[] array = new double[3];
            bool isParsed = false;

            double result = Newton.MethodNewton(135, 12, 0.0001);
            Console.WriteLine("Test MethodNewton: root 12 degree of 135 -> {0}", result);
            Console.WriteLine("Compare result Math.Pow: {0} in degree {1} = {2}", result, 12, Math.Pow(result, 12));
            Console.WriteLine();
            #endregion

            #region Enter data
            Console.WriteLine("Enter elements: 1 -> number(18), 2 -> degree(5), 3 -> precision(0,00001)");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter element {0} of array: ", i + 1);
                isParsed = Double.TryParse(Console.ReadLine(), out array[i]);
                if (!isParsed)
                {
                    Console.WriteLine("You enter not a number!");
                    break;
                }
            }

            if (isParsed)
            {
                result = Newton.MethodNewton((int)array[0], array[1], array[2]);
                Console.WriteLine();
                Console.WriteLine("Test MethodNewton: root {0} degree of {1} -> {2}", array[1], array[0], result);
                Console.WriteLine("Compare result Math.Pow: {0}", Math.Pow(result, array[1]));
            }

            Console.ReadLine();
            #endregion
        }
    }
}
