using dotnet_gql_test.Data;
using dotnet_gql_test.GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(o => {
    o.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddControllers();
builder.Services.AddScoped<ISchema, NoteSchema>(s => new NoteSchema(new SelfActivatingServiceProvider(s)));

builder.Services.AddGraphQL(o => o.EnableMetrics = true).AddSystemTextJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseGraphQLAltair();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseGraphQL<ISchema>();

app.Run();
