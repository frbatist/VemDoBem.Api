using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using VemDoBem.Domain.Entidades;
using VemDoBem.Infra.Data;

namespace VemDoBem.Api
{
    public class Startup
    {
        const string ConnectionStringEnviromentVariable = "DB_CONNECTION_STRING";
        const string ConnectionStringJsonConfig = "DefaultConnection";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            Console.WriteLine("construiu o startup");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("entron no ConfigureServices");
            var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnviromentVariable);
            if (string.IsNullOrWhiteSpace(connectionString))
                connectionString = Configuration.GetConnectionString(ConnectionStringJsonConfig);
            Console.WriteLine($"connection string: {connectionString}");
            services.AddDbContext<ContextoVemDoBem>(
                options => options.UseNpgsql(connectionString));

            services.AddIdentity<Usuario, AppRole>()
                .AddEntityFrameworkStores<ContextoVemDoBem>()
                .AddRoles<AppRole>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtIssuer"],
                        ValidAudience = Configuration["JwtAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                    };
                });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            await ApplyMigrations(app);
        }

        private static async Task ApplyMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ContextoVemDoBem>())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }
    }
}
