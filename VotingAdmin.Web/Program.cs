using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Authorization;
using VotingAdmin.Web.Extensions;
using VotingAdmin.Web.Infrastructure.Mapper;
using VotingAdmin.Web.Middleware;
using VotingAdmin.Web.Services.Http.Voting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(config => config.Filters.Add(new AuthorizeFilter()));
builder.Services.AddHttpContextAccessor();
builder.Services.AddNotyf(config => { config.DurationInSeconds = 5; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
builder.Services.AddAuthenticationServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddHostedApplicationServices();
builder.Services.ConfigureApplicationAndServices(builder.Configuration);
builder.Services.AddHttpClient();
builder.Services.AddHttpClient(VotingApiDefaults.HttpClientVotingApi, client =>
{
    client.DefaultRequestHeaders.Clear();
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("VotingApi:BaseUrl"));
    client.Timeout = new TimeSpan(0, 0, 30);
});

builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Home/HandleError/{0}");
app.UseCookiePolicy();

app.UseSession();
app.UseNotyf();

//app.UseStatusCodePagesWithReExecute("/errors/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
// Auth Middleware
app.UseMiddleware<AuthMiddleware>();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
