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
using Entity.Context;
using Entity.Entity;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.User.Service;
using Domain.Lender.Service;
using Domain.Loan.Service;
using Domain.SeedData;

namespace WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<LoanContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LoanDatabase")));
            services.AddDbContext<AplicationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AplicationDatabase")));

            services.AddIdentity<AplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AplicationContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ILoanService, LoanService>();


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
            SeedData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
