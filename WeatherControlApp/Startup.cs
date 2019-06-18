using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WeatherControlApp.Models;

namespace WeatherControlApp
{
    public class Startup
    {
       public IConfiguration Configuration {get;}

           public Startup(IConfiguration configuration) => Configuration = configuration;

        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WeatherContext>
                (opt => opt.UseSqlServer(Configuration["Data:WeatherAPIConnection:ConnectionString"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
           app.UseMvc();
        }
    }
}
