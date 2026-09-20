var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<IWhatsAppService, WhatsAppService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// [SECTION: CORE APP SERVICES]
// Team Security: JWT Authentication and Authorization setup
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options => {
        options.Authority = "https://auth.company.com";
        options.Audience = "practice-api";
    });
builder.Services.AddAuthorization();

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