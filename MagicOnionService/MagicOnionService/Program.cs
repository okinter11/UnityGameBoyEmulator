using Grpc.Net.Client;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace MagicOnionService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.WebHost.ConfigureKestrel(options =>
        {
            // WORKAROUND: Accept HTTP/2 only to allow insecure HTTP/2 connections during development.
            options.ConfigureEndpointDefaults(endpointOptions => { endpointOptions.Protocols = HttpProtocols.Http2; });
        });
        builder.Services.AddControllersWithViews();
        builder.Services.AddGrpc(); // MagicOnion depends on ASP.NET Core gRPC service.
        builder.Services.AddMagicOnion();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        var methodHandlers = app.Services
                                .GetService<MagicOnion.Server.MagicOnionServiceDefinition>()!
                                .MethodHandlers;
        app.MapMagicOnionHttpGateway("_", methodHandlers, GrpcChannel.ForAddress("https://localhost:5001"));
        app.MapMagicOnionSwagger("swagger", methodHandlers, "/_/");

        app.MapMagicOnionService();

        app.Run();
    }
}