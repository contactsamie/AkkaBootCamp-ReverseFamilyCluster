using System;
using Akka.Actor;

namespace FamilyCluster.Sister
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Sister ...");
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