using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MultipleDbAPI.Models;
using MultipleDbAPI.Services;

namespace MultipleDbAPI
{
    public class Startup
    {
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMultipleDbAPIDatabaseSettings>(p => new MultipleDbAPIDatabaseSettings
            {
                ConnectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING"),
                DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME"),
                employeeCollectionName = nameof(Employee),
                departmentCollectionName=nameof(Department)
            });
            services.AddTransient<EmployeeService>();
            services.AddTransient<DepartmentService>();
            services.AddTransient<EmployeeDetailsService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }
    }
}
