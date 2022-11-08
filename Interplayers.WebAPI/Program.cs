using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Domain.PasswordRules;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Endpoints.ValidatePassword;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Implementations
builder.Services.AddSingleton<PasswordRulesOptions>(c => configuration.GetSection(PasswordRulesOptions.SectionName).Get<PasswordRulesOptions>());
builder.Services.AddSingleton<IPasswordRulesProvider, PasswordRulesProvider>();

// Use cases (or services)
builder.Services.AddSingleton<ValidatePasswordHandler>();

// Endpoint bindings
var app = builder.Build();
app.MapPost("/validate-password", ValidatePasswordEndpoint.Handle);

app.Run("http://localhost:5000");