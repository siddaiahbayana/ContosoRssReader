var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5213", "https://localhost:7019")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("LocalFrontend");

var subscriptions = new List<Subscription>();

app.MapGet("/api/subscriptions", () =>
{
    var ordered = subscriptions
        .OrderBy(item => item.CreatedAt)
        .ToList();

    return Results.Ok(new SubscriptionListResponse(ordered));
});

app.MapPost("/api/subscriptions", (CreateSubscriptionRequest request) =>
{
    if (string.IsNullOrWhiteSpace(request.Url))
    {
        return Results.BadRequest(new { error = "Subscription URL is required." });
    }

    var url = request.Url.Trim();
    var subscription = new Subscription(Guid.NewGuid().ToString(), url, DateTimeOffset.UtcNow);
    subscriptions.Add(subscription);

    return Results.Created($"/api/subscriptions/{subscription.Id}", new { subscription });
});

app.Run();

public record Subscription(string Id, string Url, DateTimeOffset CreatedAt);
public record SubscriptionListResponse(List<Subscription> Subscriptions);
public record CreateSubscriptionRequest(string Url);
