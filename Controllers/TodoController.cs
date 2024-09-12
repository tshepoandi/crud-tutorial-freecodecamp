using Microsoft.AspNetCore.Mvc;
using TodoAPI.Contracts;
using TodoAPI.Interface;

namespace TodoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoServices _todoService;

        public TodoController(ITodoServices todoService)
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<IActionResult>
        CreateTodoAsync(CreateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _todoService.CreateTodoAsync(request);
                return Ok(new { message = "post created successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500,
                new { message = "an error occured grootman." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var todo = await _todoService.GetAllAsync();
                if (todo == null || !todo.Any())
                {
                    return Ok(new { message = "No Todo Item found" });
                }
                return Ok(new {
                    message = "Succesfully retrived all blog post",
                    data = todo
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
