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
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int EuclidMethod(int a, int b, ref double totalTime)
        {
            int r = 0;
            int q = 0;

            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            int result = CheckInputNumbers(ref a, ref b);
            
            if (result != 0)
                return result;

            while (a % b != 0)
            {
                q = a / b;
                r = a % b;
                a = b;
                b = r;
                r = 0;
                q = 0;
            }

            sWatch.Stop();
            totalTime = sWatch.Elapsed.TotalMilliseconds;

            return b;
        }

        /// <summary>
        /// Overload of Method Euclid for 3 values. Work such as GCD(a, GCD(b, c)).
        /// </summary>
        public static int EuclidMethod(int a, int b, int c)
        {
            int result = EuclidMethod(b, c);
            return EuclidMethod(a, result);
        }

        /// <summary>
        /// Overload of Method Euclid for 3 values. Get total time of method work. Work such as GCD(a, GCD(b, c)).
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int EuclidMethod(int a, int b, int c, ref double totalTime)
        {
            int result = EuclidMethod(b, c, ref totalTime);
            return EuclidMethod(a, result, ref totalTime);
        }

        /// <summary>
        /// Method Euclid for params. Work such GCD(a, GCD(...GCD(b, GCD(c, d)), z)).
        /// </summary>
        public static int EuclidMethod(params int[] values)
        {
            int result = 0;

            for (int i = values.Length-1; i > 0; i--)
            {
                result = EuclidMethod(values[i-1], values[i]);
            }

            return result;
        }

        /// <summary>
        /// Method Euclid for params. Get total time of method work. Work such GCD(a, GCD(...GCD(b, GCD(c, d)), z)).
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int EuclidMethod(ref double totalTime, params int[] values)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
            {
                result = EuclidMethod(values[i - 1], values[i], ref totalTime);
            }

            return result;
        }
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
            int k = 1;
            Stopwatch sWatch = new Stopwatch();
            sWatch.Start();

            int result = CheckInputNumbers(ref a, ref b);

            if (result != 0)
                return result;

            while (a != 0 && b != 0)
            {
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }
                while (a % 2 == 0 && b % 2 != 0)
                {
                    a /= 2;
                }
                while (a % 2 != 0 && b % 2 == 0)
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

            sWatch.Stop();
            totalTime = sWatch.Elapsed.TotalMilliseconds;
            return b * k;
        }

        /// <summary>
        /// Binary Method Stein for GCD of params
        /// </summary>
        public static int SteinMethod(params int[] values)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
            {
                result = SteinMethod(values[i - 1], values[i]);
            }

            return result;            
        }

        /// <summary>
        /// Binary Method Stein for GCD of params. Get total time of method work.
        /// </summary>
        /// <param name="totalTime">ref double parameter, that's store time of method work.</param>
        public static int SteinMethod(ref double totalTime, params int[] values)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
            {
                result = SteinMethod(values[i - 1], values[i], ref totalTime);
            }

            return result;
        }
        #endregion

        #region Helper method.
        /// <summary>
        /// The method checks the validity of the data
        /// </summary>
        /// <returns>Return 0 if method complete checking </returns>
        public static int CheckInputNumbers(ref int a, ref int b)
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
