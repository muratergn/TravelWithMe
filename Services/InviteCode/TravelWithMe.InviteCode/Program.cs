using Microsoft.EntityFrameworkCore;
using TravelWithMe.InviteCode.Context;
using TravelWithMe.InviteCode.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DapperContext>();
builder.Services.AddTransient<IInviteCodeServices, InviteCodeServices>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//deneme

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
