using SomeAPI.DTO;

namespace SomeAPI.GrpcServices;

public interface IUserGrpcClient
{
    public Task<UserDto> GetById(int id);
    public Task<List<UserDto>> GetAll();
}