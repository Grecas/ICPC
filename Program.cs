using System;
using System.Collections.Generic;
using System.IO;

namespace TrafficBr
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Semaphore> s = new List<Semaphore>();

            //// Read each line of the file into a string array. 
            string[] lines = System.IO.File.ReadAllLines(@"Data.txt");

            // Read and create the semaphores properties
            for(int line = 1; line< lines.Length; line++)
            {
                string[] properties = lines[line].Split(" ");
                s.Add(new Semaphore { X = int.Parse(properties[0]), R = int.Parse(properties[1]), G = int.Parse(properties[2])});
            }

            //Le calcula a cada semaphore la probabilidad de ser el primero en rojo, para un 0<=t<=TotalCiclos
            List<float> a = TrafficBlights.pBeTheFirst(s);
            foreach (float fl in a)
                Console.WriteLine("Semaphore: " + fl);

            //Calcula la probabilidad de que todos los semaphore esten en verde para cada intervalo de tiempo
            var pGreen = TrafficBlights.pAllInGreen();
            Console.WriteLine("All in Green: " + pGreen);

            Console.Read();
        }
       
    }

}