using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akka.Actor;

namespace FamilyCluster.FamilyFriend
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Friend ...");
            using (var system = ActorSystem.Create("Friend"))
            {
                var family = system.ActorSelection("akka.tcp://Family@localhost:50000/user/FamilyActor");
                while (true)
                {
                    var message = Console.ReadLine();
                    family.Tell(message, ActorRefs.NoSender);
                }
            }
        }
    }
}
