using System;
using dotnet_gql_test.Models;
using GraphQL.Types;

namespace dotnet_gql_test.GraphQL
{
    public class NoteType : ObjectGraphType<Note>
    {
        public NoteType()
        {
            Name = "Note";
            Description = "Note Type";
            Field(d => d.Id, nullable: false).Description("Note Id");
            Field(d => d.Message, nullable: true).Description("Note Message");
        }
    }
}
