using GraphQLAPIDemo.Data;
using GraphQLAPIDemo.Models;

namespace GraphQLAPIDemo.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context) 
        {
            return context.Platforms;
        }
            
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context) 
        {
            return context.Commands;
        }
        
    }
}
