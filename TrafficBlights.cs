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
        /// Calcula primero semaforo que se encuentra en rojo si partiendo un auto en la posicion cero en un moemnto dado
        /// </summary>
        /// <param name="time">Segundo en el que inicia su reccorido el auto</param>
        /// <param name="s">Lista de semaforos que se encuentran en la MainStreet</param>
        /// <returns>Devuelve el tiempo numero del primer semaforo qu eencuentra en ropjo el auto. Si avanza por toda la calle con los semaforos en verde devuelve 0</returns>
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
            counter[0] = counter[0] - allGreen;
            foreach (int i in counter)
            {
                p.Add((float)i / (float)totalTime);
            }

            return p;
        }
    }
}
