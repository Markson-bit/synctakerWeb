using Microsoft.Extensions.Options;
using synctakerWeb.Components;
using System;

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
                    policy.WithOrigins("https://localhost:7299")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            //builder.Services.AddScoped<UserService>();
            builder.Services.AddSingleton<UserService>();

            builder.Services.AddScoped<ProjectService>();
            builder.Services.AddScoped<TaskService>();
            builder.Services.AddScoped<StatusService>();

            builder.Services.AddHttpClient("ApiClient", client =>
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