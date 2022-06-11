using GraphQLAPIDemo.Data;
using GraphQLAPIDemo.GraphQL;
using GraphQLAPIDemo.GraphQL.Commmands;
using GraphQLAPIDemo.GraphQL.Platforms;
using Microsoft.EntityFrameworkCore;

public static class ServiceExtensions
{
    public static void ConfigureGraphQL(this IServiceCollection services)
    {
        services
        .AddGraphQLServer()
        .AddQueryType<Query>()
        .AddMutationType<Mutation>()
        .AddSubscriptionType<Subscription>()
        .AddType<CommandType>()
        .AddType<PlatformType>()
        .AddType<AddCommandInputType>()
        .AddType<AddCommandPayloadType>()
        .AddType<AddPlatformInputType>()
        .AddType<AddPlatformPayloadType>()
        .AddFiltering()
        .AddSorting()
        // .AddProjections()
        .AddInMemorySubscriptions();
    }

    public static void ConfigureSqlContext(this IServiceCollection services, 
    IConfiguration configuration)
    {
        services.AddPooledDbContextFactory<AppDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection"));
        });
    }
}