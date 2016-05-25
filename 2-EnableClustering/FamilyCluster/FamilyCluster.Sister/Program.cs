using System;
using Akka.Actor;

namespace FamilyCluster.Sister
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting SisterSystem ...");
            using (var system = ActorSystem.Create("SisterSystem"))
            {
            }
        }
    }
}