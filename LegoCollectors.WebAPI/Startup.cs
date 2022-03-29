using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using lego_collectors.Middleware;
using LegoCollectors.Core.IServices;
using LegoCollectors.DataAccess.Repositories;
using LegoCollectors.Domain.IRepositories;
using LegoCollectors.Domain.Service;
using LegoCollectors.Security;
using LegoCollectors.Security.Model;
using LegoCollectors.Security.Services;
//using LegoCollection.DataAccess;
//using LegoCollection.DataAccess.IRepository;
//using LegoCollection.DataAccess.IService;
//using LegoCollection.DataAccess.Model;
//using LegoCollection.DataAccess.Repositories;
//using LegoCollection.DataAccess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using VueCliMiddleware;

namespace lego_collectors
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {Title = "lego-collectors", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description =
                        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            // Dependency Injection.
            services.AddDbContext<AuthDbContext>(opt => { opt.UseSqlite("Data Source=auth.db"); });

            services.AddScoped<ILegoRepository, LegoRepository>();
            services.AddScoped<ILegoService, LegoService>();

            // Dependency Injection for security.
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();

            //
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtConfig:Issuer"],
                    ValidAudience = Configuration["JwtConfig:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtConfig:Secret"]))
                };
            });
            services.AddCors(options =>
            {
                options.AddPolicy("Development-cors", devPolicy =>
                {
                    devPolicy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    .WithExposedHeaders("X-Pagination");
                });
                options.AddPolicy("Production-cors", prodPolicy =>
                {
                    prodPolicy
                        .SetIsOriginAllowed(o => true)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    .WithExposedHeaders("X-Pagination");
                });
            });
            
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "../Vue";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IAuthDbSeeder authDbSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LegoCollectors v1"));
                app.UseCors("Development-cors");
                authDbSeeder.SeedDevelopment();
            }
            else
            {
                authDbSeeder.SeedProduction();
                app.UseCors("Production-cors");
            }

            app.UseRouting();
            app.UseMiddleware<JWTMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "../Vue";
                else
                    spa.Options.SourcePath = "dist";

                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }

            });
        }
    }
}