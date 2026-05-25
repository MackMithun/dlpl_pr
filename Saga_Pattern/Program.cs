using Microsoft.OpenApi;
using Npgsql;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Implementations;
using Saga_Pattern.Dapper.Repositories.PatientRepository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//get the connection
builder.Services.AddScoped<NpgsqlConnection>(sp =>
    new NpgsqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")));
// Repository Registration
builder.Services.AddScoped<IPatientGetData, PatientGetData>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("localhost",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Saga Pattern API",
        Version = "v1"
    });
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Saga Pattern API v1");
    });
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("localhost");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
