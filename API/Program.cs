using Presistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Application.Activities;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(_config);
});
builder.Services.AddMediatR(typeof(List.Handler).Assembly);

var context = builder.Services.BuildServiceProvider().GetService<DataContext>();
context.Database.Migrate();

Seed.SeedData(context).Wait();



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
