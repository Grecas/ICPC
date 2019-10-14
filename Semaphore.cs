using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficBr
{

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

}
