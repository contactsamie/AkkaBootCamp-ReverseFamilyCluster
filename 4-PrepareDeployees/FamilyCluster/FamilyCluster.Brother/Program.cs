using System;
using Akka.Actor;
using FamilyCluster.Common;

namespace FamilyCluster.Brother
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Brother ...");
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