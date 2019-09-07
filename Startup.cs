using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditCard_Transactions.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CreditCard_Transactions
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
            if (Configuration.GetSection("FeatureToggle").GetSection("UseMockData").Value == "yes")
            {
                services.AddTransient<ITransactionRepository, MockTransactionRepository>();
                services.AddTransient<IUsersTransactionRepository, MockUsersTransactionRepository>();
            }
            else
            {
                services.AddTransient<IHelper, Helper>();
                services.AddTransient<ITransactionRepository, TransactionRepository>();
                services.AddTransient<IUsersTransactionRepository, UsersTransactionRepository>();
            }

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
