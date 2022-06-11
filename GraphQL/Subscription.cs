using GraphQLAPIDemo.Models;

namespace GraphQLAPIDemo.GraphQL
{
    public class Subscription
    {
        [Topic]
        [Subscribe]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}