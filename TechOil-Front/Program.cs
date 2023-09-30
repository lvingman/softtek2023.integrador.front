using Microsoft.AspNetCore.Authentication.Cookies;

namespace TechOilFront
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient("useApi", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServiceUrl:ApiUrl"]);
                // client.DefaultRequestHeaders.Add("User-Agent", "Mi proyecto Razor");
            });

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
            {
                config.Events.OnRedirectToLogin = context =>
                {
                    context.Response.Redirect("https://localhost:7150");
                    return Task.CompletedTask;
                };
            }); 
            
            
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole("Administrador");
                });
            });

            builder.Services.AddSession(); //Todo: Para que es esto?
            
            var app = builder.Build();

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
            app.UseSession();

            
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Login}/{id?}");

            app.Run();
        }
    }
}