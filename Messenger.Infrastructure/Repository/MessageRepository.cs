using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repository
{
    public class MessageRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get { return _context; }
        }

        public MessageRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await _context.Messages.OrderBy(p => p.Context).ToListAsync();
        }

        public async Task<Message> GetByIdAsync(Guid id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task AddAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Message message)
        {
            var existMessege = await _context.Groups.FindAsync(message.Id);
            _context.Entry(existMessege).CurrentValues.SetValues(message);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Message message = await _context.Messages.FindAsync(id);;
            _context.Remove(message);
            await _context.SaveChangesAsync();
        }
    }
}
