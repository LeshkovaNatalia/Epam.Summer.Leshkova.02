using System;
using static ClassLibraryLogicEuclid.Euclid;

namespace ConsoleApplicationUIEuclid
{
    class ProgramEuclid
    {
        static void Main(string[] args)
        {
            #region Static Example
            Console.WriteLine("Euclid -> (748,944)={0}", EuclidMethod(748, 944));

            double totalTime = 0;
            Console.WriteLine("Euclid -> (748,944)={0}", EuclidMethod(748, 944, ref totalTime));
            Console.WriteLine("Total Milliseconds: " + totalTime);

            Console.WriteLine("Euclid -> GCD of enter numbers is {0}", EuclidMethod(15,18,27,69));

            totalTime = 0;
            Console.WriteLine("Stain -> (748,944)={0}", SteinMethod(748, 944, ref totalTime));
            Console.WriteLine("Total Milliseconds: " + totalTime);
            Console.WriteLine();

            Console.WriteLine("Stain -> GCD of enter numbers is {0}", SteinMethod(15, 18, 27, 69));
            Console.WriteLine();
            #endregion

            #region Enter data
            Console.Write("Enter number of elements >= 2: ");
            int N = 0;
            bool isParsed = Int32.TryParse(Console.ReadLine(), out N);
            if (isParsed && N >= 2)
            {
                int[] array = new int[N];
                for (int i = 0; i < N; i++)
                {
                    Console.Write("Enter element {0} of array: ", i + 1);
                    isParsed = Int32.TryParse(Console.ReadLine(), out array[i]);

                    if (!isParsed)
                    {
                        Console.WriteLine("You enter not a number!");
                        break;
                    }

                    if (isParsed && i == N - 1)
                    {
                        Console.WriteLine("GCD of enter numbers is {0}", SteinMethod(array));
                    }
                }
            }
            else
                Console.WriteLine("You enter not a number!");

            Console.ReadLine();
            #endregion
        }
    }
}
