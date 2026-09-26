var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddScoped<IWhatsAppService, WhatsAppService>();
builder.Services.AddScoped<IEmailService, EmailService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options => {
        options.Authority = "https://auth.company.com";
        options.Audience = "practice-api";
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpClient("StripePayment", client => {
    client.BaseAddress = new Uri("https://api.stripe.com/v1/");
    client.Timeout = TimeSpan.FromSeconds(30);
});
builder.Services.AddScoped<IPaymentGateway, StripePaymentGateway>();

// [DEVELOP]: Customer Loyalty and Rewards Program
builder.Services.AddScoped<ILoyaltyService, LoyaltyService>();
builder.Services.AddScoped<IRewardsEngine, RewardsEngine>();

var app = builder.Build();

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