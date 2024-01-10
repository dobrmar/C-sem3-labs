using Lab4.DB;
using Lab4.Repositories;
using Lab4.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<Lab4Context>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Lab4"));
});

builder.Services.AddTransient<ICompService, CompService>();
builder.Services.AddTransient<ICompRepository, CompRepository>();

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();
app.Run();

