using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repository
{
    public class GroupMembershipRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get { return _context; }
        }

        public GroupMembershipRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<GroupMembership>> GetAllAsync()
        {
            return await _context.GroupMemberships.OrderBy(p => p.Id).ToListAsync();
        }

        public async Task<GroupMembership> GetByIdAsync(Guid id)
        {
            return await _context.GroupMemberships.FindAsync(id);
        }

        public async Task AddAsync(GroupMembership groupMemberships)
        {
            _context.GroupMemberships.Add(groupMemberships);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(GroupMembership groupMemberships)
        {
            var existGroupMemberships = await _context.GroupMemberships.FindAsync(groupMemberships.Id);
            _context.Entry(existGroupMemberships).CurrentValues.SetValues(groupMemberships);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            GroupMembership groupMemberships = await _context.GroupMemberships.FindAsync(id);
            _context.Remove(groupMemberships);
            await _context.SaveChangesAsync();
        }
    }
}
