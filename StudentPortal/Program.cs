using Microsoft.Extensions.Options;
using StudentPortal.Extensions;
using StudentPortal.Middlewares;
using StudentPortal.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLocalization();
builder.Services.ConfigureResponseCaching();
builder.Services.ConfigureScopedService();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.ConfigureViews();
builder.Services.ConfigureSessionAndCookie();

WebApplication app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    _ = app.UseDeveloperExceptionPage();
}
else
{
    _ = app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    _ = app.UseHsts();
}

app.UseHttpsRedirection();
app.UseFileServer();
app.UseRouting();
app.UseCors();
app.UseSession();
app.UseCookiePolicy();
app.UseResponseCaching();
app.UseRequestLocalization(app.Services.GetService<IOptions<RequestLocalizationOptions>>().Value);

app.UseMiddleware<JwtMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Authorization}/{action=Login}/{id?}");

app.Run();
