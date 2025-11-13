using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetAllAsync();
        Task<Message?> GetByIdAsync(string id);
        Task CreateAsync(Message message);
        Task UpdateAsync(string id, Message updatedMessage);
        Task DeleteAsync(string id);
    }
}
