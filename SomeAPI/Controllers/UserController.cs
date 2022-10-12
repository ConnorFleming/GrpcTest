using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SomeAPI.GrpcServices;

namespace SomeAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    // this would obviously be done in a service/mediatr instead of controller
    private readonly IUserGrpcClient _client;
    public UserController(IUserGrpcClient client)
    {
        _client = client;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _client.GetById(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _client.GetAll();
        return Ok(users);
    }
}