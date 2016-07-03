using System;
using ClassLibraryLogicEuclid;

namespace ConsoleApplicationUIEuclid
{
    class ProgramEuclid
    {
        static void Main(string[] args)
        {
            #region Static Example
            Euclid eu = new Euclid();
            Console.WriteLine("Euclid -> (748,944)={0}", eu.EuclidMethod(748, 944));
            Console.WriteLine("RunTime " + GetTime(eu));
            Console.WriteLine();

            Euclid eu2 = new Euclid();
            Console.WriteLine("Euclid -> NOD of enter numbers is {0}", eu2.EuclidMethod(15,18,27,69));
            Console.WriteLine("RunTime " + GetTime(eu2));
            Console.WriteLine();

            Euclid eu3 = new Euclid();
            Console.WriteLine("Stain -> (748,944)={0}", eu3.SteinMethod(748, 944));
            Console.WriteLine("RunTime " + GetTime(eu3));
            Console.WriteLine();

            Euclid eu4 = new Euclid();
            Console.WriteLine("Stain -> NOD of enter numbers is {0}", eu4.SteinMethod(15, 18, 27, 69));
            Console.WriteLine("RunTime " + GetTime(eu4));
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

                    if (!isParsed || array[i] <= 0)
                    {
                        Console.WriteLine("You enter not a number or negative number!");
                        break;
                    }

                    if (isParsed && i == N - 1)
                    {
                        Euclid eu5 = new Euclid();
                        Console.WriteLine("NOD of enter numbers is {0}", eu5.SteinMethod(array));
                        Console.WriteLine("RunTime " + GetTime(eu5));
                    }
                }
            }
            else
                Console.WriteLine("You enter not a number!");

            Console.ReadLine();
            #endregion
        }

        /// <summary>
        /// Method GetTime return Total Milliseconds of method work
        /// </summary>
        public static string GetTime(Euclid eu)
        {
            TimeSpan ts = eu.SWatch.Elapsed;
            string elapsedTime = String.Format("Total Milliseconds: {0}", ts.TotalMilliseconds);
            return elapsedTime;
        }
    }
}
