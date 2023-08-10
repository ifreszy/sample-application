using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Data.Database.Extensions;
using Repository.Extensions;
using Services.Extensions;
using Microsoft.OpenApi.Models;
using System;
using sample_application.Mappings.Extension;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.Auth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Data.Database.Utils;
using DatabaseContext;
//using ApplicationContext;

namespace sample_application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private string ResolveConnectionString => string.IsNullOrEmpty(Configuration.GetConnectionString("database")) ?
            Environment.GetEnvironmentVariable("POSTGRESQLCONNSTR_DATABASE")?.Trim() : Configuration.GetConnectionString("database");

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = (Configuration.GetConnectionString("type") == "ORACLE" ? 
                DataBaseType.ORACLE : DataBaseType.POSTGRESQL, ResolveConnectionString);

            services.AddSingleton(sp => new ConnectionSettings()
            {
                Type = connectionString.Item1,
                Database = connectionString.Item2
            });

            services.AddDbContext<ApplicationContext>(opt =>
            {
                Console.WriteLine(connectionString.Item1);
                if (connectionString.Item1 == DataBaseType.POSTGRESQL)
                {
                    opt.UseNpgsql(connectionString.Item2, opt =>
                    {
                        opt.MigrationsAssembly(@"MigrationsPostgreSQL");
                    });
                }

                if (connectionString.Item1 == DataBaseType.ORACLE) 
                {
                    opt.UseOracle(connectionString.Item2, opt =>
                    {
                        opt.MigrationsAssembly(@"MigrationsOracle");
                    });
                }
            });

            services.AddDbConnection(connectionString.Item2, connectionString.Item1);
            services.AddMappers();
            services.AddRepositories();
            services.AddServices();

            #region JWT Auth config
            var tokenSettings = new AuthSettings();

            Configuration.GetSection("AuthSettings").Bind(tokenSettings);

            services.AddAuth(tokenSettings);
            #endregion
            services.AddCors();
            services.AddControllers();

            #region JWT Setup
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenSettings.Key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "sample_application",
                    Version = "v1",
                    Description = "Sample application using repository pattern and EF core for migrations",
                    Contact = new OpenApiContact()
                    {
                        Url = new Uri("https://github.com/ifreszy/sample-application")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a token",
                    Name = "Authorization",
                    BearerFormat = "JWT",
                    Scheme = "Bearer",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "sample application"));
            }

            app.UseHttpsRedirection();

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyHeader();
                x.AllowAnyMethod();
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
