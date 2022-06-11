using GraphQLAPIDemo.Data;
using GraphQLAPIDemo.GraphQL.Commands;
using GraphQLAPIDemo.GraphQL.Commmands;
using GraphQLAPIDemo.GraphQL.Platforms;
using GraphQLAPIDemo.Models;
using HotChocolate.Subscriptions;

namespace GraphQLAPIDemo.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender evenSender,
            CancellationToken cancellationToken)
        {
            var command = new Command
            {
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };
            context.Commands.Add(command);
            await context.SaveChangesAsync(cancellationToken);

            return new AddCommandPayload(command);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(AddPlatformInput input, 
            [ScopedService] AppDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform
            {
                Name = input.Name
            };
            context.Platforms.Add(platform);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }
    }
}
