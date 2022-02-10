using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Identity.Web;
using SandboxAPI;
using SandboxAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});
builder.Services.AddAuthentication( options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Auth0",options =>
{
    options.Authority = "https://dev-bujpp543.us.auth0.com/";
    options.Audience = "https://thisisarealapiendpoint.com/";
});
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();

    foreach (var scope  in SandboxScopes.Scopes)
    {
        options.AddPolicy(scope, p => p.Requirements.Add(new ScopeAuthorizationRequirement()));
    }
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<ScopeAuthorizationRequirement>();

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
    options.AddPolicy(name: MyCors,
        builder =>
        {
            builder.AllowAnyOrigin();
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
app.UseStaticFiles();
app.UseCors(MyCors);
app.UseAuthorization();
app.UseAuthentication();
app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", 
        template: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllers();

app.Run();
