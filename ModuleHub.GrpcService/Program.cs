#region    USINGS

using ModuleHub.Application;
using ModuleHub.Contracts;
using ModuleHub.Contracts.Interfaces;
using ModuleHub.DataAccess;
using ModuleHub.DataAccess.Contexts;
using ModuleHub.DataAccess.Repositories.Common;
using ModuleHub.GrpcService.Services;
using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography.X509Certificates;
using ModuleHub.Application.DataSourcesCQRS.Commands.CreateDataSource;
using AssemblyReference = ModuleHub.Application.AssemblyReference;

#endregion

namespace ModuleHub.GrpcService;

public class Program
{
    public static void Main(string[] args)
    {




        var builder = WebApplication.CreateBuilder(args);

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682


        // Add services to the container.
        builder.Services.AddAutoMapper(typeof(Program).Assembly);


        builder.Services.AddGrpc(options =>
        {
            options.EnableDetailedErrors = true;
            options.MaxReceiveMessageSize = 2 * 1024 * 1024; //2 Mb
            options.MaxSendMessageSize = 5 * 1024 * 1024;
        });



        builder.Services.AddMediatR(new MediatRServiceConfiguration()
        {
            AutoRegisterRequestProcessors = true,
        }
        .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));


        // Add services to the container.
        builder.Services.AddGrpc();
        builder.Services.AddSingleton("Data Source = ModuleHub_DB.sqlite");
        builder.Services.AddScoped<ApplicationContext>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IDataSourceRepository, DataSourceRepository>();
        builder.Services.AddScoped<ICommunicationClientRepository, CommunicationClientRepository>();
        builder.Services.AddScoped<ICommunicationNodeRepository, CommunicationNodeRepository>();


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<DataSourceService>();
        app.MapGrpcService<CommunicationClientService>();
        app.MapGrpcService<OPCNodeService>();
        app.MapGrpcService<ModbusNodeService>();


        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();

    }


}