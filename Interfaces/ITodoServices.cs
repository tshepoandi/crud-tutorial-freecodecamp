using TodoAPI.Contracts;
using TodoAPI.Models;

namespace TodoAPI.Interface
{
    public interface ITodoServices
    {
        Task<IEnumerable<ToDo>> GetAllAsync();

        Task<ToDo> GetByIdAsync(Guid id);

        Task CreateTodoAsync(CreateTodoRequest request);

        Task UpdateTodoAsync(Guid id, UpdateTodoRequest request);

        Task DeleteTodoAsync(Guid id);
    }
}
