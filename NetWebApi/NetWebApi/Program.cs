using Model.Entities;
using NetWebApi.Context;
using NetWebApi.Middlewares;
using NetWebApi.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(
    
    // Manejo de Exception por Filter
//    options =>
//{
//    options.Filters.Add<CustomExceptionFilter>();
//}

);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDbContext();
builder.Services.AddRepositories(DatabaseType.SqlServer);

builder.Services.AddAutoMapper(configuration =>
{
    configuration.CreateMap<ClubDTO, Club>();
    //configuration.CreateMap<AutorCreacionDTO, Autor>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ApplicationDbContextFactoryConfig.SetProvider(app.Services);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
// app.SetUpUseAndRun();

// Maneja de Exception por Middleware app.UseMiddleware<ExceptionMiddleware>();

app.Run();