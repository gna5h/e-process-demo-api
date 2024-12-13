using EProcessDemo.Api.Data;
using EProcessDemo.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("OrderStore");

builder.Services.AddSqlite<OrderContext>(connString);

var app = builder.Build();

app.MapOrdersEndpoints();

app.MigrateDb();

app.Run();
