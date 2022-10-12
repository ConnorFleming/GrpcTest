using Grpc.Core;
using GrpcProtosLib;

namespace GrpcServer.GrpcServices;

public class UserGrpcService : UserService.UserServiceBase
{
    private readonly ILogger<UserGrpcService> _logger;

    private readonly List<GetUserResponse> UserResponses = new()
    {
        new GetUserResponse(){UserId = 1, Username = "John"},
        new GetUserResponse(){UserId = 2, Username = "Jane"},
        new GetUserResponse(){UserId = 3, Username = "Jim"},
    };

    public UserGrpcService(ILogger<UserGrpcService> logger)
    {
        // not using this but just to show we can inject whatever services we need in both server or client services
        _logger = logger;
    }

    public override async Task<GetUserResponse> Get(GetUserRequest request, ServerCallContext context)
    {
        // consume some other service here, return the result
        
        return UserResponses.Where(x => x.UserId == request.UserId).FirstOrDefault();
    }

    public override async Task GetAll(GetAllRequest request, IServerStreamWriter<GetUserResponse> responseStream, ServerCallContext context)
    {
        // consume some other service here, stream the result
        
        foreach (var user in UserResponses)
        {
            await responseStream.WriteAsync(user);
        }
    }
}