using System.Diagnostics;

namespace ClassLibraryLogicEuclid
{
    /// <summary>
    /// Euclid class contains realisation and overloads of such method:
    /// Euclid's method of finding greatest common divisor (GCD) of numbers
    /// Binary GCD algorithm - Stein's method of finding (GCD) of numbers
    /// </summary>
    public class Euclid
    {
        #region Fields
        public Stopwatch SWatch { get; }
        #endregion

        #region Ctor
        public Euclid()
        {
            SWatch = new Stopwatch();
        }

        public Euclid(Stopwatch s)
        {
            SWatch = s;
        }
        #endregion

        #region EuclidMethod and its overloads
        /// <summary>
        /// Recursion Method Euclid for NOD of 2 values
        /// </summary>
        public int EuclidMethod(int a, int b)
        {
            int r = 0;
            int q = 0;

            if ( !SWatch.IsRunning )
                SWatch.Start();

            if ((a % b) == 0)
            {
                SWatch.Stop();
                return b;
            }
            else
            {
                q = a / b;
                r = a % b;
                return EuclidMethod(b, r);
            }
        }

        /// <summary>
        /// Overload of Method Euclid for 3 values. Work such as NOD(a, NOD(b, c))
        /// </summary>
        public int EuclidMethod(int a, int b, int c)
        {
            int result = EuclidMethod(b, c);
            return EuclidMethod(a, result);
        }

        /// <summary>
        /// Method Euclid for params. Work such NOD(a, NOD(...NOD(b, NOD(c, d)), z))
        /// </summary>
        public int EuclidMethod(params int[] values)
        {
            int result = 0;

            for (int i = values.Length-1; i > 0; i--)
            {
                result = EuclidMethod(values[i-1], values[i]);
            }

            return result;
        }
        #endregion

        #region SteinMethod and its overloads
        /// <summary>
        /// Binary Method Stain for NOD of 2 values
        /// </summary>
        public int SteinMethod(int a, int b)
        {
            int k = 1;
            SWatch.Start();

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

            SWatch.Stop();

            return b * k;
        }

        /// <summary>
        /// Binary Method Stein for GCD of params
        /// </summary>
        public int SteinMethod(params int[] values)
        {
            int result = 0;

            for (int i = values.Length - 1; i > 0; i--)
            {
                result = SteinMethod(values[i - 1], values[i]);
            }

            return result;            
        }
        #endregion
    }
}
