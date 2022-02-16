using System.Security.Claims;
using Auth0Net.DependencyInjection.HttpClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = "Auth0";
    options.DefaultChallengeScheme = "Auth0";
}).AddJwtBearer("Auth0",options =>
{
    options.Authority = "https://dev-cpt-j07e.au.auth0.com/".ToHttpsUrl();
    options.Audience = "https://thisisarealapiendpoint.com/".ToHttpsUrl();
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        NameClaimType = ClaimTypes.NameIdentifier
    };
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

builder.Services.AddAuth0AuthenticationClient(config =>
{
    config.ClientId = builder.Configuration["Auth0:ClientId"];
    config.ClientSecret = builder.Configuration["Auth0:ClientSecret"];
    config.Domain = builder.Configuration["Auth0:Domain"];
});
var MyCors = "MyCors";
builder.Services.AddAuth0ManagementClient().AddManagementAccessToken();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCors,
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseCors(MyCors);
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
