using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageService.Data;
using StorageService.Model;
using StorageService.Repositories;

namespace StorageService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<GuestBookContext>(
                        builder =>
                            builder.UseSqlServer(hostContext.Configuration.GetConnectionString("GuestBook"))
                        );

                    services.AddScoped<ICommentRepository, CommentRepository>();

                    services.AddHostedService<Worker>();
                });
    }
}