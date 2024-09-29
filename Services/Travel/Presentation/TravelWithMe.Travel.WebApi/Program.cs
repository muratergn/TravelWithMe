using Microsoft.EntityFrameworkCore;
using TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelDetailHandlers;
using TravelWithMe.Travel.Application.Features.CQRS.Handlers.TravelHandlers;
using TravelWithMe.Travel.Application.Interfaces;
using TravelWithMe.Travel.Application.Services;
using TravelWithMe.Travel.Persistence.Context;
using TravelWithMe.Travel.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ITravelRepository), typeof(TravelRepository));
builder.Services.AddApplicationService(builder.Configuration);

/*builder.Services.AddScoped<CreateTravelCommandHandler>();
builder.Services.AddScoped<GetTravelByIdQueryHandler>();
builder.Services.AddScoped<GetTravelQueryHandler>();
builder.Services.AddScoped<UpdateTravelCommandHandler>();
builder.Services.AddScoped<RemoveTravelCommandHandler>();*/

builder.Services.AddScoped<CreateTravelDetailCommandHandler>();
builder.Services.AddScoped<GetTravelDetailByIdQueryHandler>();
builder.Services.AddScoped<GetTravelDetailQueryHandler>();
builder.Services.AddScoped<UpdateTravelDetailCommandHandler>();
builder.Services.AddScoped<RemoveTravelDetailCommandHandler>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TravelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
