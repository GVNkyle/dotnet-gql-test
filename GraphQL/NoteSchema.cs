using GraphQL.Types;

namespace dotnet_gql_test.GraphQL
{
    public class NoteSchema : Schema
    {
        public NoteSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<NoteQuery>();
            Mutation = serviceProvider.GetRequiredService<NoteMutation>();
        }
    }
}