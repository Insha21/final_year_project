using MongoDB.Driver;
using Microsoft.Extensions.Options;
using Model;
using API.MongoModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMongoCollection<Message> _messages;

        public MessageService(IOptions<MongoDBSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);

            // Make sure this matches your collection name
            _messages = database.GetCollection<Message>("Message");
        }

        // 🔹 Get all messages
        public async Task<List<Message>> GetAllAsync()
        {
            return await _messages.Find(m => true).ToListAsync();
        }

        // 🔹 Get message by ID
        public async Task<Message?> GetByIdAsync(string id)
        {
            return await _messages.Find(m => m.Id == id).FirstOrDefaultAsync();
        }

        // 🔹 Create new message
        public async Task CreateAsync(Message message)
        {
            message.SentAt = DateTime.UtcNow;
            await _messages.InsertOneAsync(message);
        }

        // 🔹 Update message by ID
        public async Task UpdateAsync(string id, Message updatedMessage)
        {
            await _messages.ReplaceOneAsync(m => m.Id == id, updatedMessage);
        }

        // 🔹 Delete message by ID
        public async Task DeleteAsync(string id)
        {
            await _messages.DeleteOneAsync(m => m.Id == id);
        }

        public Task<List<Message>> GetAllMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message?> GetMessageByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task AddMessageAsync(Message message)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMessageAsync(string id, Message updatedMessage)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMessageAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
