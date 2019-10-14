using System;
using System.Collections.Generic;
using System.IO;

namespace TrafficBr
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Semaphore> s = new List<Semaphore>()
            {
                new Semaphore { X = 1, R = 2, G = 3 },
                new Semaphore { X = 6, R = 2, G = 3 },
                new Semaphore { X = 10, R = 2, G = 3 },
                new Semaphore { X = 16, R = 3, G = 4 }
            };
           
            //// Read each line of the file into a string array. 
            //string[] lines = System.IO.File.ReadAllLines(@"C:\Data.txt");

            //// Display the file contents by using a foreach loop.
            //foreach (string line in lines)
            //{
                
            //}
                      


            List<float> a = TrafficBlights.pBeTheFirst(s);
            foreach (float fl in a)
                Console.WriteLine("Semaphore: " + fl);
            var pGreen = TrafficBlights.pAllInGreen();
            Console.WriteLine("All in Green: " + pGreen);

            Console.Read();
        }
       
    }

}