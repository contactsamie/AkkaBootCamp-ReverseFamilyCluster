using System;
using System.Configuration;
using Akka.Actor;
using Akka.Configuration.Hocon;
using Akka.Routing;

namespace FamilyCluster.Common
{
    public static class ActorSystemExtensions
    {
        public static IActorRef TryCreateActor<T>(this ActorSystem system, string actorName)
        {
            return TryCreateActor(system, typeof (T), actorName);
        }

        public static IActorRef TryCreateActor(this ActorSystem system, Type actorFunc, string actorName)
        {
            var section = (AkkaConfigurationSection) ConfigurationManager.GetSection("akka");
            IActorRef actor;

            if (section?.AkkaConfig?.GetConfig("akka.actor.deployment") != null)
            {
                actor = system.ActorOf(Props.Create(actorFunc).WithRouter(FromConfig.Instance), actorName);
                Console.WriteLine("Loaded router for " + actorName + " from hocon");
            }
            else
            {
                Console.WriteLine("Could not load router for " + actorName + " from hocon");
                actor = system.ActorOf(Props.Create(actorFunc), actorName);
            }
            return actor;
        }
    }
}