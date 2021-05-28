using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using SpecFlow.Gherkin.Domain.Support.Extensions;
using SpecFlow.Gherkin.Data.DDL.Support.Options.Extensions;
using SpecFlow.Gherkin.Data.DML.Support.Options.Extensions;

namespace SpecFlow.Gherkin.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();

            services.AddControllers();

            services.AddHealthChecks()
                .AddSqlServer(
                    name: "Database",
                    connectionString: Configuration["ConnectionStrings:Database:ConnectionString"],
                    tags: new string[] { "sqlserver" })
                .AddSqlServer(
                    name: "CustomerBase",
                    connectionString: Configuration["ConnectionStrings:CustomerBase:ConnectionString"],
                    tags: new string[] { "sqlserver" });

            services.AddOptions();

            services
                .AddDomain(Configuration)
                .AddDdlData(Configuration)
                .AddDmlData(Configuration);

            services.BuildServiceProvider()
                .AddDataProvider();

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SpecFlow Gherkin Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    ResponseWriter = WriteResponse
                });
            });

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "SpecFlow Gherkin Api V1");
            }); ;
        }

        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));

            return context.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }
    }
}