using Akka.Actor;
using Akka.Cluster;
using FamilyCluster.Common;
using System;
using System.Linq;

namespace FamilyCluster.Family
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting Family ...");
            using (var system = ActorSystem.Create("Family"))
            {
                var familyActor = system.TryCreateActor<FamilyActor>("FamilyActor");

                while (true)
                {
                    var message = Console.ReadLine();
                    var sisterEchoActor = system.ActorSelection(Cluster.Get(system).ReadView.Members.First(x => x.HasRole("sister")).Address+ "/user/SisterEchoActor");
                    var brotherEchoActor = system.ActorSelection(Cluster.Get(system).ReadView.Members.First(x => x.HasRole("brother")).Address+ "/user/BrotherEchoActor");
                   
                    sisterEchoActor.Tell(new Hello("From Family to sisterEchoActor" + message), ActorRefs.NoSender);
                    brotherEchoActor.Tell(new Hello("From Family to brotherEchoActor" + message), ActorRefs.NoSender);
                }
            }
        }

        public class FamilyActor : ReceiveActor
        {
            public FamilyActor()
            {
                Receive<string>(message =>
               {
                   var sisterEchoActor = Context.ActorSelection(Cluster.Get(Context.System).ReadView.Members.First(x => x.HasRole("sister")).Address + "/user/SisterEchoActor");
                   var brotherEchoActor = Context.ActorSelection(Cluster.Get(Context.System).ReadView.Members.First(x => x.HasRole("brother")).Address + "/user/BrotherEchoActor");

                   sisterEchoActor.Tell(new Hello("From Family to sisterEchoActor" + message), ActorRefs.NoSender);
                   brotherEchoActor.Tell(new Hello("From Family to brotherEchoActor" + message), ActorRefs.NoSender);
               });
            }
        }
    }
}