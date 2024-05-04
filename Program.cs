using PrometoFoodTrucksBackEnds.Services;
using PrometoFoodTrucksBackEnds.Services.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<UserServices>();
builder.Services.AddScoped<PasswordServices>();
builder.Services.AddScoped<FoodTrucksService>();

var connectionString = builder.Configuration.GetConnectionString("MyPrometoString");

builder.Services.AddDbContext<DataContext>(Options => Options.UseSqlServer(connectionString));

builder.Services.AddCors(options => options.AddPolicy("AppPolicy", 
 builder => {
    builder.WithOrigins("http://localhost:5264", "http://localhost:3000", "https://prometofoodtrucks.vercel.app")
    .AllowAnyHeader()
    .AllowAnyMethod();
 }
));

// Add services to the container.

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

app.UseCors("AppPolicy");

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
