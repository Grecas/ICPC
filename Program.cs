using System;
using System.Collections.Generic;

namespace TrafficBr
{
    class TrafficBlights
    {
        static void Main(string[] args)
        {
            List<Semaphore> s = new List<Semaphore>() { new Semaphore { X = 1, R = 2, G = 3 }, new Semaphore { X = 6, R = 2, G = 3 }, new Semaphore { X = 10, R = 2, G = 3 }, new Semaphore { X = 16, R = 3, G = 4 } };

            List<float> a = pBeTheFirst(s);
            foreach( float fl in a)
             Console.WriteLine("Semaphore: " + fl+ "/n");

            Console.Read();
        }
       
        /// <summary>
        /// Calcula primero semaforo que se encuentra en rojo si partiendo un auto en la posicion cero en un moemnto dado
        /// </summary>
        /// <param name="time">Segundo en el que inicia su reccorido el auto</param>
        /// <param name="s">Lista de semaforos que se encuentran en la MainStreet</param>
        /// <returns>Devuelve el tiempo numero del primer semaforo qu eencuentra en ropjo el auto. Si avanza por toda la calle con los semaforos en verde devuelve 0</returns>
        static int firstRed(int time, List<Semaphore> s) 
        {
            int tic = time;
            int countSem = 0;
            foreach(Semaphore sem in s)
            {
                tic = time + sem.X;
                if (sem.isRed(tic))
                    return countSem;
                countSem++;
            }

            return 0;
        }

        static List<float> pBeTheFirst(List<Semaphore> s) 
        {
            int[] counter = new int[(s.Count)];
            List<float> p = new List<float>();
            int timer = 0;

            List<int> ciclos = new List<int>();
            foreach (Semaphore sem in s)
            {
                ciclos.Add(sem.G + sem.R);
            }
            int totalTime = MathHelper.MCM(ciclos);
            while(timer < totalTime)
            {
               counter[ firstRed(timer, s)] ++;
                timer++;
            }
            foreach (int i in counter)
            {
                p.Add( (float)i / (float)totalTime);
            }
            return p;
        }
       
    }

    /// <summary>
    /// Class Semaphore. 
    /// Los objetos semaphore tienen un intervalo de duracion para su luz roja(r) y otro para su luz verde(g) y se encuentran a una distancia(x) del punto inicial de una calle
    /// </summary>
    internal class Semaphore
    {
        #region Campos
        private int x;
        private int g;
        private int r;
        #endregion

        #region Propiedades
        public int R { get => r; set => r = value; }
        public int X { get => x; set => x = value; }
        public int G { get => g; set => g = value; }
        #endregion

        /// <summary>
        /// Devuelve si dado un tiempo en seg. el semaphore se encuentra en rojo o verde
        /// </summary>
        /// <param name="time">Segundo en el que se desea conocer si el semaforo esta en rojo</param>
        /// <returns>Devuelve True si el semaforo esta en rojo en el segundo "time". False en caso contrario</returns>
        internal bool isRed(int time)
        {
            return (time) % (g + r) < r;
        }
    }

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