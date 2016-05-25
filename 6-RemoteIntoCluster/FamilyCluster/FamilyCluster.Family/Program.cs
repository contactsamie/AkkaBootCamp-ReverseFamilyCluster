using System;
using Akka.Actor;
using FamilyCluster.Common;

namespace FamilyCluster.Family
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Family ...");
            using (var system = ActorSystem.Create("Family"))
            {
                var sisterEchoActor = system.TryCreateActor<EchoActor>("SisterEchoActor");
                var brotherEchoActor = system.TryCreateActor<EchoActor>("BrotherEchoActor");
                var familyActor = system.TryCreateActor<FamilyActor>("FamilyActor");
                while (true)
                {
                    var message = Console.ReadLine();
                    sisterEchoActor.Tell(new Hello("From Family to sisterEchoActor" + message), ActorRefs.NoSender);
                    brotherEchoActor.Tell(new Hello("From Family to brotherEchoActor" + message), ActorRefs.NoSender);
                }
            }
        }

        public class FamilyActor : ReceiveActor
        {
            public FamilyActor()
            {
                var sisterEchoActor = Context.ActorSelection("/user/SisterEchoActor");
                var brotherEchoActor = Context.ActorSelection("/user/BrotherEchoActor");
                Receive<string>(message =>
               {
                   sisterEchoActor.Tell(new Hello("From Family to sisterEchoActor" + message), ActorRefs.NoSender);
                   brotherEchoActor.Tell(new Hello("From Family to brotherEchoActor" + message), ActorRefs.NoSender);
               });
            }
        }
    }
}