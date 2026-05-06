using DataAccess;
using BussinesLogic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddBusinesLogic();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

await app.Services.CheckDatabaseConnectionAsync();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();