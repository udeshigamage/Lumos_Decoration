using Microsoft.EntityFrameworkCore;
using Deco_Sara.dbcontext__;
using Deco_Sara.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure MySQL Database
builder.Services.AddDbContext<Appdbcontext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31)) // Replace with your MySQL version
    ));

// Register custom services
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IFeedbackService, FeedbackService>();

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // React app origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable CORS
app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
