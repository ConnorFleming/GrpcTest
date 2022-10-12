using AutoMapper;
using GrpcProtosLib;
using SomeAPI.DTO;

namespace SomeAPI.MappingProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // very simple dto just for sample
        CreateMap<GetUserResponse, UserDto>();
    }
}