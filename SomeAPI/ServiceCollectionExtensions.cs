using Grpc.Net.Client;
using GrpcProtosLib;
using SomeAPI.GrpcServices;

namespace SomeAPI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IUserGrpcClient, UserGrpcClient>(); // the service
        services.AddTransient(x => new UserService.UserServiceClient(
            GrpcChannel.ForAddress(configuration.GetValue<string>("GrpcAddress")))); // the client that will connect to the server
        
        return services;
    }
}