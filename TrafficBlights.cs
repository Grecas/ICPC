using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficBr
{
    static class TrafficBlights
    {
        static int allGreen = 0;
        static int totalTime = 0;
        static internal float pAllInGreen()
        {
            return (float)allGreen / (float)totalTime;
        }

        /// <summary>
        /// Calcula el primer semáforo que se encuentra en rojo, si partiendo un auto en la posición cero en un momento dado
        /// </summary>
        /// <param name="time">Segundo en el que inicia su recorrido el auto</param>
        /// <param name="s">Lista de semáforos que se encuentran en la MainStreet</param>
        /// <returns>Devuelve el número del primer semáforo que el auto encuentra en rojo . Si avanza por toda la calle con los semáforos en verde devuelve 0</returns>
        static internal int firstRed(int time, List<Semaphore> s)
        {
            int tic = time;
            int countSem = 0;
            foreach (Semaphore sem in s)
            {
                tic = time + sem.X;
                if (sem.isRed(tic))
                    return countSem;
                countSem++;
            }
            allGreen++;
            return 0;
        }
        
        /// <summary>
        /// Calcula la probabilidad que tiene cada semáforo de ser el primero que el auto encuentra en rojo.
        /// </summary>
        /// <param name="time">Segundo en el que inicia su recorrido el auto</param>
        /// <param name="s">Lista de semáforos que se encuentran en la MainStreet</param>
        /// <returns>Devuelve el número del primer semáforo que el auto encuentra en rojo . Si avanza por toda la calle con los semáforos en verde devuelve 0</returns>
        static internal List<float> pBeTheFirst(List<Semaphore> s)
        {
            int[] counter = new int[(s.Count)];
            List<float> p = new List<float>();
            int timer = 0;

            List<int> ciclos = new List<int>();
            foreach (Semaphore sem in s)
            {
                ciclos.Add(sem.G + sem.R);
            }
            totalTime = MathHelper.MCM(ciclos);
            while (timer < totalTime)
            {
                counter[firstRed(timer, s)]++;
                timer++;
            }
            //La cantidad de veces que todos los autos están en verde se va guardando en el contador del primer semáforo, aquí se saca
            counter[0] = counter[0] - allGreen;
            foreach (int i in counter)
            {
                p.Add((float)i / (float)totalTime);
            }

            return p;
        }
    }
}
