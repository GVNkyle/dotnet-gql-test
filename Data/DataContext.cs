using dotnet_gql_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_gql_test.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Note> Notes {get; set;}
        public DataContext(DbContextOptions options) : base(options)
        {

        }


    }
}
