using System;
using System.Collections.Generic;

namespace TrafficBr
{
    class TrafficBlights
    {
        static void Main(string[] args)
        {
            List<Semaphore> s = new List<Semaphore>() { new Semaphore { X = 4, R = 3, G = 5}, new Semaphore { X = 10, R = 3, G = 5}, new Semaphore { X = 2, R=1, G = 3} };

            Console.WriteLine("16,12 " + MCM(16, 12));

            Console.Read();
        }
       

        static int firstRed(int time, List<Semaphore> s) 
        {
            int tic = time;
            int countSem = 1;
            foreach(Semaphore sem in s)
            {
                tic = time + sem.X;
                if (sem.isRed(tic))
                    return countSem;
                countSem++;
            }

            return 0;
        }

        static int MCM(int n1, int n2) 
        {
            int min = Math.Min(n1, n2);
            int max = Math.Max(n1, n2);

            return (max/MCD(n1,n2))*min;
        }

        private static int MCD(int n1, int n2)
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

    /// <summary>
    /// Class Semaphore. 
    /// Los objetos semaphore tienen un intervalo de duracion para su luz roja(r) y otro para su luz verde(g) y se encuentran a una distancia(x) del punto inicial de una calle
    /// </summary>
    internal class Semaphore
    {
        private int x;
        private int g;
        private int r;

        public int R { get => r; set => r = value; }
        public int X { get => x; set => x = value; }
        public int G { get => g; set => g = value; }

        /// <summary>
        /// Devuelve si dato un tiempo en seg. el semaphore se encuentra en rojo o verde
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        internal bool isRed(int time)
        {
            return (time) % (g + r) < r;
        }
    }
}