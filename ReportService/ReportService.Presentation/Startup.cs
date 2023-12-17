using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Npgsql;
using ReportService.Application.Queries.GetReportData;
using ReportService.Infrastructure.HttpClients.AccountingService;
using ReportService.Infrastructure.Repositories.Department;
using ReportService.Infrastructure.Repositories.Employee;
using ReportService.Infrastructure.Repositories.Options;

namespace ReportService.Presentation
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
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IAccountingServiceHttpClient, AccountingServiceHttpClient>();
            
            services.AddTransient<GetReportDataQueryHandler>();
            
            services.Configure<AccountingServiceHttpClientOptions>(
                Configuration.GetSection(nameof(AccountingServiceHttpClientOptions)));
            services.Configure<DatabaseOptions>(
                Configuration.GetSection(nameof(DatabaseOptions)));
            services.AddTransient<IDbConnection>(serviceProvider =>
            {
                var dbSettings = serviceProvider.GetRequiredService<IOptions<DatabaseOptions>>().Value;
                return new NpgsqlConnection(dbSettings.ConnectionString);
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReportService.Presentation", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReportService.Presentation v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}