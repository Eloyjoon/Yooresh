﻿using Hangfire;
using Yooresh.Application.Common.Interfaces;
using Yooresh.Infrastructure.EmailTools;
using Yooresh.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Yooresh.Domain.Interfaces;
using Yooresh.Infrastructure.JobTools;

namespace Yooresh.Infrastructure;

public static class ConfigureServices
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<Context>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(Context).Assembly.GetName().Name)
            ));

        services.AddScoped<IContext, Context>();

        var senderEmail = configuration.GetSection("Email")!["Address"]!;
        var senderPassword = configuration.GetSection("Email")!["Password"]!;
        
        services.AddScoped<IEmail>(s=> new Email(senderEmail, senderPassword));
        
        services.AddHangfire(x => x.UseSqlServerStorage(configuration.GetConnectionString("DefaultConnection")));
        services.AddHangfireServer();
        
        services.AddScoped<IJob, Job>();


    }
}