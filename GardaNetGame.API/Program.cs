using GardaNetGame.Shared.Entities;
using GardaNetGame.Shared.Interfaces;
using FastEndpoints;
using GardaNetGame.DataAccess.Repository;
//using Microsoft.EntityFrameworkCore;
//using GardaNetGame.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddSingleton<IEventService<Event>, EventRepository>();
builder.Services.AddSingleton<IEventTypeService<EventType>, EventTypeRepository>();
builder.Services.AddSingleton<IGenreService<Genre>, GenreRepository>();
builder.Services.AddSingleton<IGameService<Game>, GameRepository>();
builder.Services.AddSingleton<IOrderService<GardaNetGame.Shared.Entities.Order>, OrderRepository>();
builder.Services.AddSingleton<ICustomerService<Customer>, CustomerRepository>();

var app = builder.Build();

app.UseFastEndpoints();

app.Run();
