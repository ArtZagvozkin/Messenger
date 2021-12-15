using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repository
{
    public class GroupRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get { return _context; }
        }

        public GroupRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Group>> GetAllAsync()
        {
            return await _context.Groups.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Group> GetByIdAsync(Guid id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task AddAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Group group)
        {
            var existGroup = await _context.Groups.FindAsync(group.Id);
            _context.Entry(existGroup).CurrentValues.SetValues(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Group group = await _context.Groups.FindAsync(id);
            _context.Remove(group);
            await _context.SaveChangesAsync();
        }
    }
}
