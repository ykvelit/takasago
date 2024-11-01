using MediatR;
using Microsoft.EntityFrameworkCore;
using Takasago.Data;
using Takasago.Domain;
using Takasago.UseCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqlServer");
builder.Services.AddDbContext<AppDbContext>((services,options) =>
{
    options.UseSqlServer(connectionString);
    options.AddInterceptors(services.GetRequiredService<SetUserIdInUserPreferenceInterceptor>());
    options.EnableSensitiveDataLogging();
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<CurrentUser>();
builder.Services.AddScoped<UserPreferenceStore>();
builder.Services.AddScoped<SetUserIdInUserPreferenceInterceptor>();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(CreateUserPreference).Assembly));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();
}

app.MapPost("/api/v1/user-preferences", async (AppDbContext db, CreateUserPreference.Request request, ISender sender,
    CancellationToken cancellationToken) =>
{
    await sender.Send(request, cancellationToken);
    await db.SaveChangesAsync(cancellationToken);
});

app.MapGet("/api/v1/user-preferences/{key}", async (string key, ISender sender, CancellationToken cancellationToken) =>
{
    var request = new GetUserPreferences.Request(key);
    return await sender.Send(request, cancellationToken);
});

await app.RunAsync();