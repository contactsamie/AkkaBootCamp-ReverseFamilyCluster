using System;
using Akka.Actor;
using FamilyCluster.Common;

namespace FamilyCluster.Sister
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Sister ...");
            using (var system = ActorSystem.Create("Family"))
            {
                var sisterEchoActor = system.TryCreateActor<EchoActor>("SisterEchoActor");

                while (true)
                {
                    var message = Console.ReadLine();
                }
            }
        }
    }
}