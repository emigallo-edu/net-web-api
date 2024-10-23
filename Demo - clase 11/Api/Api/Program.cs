using Api;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
             options => options.UseSqlServer(ApplicationDbContextFactory.CONNECTION_STRING, x =>
               x.MigrationsHistoryTable("_MigrationsHistory", "dbo")
               .CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)));
builder.Services.AddScoped<OrderRepository, OrderRepository>();

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
