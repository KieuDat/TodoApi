using TodoApi.Models;
using TodoItemApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService) =>
        _todoService = todoService;

    [HttpGet]
    public async Task<List<TodoItem>> Get() =>
        await _todoService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<TodoItem>> Get(string id)
    {
        var todo = await _todoService.GetAsync(id);

        if (todo is null)
        {
            return NotFound();
        }

        return todo;
    }

    [HttpPost]
    public async Task<IActionResult> Post(TodoItem newtodo)
    {
        await _todoService.CreateAsync(newtodo);

        return CreatedAtAction(nameof(Get), new { id = newtodo.Id }, newtodo);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, TodoItem updatedtodo)
    {
        var todo = await _todoService.GetAsync(id);

        if (todo is null)
        {
            return NotFound();
        }

        updatedtodo.Id = todo.Id;

        await _todoService.UpdateAsync(id, updatedtodo);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var todo = await _todoService.GetAsync(id);

        if (todo is null)
        {
            return NotFound();
        }

        await _todoService.RemoveAsync(id);

        return NoContent();
    }
}