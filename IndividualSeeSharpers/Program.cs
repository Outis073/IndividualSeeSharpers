using System.Globalization;
using IndividualSeeSharpers.Data;
using IndividualSeeSharpers.Models;
using IndividualSeeSharpers.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SeeSharpersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SeeSharpersContext")));
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SeeSharpersContext>();

//Google Facebook login
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Google:ClientSecret"];
    })
    .AddFacebook(FacebookOptions =>
    {
        FacebookOptions.AppId = builder.Configuration["Facebook:AppId"];
        FacebookOptions.AppSecret = builder.Configuration["Facebook:AppSecret"];
    });

//Add Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminAccess", policy => policy.RequireRole("Admin"));

    options.AddPolicy("BackOfficeAccess", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Admin")
            || context.User.IsInRole("BackOffice")));

    options.AddPolicy("EmployeeAccess", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Admin")
            || context.User.IsInRole("BackOffice")
            || context.User.IsInRole("Cashier")));

    options.AddPolicy("CustomerAccess", policy =>
        policy.RequireAssertion(context =>
            context.User.IsInRole("Admin")
            || context.User.IsInRole("BackOffice")
            || context.User.IsInRole("Cashier")
            || context.User.IsInRole("Customer")));
});

//Connects MailSettings
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//Register MailService
builder.Services.AddTransient<IMailService, MailService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

//support globalization and localization
builder.Services.AddLocalization(option => { option.ResourcesPath = "Resources"; });
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var supportedCultures = new List<CultureInfo>
        {
            new CultureInfo("nl"),
            new CultureInfo("en")
        };
        opt.DefaultRequestCulture = new RequestCulture("nl");
        opt.SupportedCultures = supportedCultures;
        opt.SupportedUICultures = supportedCultures;
    });
builder.Services.AddControllersWithViews();

//builder
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
    SeedRoles.Initialize(services);
}
//localization
app.UseRequestLocalization(((IApplicationBuilder)app).ApplicationServices
    .GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Adds razor pages to register/login
app.MapRazorPages();

app.Run();