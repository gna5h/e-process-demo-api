using EProcessDemo.Api.Data;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("OrderStore");

builder.Services.AddSqlite<OrderContext>(connString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MigrateDb();

app.Run();
