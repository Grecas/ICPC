using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficBr
{

    internal static class MathHelper
    {
        /// <summary>
        /// Caclula el MCM de una lista de numeros
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        internal static int MCM(List<int> nums)
        {
            if (nums.Count == 0) throw new Exception("Debe ingresar al menos 2 numeros");
            int mcm = nums[0];
            for (int n = 0; n < nums.Count - 1; n++)
            {
                mcm = MCM(mcm, nums[n + 1]);
            }
            return mcm;
        }

        /// <summary>
        /// Calcula el mcm de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        internal static int MCM(int n1, int n2)
        {
            int min = Math.Min(n1, n2);
            int max = Math.Max(n1, n2);

            return (max / MCD(n1, n2)) * min;
        }

        /// <summary>
        /// Calcula el maximo comun divisor de dos numeros
        /// </summary>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        /// <returns></returns>
        internal static int MCD(int n1, int n2)
        {
            int mcd;
            int min = Math.Min(n1, n2);
            int max = Math.Max(n1, n2);
            do
            {
                mcd = min;
                min = max % min;
                max = mcd;
            } while (min != 0);

            return mcd;
        }

    }
}
