using System;
using System.Diagnostics;

namespace ClassLibraryLogicEuclid
{
    /// <summary>
    /// Euclid class contains realisation and overloads of such method:
    /// Euclid's method of finding greatest common divisor (GCD) of numbers
    /// Binary GCD algorithm - Stein's method of finding GCD of numbers
    /// </summary>
    public static class Euclid
    {
        #region EuclidMethod and its overloads
        
        /// <summary>
        /// Method Euclid for GCD of 2 values.
        /// </summary>
        /// <param name="a">First input number.</param>
        /// <param name="b">Second input number.</param>
        /// <returns>GCD of numbers a and b.</returns>
        public static int EuclidMethod(int a, int b)
        {
            int result = CheckInputNumbers(ref a, ref b);
            
            if (result != 0)
                return result;

            int r = 0;
            int q = 0;

            while ((a % b) != 0)
            {
                q = a / b;
                r = a % b;
                a = b;
                b = r;
                r = 0;
                q = 0;
            }

            return b;
        }

        /// <summary>
        /// Method Euclid for GCD of 2 values. Get total time of method work.
        /// </summary>
        /// <param name="a">First input number.</param>
        /// <param name="b">Second input number.</param> 
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        /// <returns>GCD of numbers a and b. Total time of method work.</returns>
        public static int EuclidMethod(int a, int b, ref double totalTime)
        {
            int result = 0;

            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            result = EuclidMethod(a, b);

            sWatch.Stop();
            totalTime = sWatch.Elapsed.TotalMilliseconds;

            return result;
        }

        /// <summary>
        /// Overload of Method Euclid for 3 values. Work such as GCD(a, GCD(b, c)).
        /// </summary>
        /// <returns>GCD of numbers a, b, c.</returns>
        public static int EuclidMethod(int a, int b, int c) => RecursiveMethod(EuclidMethod, new int[] { a, b, c });

        /// <summary>
        /// Overload of Method Euclid for 3 values. Get total time of method work. Work such as GCD(a, GCD(b, c)).
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        /// <returns>GCD of numbers a, b, c. Total time of method work.</returns>
        public static int EuclidMethod(int a, int b, int c, ref double totalTime)
        {
            int result = EuclidMethod(b, c, ref totalTime);
            return EuclidMethod(a, result, ref totalTime);
        }

        /// <summary>
        /// Method Euclid for params. Work such GCD(a, GCD(...GCD(b, GCD(c, d)), z)).
        /// </summary>
        /// <param name="values">Array of numbers.</param>
        /// <returns>GCD of numbers in array.</returns>
        public static int EuclidMethod(params int[] values) => RecursiveMethod(EuclidMethod, values);

        /// <summary>
        /// Method Euclid for params. Get total time of method work. Work such GCD(a, GCD(...GCD(b, GCD(c, d)), z)).
        /// </summary>
        /// <param name="values">Array of numbers.</param>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        /// <returns>GCD of numbers in array. Total ti,e of method work.</returns>
        public static int EuclidMethod(ref double totalTime, params int[] values) => RecursiveTimeMethod(EuclidMethod, values, ref totalTime);
        
        #endregion

        #region SteinMethod and its overloads
        /// <summary>
        /// Binary Method Stain for GCD of 2 values.
        /// </summary>
        public static int SteinMethod(int a, int b)
        {
            int k = 1;

            int result = CheckInputNumbers(ref a, ref b);
            
            if (result != 0)
                return result;

            while (a != 0 && b != 0)
            {
                while(a%2 == 0 && b%2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while(a%2 == 0 && b%2 !=0)
                {
                    a /= 2;
                }
                while(a % 2 != 0 && b % 2 == 0)
                {
                    b /= 2;
                }
                if (a >= b)
                {
                    a = a - b;
                }
                else
                    b = b - a;
            }

            return b * k;
        }

        /// <summary>
        /// Binary Method Stain for GCD of 2 values. Get total time of method work.
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int SteinMethod(int a, int b, ref double totalTime)
        {
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            int result = SteinMethod(a, b); 
            
            sWatch.Stop();
            totalTime = sWatch.Elapsed.TotalMilliseconds;
            return result;
        }

        /// <summary>
        /// Binary Method Stein for GCD of params
        /// </summary>
        public static int SteinMethod(params int[] values) => RecursiveMethod(SteinMethod, values);
        
        /// <summary>
        /// Binary Method Stein for GCD of params. Get total time of method work.
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int SteinMethod(ref double totalTime, params int[] values) => RecursiveTimeMethod(SteinMethod, values, ref totalTime);

        #endregion

        #region Private Method

        /// <summary>
        /// Method RecursiveMethod gets function type of delegate and array of input numbers.
        /// </summary>
        /// <param name="func">Encapsulates a method that has two parameters.</param>
        /// <param name="values">Array of numbers.</param>
        /// <returns>GCD of numbers in array.</returns>
        private static int RecursiveMethod(Func<int, int, int> func, int[] values)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
                result = func(values[i - 1], values[i]);

            return result;
        }

        /// <summary>
        /// Encapsulates a method that has three parameters one of wich has a ref type.
        /// </summary>
        /// <param name="a">First parameter.</param>
        /// <param name="b">Second parameter.</param>
        /// <param name="time">Third parameter type of ref double.</param>
        private delegate int RecursiveMethodDelegate(int a, int b, ref double time);

        /// <summary>
        /// Method RecursiveTimeMethod.
        /// </summary>
        /// <param name="func">Variable of type delegate.</param>
        /// <param name="values">Array of input numbers.</param>
        /// <param name="totalTime">Total time of method work.</param>
        /// <returns>GCD of two numbers. Total time of method work.</returns>
        private static int RecursiveTimeMethod(RecursiveMethodDelegate func, int[] values, ref double totalTime)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
                result = func(values[i - 1], values[i], ref totalTime);

            return result;
        }

        /// <summary>
        /// The method checks the validity of the data.
        /// </summary>
        /// <returns>Return 0 if method complete checking.</returns>
        private static int CheckInputNumbers(ref int a, ref int b)
        {
            if (a == 0 && b == 0)
                throw new ArgumentException();

            if (a == 0)
                return b;
            if (b == 0)
                return a;

            if (a == 1)
                return 1;
            if (b == 1)
                return 1;

            if (a < 0 && b < 0)
            {
                a = -a;
                b = -b;
            }

            if (a < 0)
                a = -a;
            if (b < 0)
                b = -b;

            return 0;
        }

        #endregion
    }
}
