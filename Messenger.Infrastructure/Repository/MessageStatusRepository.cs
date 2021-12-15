using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repository
{
    public class MessageStatusRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get { return _context; }
        }

        public MessageStatusRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<MessageStatus>> GetAllAsync()
        {
            return await _context.MessageStatuses.OrderBy(p => p.Status).ToListAsync();
        }

        public async Task<MessageStatus> GetByIdAsync(Guid id)
        {
            return await _context.MessageStatuses.FindAsync(id);
        }

        public async Task AddAsync(MessageStatus messageStatus)
        {
            _context.MessageStatuses.Add(messageStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MessageStatus messageStatus)
        {
            var existMessageStatus = await _context.MessageStatuses.FindAsync(messageStatus.Id);
            _context.Entry(existMessageStatus).CurrentValues.SetValues(messageStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            MessageStatus messageStatus = await _context.MessageStatuses.FindAsync(id);
            _context.Remove(messageStatus);
            await _context.SaveChangesAsync();
        }
    }
}
