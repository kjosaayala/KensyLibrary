using Application.AuthorServices;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebApi.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors();

// Register App Db
builder.Services.AddDbContext<KensyLibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

ServicesRegister.AddDependencyService(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "KensyLibraryAPI V1");
        });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseCors();

