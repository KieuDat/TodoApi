using Microsoft.AspNetCore.Mvc;
using User.Services;
using UserApi.Models;

namespace UserApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class UserController : Controller
    {
    private readonly UserService _userService;
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<List<UserItem>> Get() => 
        await _userService.GetUsersAsync();
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<UserItem>> Get(string id)
    {
        var user = await _userService.GetAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> Post(UserItem newUser)
    { 
        await _userService.CreateAsync(newUser);
        return Ok();
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, UserItem updateUser)
    {
        var user = await _userService.GetAsync(id);
        if (user == null) { 
            return NotFound();
        }
        updateUser.Id = user.Id;
        await _userService.UpdateAsync(id, updateUser);
        return Ok(user);
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id) {
        var user = await _userService.GetAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        await _userService.RemoveAsync(id);
        return Ok();
    }
    }