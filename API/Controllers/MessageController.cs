using Microsoft.AspNetCore.Mvc;
using API.Services;
using Model;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        // 🔹 Get all messages
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.GetAllAsync();
            return Ok(messages);
        }

        // 🔹 Get message by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var message = await _messageService.GetByIdAsync(id);
            if (message == null)
                return NotFound();
            return Ok(message);
        }

        // 🔹 Create new message
        [HttpPost]
        public async Task<IActionResult> Create(Message message)
        {
            await _messageService.CreateAsync(message);
            return CreatedAtAction(nameof(GetById), new { id = message.Id }, message);
        }

        // 🔹 Update message
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Message updatedMessage)
        {
            await _messageService.UpdateAsync(id, updatedMessage);
            return NoContent();
        }

        // 🔹 Delete message
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _messageService.DeleteAsync(id);
            return NoContent();
        }
    }
}
