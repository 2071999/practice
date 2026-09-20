var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<IWhatsAppService, WhatsAppService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// [SECTION: CORE APP SERVICES]
// Payment Gateway: Stripe payment client and checkout handler
builder.Services.AddHttpClient("StripePayment", client => {
    client.BaseAddress = new Uri("https://api.stripe.com/v1/");
    client.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddScoped<IPaymentGateway, StripePaymentGateway>();

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