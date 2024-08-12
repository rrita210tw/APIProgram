using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIProgram.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<BlogDbContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
        //}
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
