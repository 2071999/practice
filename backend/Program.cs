var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
// Fraser's Email Service
builder.Services.AddScoped<IEmailService, EmailService>();


// Connection string from configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register application services (practice area for merge conflicts)
// [LINE 10]: Services registration area

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/status", () => Results.Ok(new { 
    status = "Active", 
    system = "Practice Git System",
    timestamp = DateTime.UtcNow 
}));

app.Run();