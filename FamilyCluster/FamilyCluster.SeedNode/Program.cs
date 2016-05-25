using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace FamilyCluster.SeedNode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting SeedNode ...");
            using (var system = ActorSystem.Create("Family"))
            {
                while (true)
                {
                    var message = Console.ReadLine();
                   
                }
            }
        }
    }
}
