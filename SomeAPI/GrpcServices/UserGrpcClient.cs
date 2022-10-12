using AutoMapper;
using GrpcProtosLib;
using SomeAPI.DTO;

namespace SomeAPI.GrpcServices;

public class UserGrpcClient : IUserGrpcClient
{
    private readonly UserService.UserServiceClient _client;
    private readonly IMapper _mapper;

    public UserGrpcClient(UserService.UserServiceClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<UserDto> GetById(int id)
    {
        var request = new GetUserRequest() { UserId = id };
        var response = await _client.GetAsync(request);
        return _mapper.Map<UserDto>(response);
    }
    
    public async Task<List<UserDto>> GetAll()
    {
        var request = new GetAllRequest();
        var response =  _client.GetAll(request);

        var users = new List<UserDto>();
        while (await response.ResponseStream.MoveNext(CancellationToken.None))
        {
            var currentUser = response.ResponseStream.Current;
            users.Add(_mapper.Map<UserDto>(currentUser));
        }

        return users;
    }
}