
using GraphQLAPIDemo.GraphQL.Commands;

namespace GraphQLAPIDemo.GraphQL.Commmands
{
    public class AddCommandPayloadType : ObjectType<AddCommandPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<AddCommandPayload> descriptor)
        {
            descriptor.Description("Represents the payload to return for an added command.");

            descriptor
                .Field(c => c.command)
                .Description("Represents the added command.");

            base.Configure(descriptor);
        }
    }
}
