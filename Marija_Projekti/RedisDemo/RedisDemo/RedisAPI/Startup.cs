using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RedisAPI.BackgroundTasks;
using RedisAPI.Services;
using StackExchange.Redis;

namespace RedisAPI
{
    public class Startup
    {
        //https://dotnetcorecentral.com/blog/redis-cache-in-net-core-docker-container/
        //https://www.youtube.com/watch?v=jwek4w6als4
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IConnectionMultiplexer>(s =>
            ConnectionMultiplexer.Connect(Configuration.GetValue<string>("RedisConnection")));

            //services.AddSingleton<ICacheService, InMemoryCacheService>();
            services.AddSingleton<ICacheService, RedisCacheService>();

            services.AddHostedService<RedisSubscriber>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
        }
    }
}
