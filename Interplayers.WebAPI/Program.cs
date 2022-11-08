using Interplayers.Application.UseCases.ValidatePassword;
using Interplayers.Domain.PasswordRules;
using Interplayers.Infrastructure.Implementations.Locale;
using Interplayers.Infrastructure.Implementations.Locale.Languages;
using Interplayers.Infrastructure.Implementations.PasswordRules;
using Interplayers.WebAPI.Endpoints.ValidatePassword;
using Interplayers.WebAPI.Locale;
using Interplayers.WebAPI.Locale.Languages;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// ASP.NET classes
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 

// Locale
builder.Services.AddSingleton<ILanguageProvider, LanguageProvider>();
builder.Services.AddScoped<ILanguageDecider, HttpLanguageDecider>();

// Implementations
builder.Services.AddSingleton<PasswordRulesOptions>(c => configuration.GetSection(PasswordRulesOptions.SectionName).Get<PasswordRulesOptions>());
builder.Services.AddSingleton<IPasswordRulesProvider, PasswordRulesProvider>();

// Use cases (or services)
builder.Services.AddSingleton<ValidatePasswordHandler>();

// Endpoint bindings
var app = builder.Build();
app.MapPost
(
    "/validate-password", 
    (
        [FromServices]ILanguageDecider languageDecider, 
        [FromServices]ValidatePasswordHandler handler, 
        [FromBody]ValidatePasswordParameters parameter
    ) => ValidatePasswordEndpoint.Handle(languageDecider, handler, parameter)
);

app.Run("http://localhost:5000");