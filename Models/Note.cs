using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_gql_test.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
