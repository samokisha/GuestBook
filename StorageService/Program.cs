using MassTransit;
using MessageContracts.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StorageService.Consumers;
using StorageService.Data;
using StorageService.MapperProfiles;
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
                    services.AddAutoMapper(typeof(CommentProfile));
                    
                    services.AddDbContext<GuestBookContext>(
                        builder =>
                            builder.UseSqlServer(hostContext.Configuration.GetConnectionString("GuestBook"))
                    );

                    services.AddScoped<ICommentRepository, CommentRepository>();

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<SaveCommentConsumer>();
                        
                        x.UsingRabbitMq((context, configurator) =>
                        {
                            configurator.Host("rabbitmq");
                            configurator.ConfigureEndpoints(context);
                        });
                        
                        x.AddRequestClient<NewCommentModel>();
                    }).AddMassTransitHostedService();
                });
    }
}