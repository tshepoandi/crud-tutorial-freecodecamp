using AutoMapper;
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

        public Task CreateTodoAsync(CreateTodoRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTodoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ToDo>> GetAllAsync()
        {
            throw new NotImplementedException();
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
