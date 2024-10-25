using Microsoft.Extensions.Options;
using synctakerWeb.Components;

namespace synctakerWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("BlazorCorsPolicy", policy =>
                {
                    policy.WithOrigins("https://localhost:7299") // Zast¹p [TWOJE_IP] i [PORT] odpowiednimi wartoœciami dla Blazor Server
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddScoped<WeatherForecastService>();
            builder.Services.AddHttpClient("WeatherApi", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7219");
            });

            var app = builder.Build();

            app.UseCors("BlazorCorsPolicy");

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}