using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;
using TodoListApi.Services;

namespace TodoListApi.Controllers;

[ApiController]
[Route("api/[controller]")]

    public class TodoListController : ControllerBase
    {
        private readonly TodoListService _todoListService;
        public TodoListController(TodoListService todoListService) { 
               this._todoListService = todoListService;
        }
    [HttpGet]
    public async Task<List<TodoListItem>> Get() =>
        await _todoListService.GetAsync();
    }
