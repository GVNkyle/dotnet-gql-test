using dotnet_gql_test.Data;
using dotnet_gql_test.Models;
using GraphQL;
using GraphQL.Types;

namespace dotnet_gql_test.GraphQL
{
    public class NoteMutation : ObjectGraphType
    {
        public NoteMutation()
        {
            Field<NoteType>(
                "createNote",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "message"}
                ),
                resolve: context =>
                {
                    var message = context.GetArgument<string>("message");
                    var notesContext = context.RequestServices.GetRequiredService<DataContext>();
                    var note = new Note
                    {
                        Message = message,
                    };
                    notesContext.Notes.Add(note);
                    notesContext.SaveChanges();
                    return note;
                }
            );
        }
    }
}