using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Domain.PasswordRules;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Endpoints.ValidatePassword;
using Interplayers.WebAPI.Locale;
using Interplayers.WebAPI.Locale.Languages;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ASP.NET classes
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

// Locale
builder.Services.AddSingleton<LanguageProvider>(c => LanguageProvider.Create(c));
builder.Services.AddScoped<ILanguageDecider, HttpLanguageDecider>();

// Implementations
builder.Services.AddSingleton<PasswordRulesOptions>(c => configuration.GetSection(PasswordRulesOptions.SectionName).Get<PasswordRulesOptions>());
builder.Services.AddSingleton<IPasswordRulesProvider, PasswordRulesProvider>();

// Use cases (or services)
builder.Services.AddSingleton<ValidatePasswordHandler>();

// Endpoint bindings
var app = builder.Build();
app.MapPost("/validate-password", ValidatePasswordEndpoint.Handle);

app.Run("http://localhost:5000");