using CinemaApp.Endpoint;
using CinemaApp.Endpoint.Services;
using CinemaApp.Logic;
using CinemaApp.Models;
using CinemaApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<CinemaDBContext>();

builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ISeatRepository, SeatRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();

builder.Services.AddTransient<IMovieLogic, MovieLogic>();
builder.Services.AddTransient<ISeatLogic, SeatLogic>();
builder.Services.AddTransient<IAccountLogic, AccountLogic>();
builder.Services.AddTransient<ITicketLogic, TicketLogic>();
builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapHub<SignalRHub>("/hub");

app.Run();