using System;
using System.Collections.Generic;
using System.Text;
using Domain.User.Service;
using Entity.Context;
using Entity.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
namespace Domain.Helpers
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddUserServiceLoanDbContext(this IServiceCollection services)
        {
            services.AddDbContext<LoanContext>(x => x.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=LoanDb;Integrated Security=True"));
            return services;
        }
    }

}
