using dotnet_gql_test.Data;
using dotnet_gql_test.Models;
using GraphQL.Types;

namespace dotnet_gql_test.GraphQL
{
    public class NoteQuery : ObjectGraphType
    {
        public NoteQuery()
        {
            Field<ListGraphType<NoteType>>("notes", resolve: context => new List<Note> {
            new Note { Id = Guid.NewGuid(), Message = "Hello World!" },
            new Note { Id = Guid.NewGuid(), Message = "Hello World! How are you?" }
            });

            Field<ListGraphType<NoteType>>("test", resolve: context =>
            {
                var dataContext = context.RequestServices.GetRequiredService<DataContext>();
                return dataContext.Notes.ToList();
            }
            );
        }
    }
}