using API1.Models;
using API1.UserRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepo, UserRepo>();

builder.Services.AddDbContext<ContextDB>(otp => otp.UseSqlServer(
    builder.Configuration.GetConnectionString("ScoreRatingDBConnection")));
//Allow CORS Policy
builder.Services.AddCors(p => p.AddDefaultPolicy(build =>
{
    build.WithOrigins("http://localhost:4200");
    build.AllowAnyMethod();
    build.AllowAnyHeader();

}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllers();
});

app.Run();