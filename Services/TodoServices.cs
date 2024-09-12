using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TodoAPI.AppDataContext;
using TodoAPI.Contracts;
using TodoAPI.Interface;
using TodoAPI.Models;

namespace TodoAPI.Services
{
    public class TodoServices : ITodoServices
    {
        private readonly ToDoDbContext _context;

        private readonly ILogger<TodoServices> _logger;

        private readonly IMapper _mapper;

        public TodoServices(
            ToDoDbContext context,
            ILogger<TodoServices> logger,
            IMapper mapper
        )
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTodoAsync(CreateTodoRequest request)
        {
            try
            {
                var todo = _mapper.Map<ToDo>(request);
                todo.CreatedAt = DateTime.UtcNow;
                _context.ToDos.Add (todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger
                    .LogError(ex,
                    "An error occured while creating the todo item.");
                throw new Exception("An error occured while creating the todo item");
            }
        }

        public Task DeleteTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            var todo = await _context.ToDos.ToListAsync();
            if (todo == null)
            {
                throw new Exception("No todo items found");
            }
            return todo;
        }

        public Task<ToDo> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTodoAsync(Guid id, UpdateTodoRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
