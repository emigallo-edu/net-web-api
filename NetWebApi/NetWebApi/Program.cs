using Model;
using NetWebApi.Context;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDbContext();
//builder.Services.AddScoped<IClubRepository, ClubFileRepository>((Iservicepri) => new ClubFileRepository(Path.Combine(Environment.CurrentDirectory, "Files")));
builder.Services.AddScoped<IClubRepository, ClubDbRepository>();

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
