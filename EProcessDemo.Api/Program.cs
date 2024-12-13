using EProcessDemo.Api.Data;
using EProcessDemo.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("OrderStore");

builder.Services.AddSqlite<EProcessDemoContext>(connString);

var app = builder.Build();

app.MapOrdersEndpoints();
app.MapCustomersEndpoints();

app.MigrateDb();

app.Run();
