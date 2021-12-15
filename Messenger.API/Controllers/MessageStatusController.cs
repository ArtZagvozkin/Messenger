using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Messenger.Domain;
using Messenger.Infrastructure;
using Messenger.Infrastructure.Repository;

namespace Messenger.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageStatusController : ControllerBase
    {
        private readonly Context _context;
        private readonly MessageStatusRepository _messageStatusRepository;

        public MessageStatusController(Context context)
        {
            _context = context;
            _messageStatusRepository = new MessageStatusRepository(_context);
        }

        // GET: api/MessageStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageStatus>>> GetMessageStatuses()
        {
            return await _messageStatusRepository.GetAllAsync();
        }

        // GET: api/MessageStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageStatus>> GetMessageStatus(Guid id)
        {
            var messageStatus = await _messageStatusRepository.GetByIdAsync(id);

            if (messageStatus == null)
            {
                return NotFound();
            }

            return messageStatus;
        }

        // PUT: api/MessageStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageStatus(Guid id, MessageStatus messageStatus)
        {
            if (id != messageStatus.Id)
            {
                return BadRequest();
            }

            await _messageStatusRepository.UpdateAsync(messageStatus);

            return NoContent();
        }

        // POST: api/MessageStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageStatus>> PostMessageStatus(MessageStatus messageStatus)
        {
            await _messageStatusRepository.AddAsync(messageStatus);

            return CreatedAtAction("GetMessageStatus", new { id = messageStatus.Id }, messageStatus);
        }

        // DELETE: api/MessageStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageStatus(Guid id)
        {
            var messageStatus = await _messageStatusRepository.GetByIdAsync(id);
            if (messageStatus == null)
            {
                return NotFound();
            }

            await _messageStatusRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool MessageStatusExists(Guid id)
        {
            return _context.MessageStatuses.Any(e => e.Id == id);
        }
    }
}
