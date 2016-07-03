using System;

namespace ClassLibraryLogicNewton
{
    /// <summary>
    /// Newton class contains realisation of Newton's method of finding the root of the number of degree n
    /// </summary>
    public static class Newton
    {
        #region MethodNewton
        /// <summary>
        /// Realisation of Newton Method
        /// </summary>
        public static double MethodNewton(int number, double degree, double precision)
        {
            double previous = StartApproach(number, degree);
            double next = (1 / degree)*((degree - 1)*previous + number/(Math.Pow(previous, degree-1)));

            while (next - previous >= precision)
            {
                previous = next;
                next = (1 / degree)*((degree - 1) * previous + number / (Math.Pow(previous, degree - 1)));
            }

            return next;
        }

        /// <summary>
        /// Method StartApproach find start value for Newton method
        /// </summary>
        public static double StartApproach(int number, double degree)
        {
            double approach = 1;

            while (ResultFunction(number, degree, approach) < 0)
            {
                approach += 0.01;
            }

            return approach;
        }

        /// <summary>
        /// Method ResultFunction return value of function at a given point
        /// </summary>
        public static double ResultFunction(int number, double degree, double approach)
        {
            return Math.Pow(approach, degree) - number;
        }
        #endregion
    }
}
