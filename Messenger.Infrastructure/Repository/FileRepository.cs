using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Microsoft.EntityFrameworkCore;

namespace Messenger.Infrastructure.Repository
{
    public class FileRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get { return _context; }
        }

        public FileRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<File>> GetAllAsync()
        {
            return await _context.Files.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<File> GetByIdAsync(Guid id)
        {
            return await _context.Files.FindAsync(id);
        }

        public async Task AddAsync(File file)
        {
            _context.Files.Add(file);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(File file)
        {
            var existFile = await _context.Files.FindAsync(file.Id);
            _context.Entry(existFile).CurrentValues.SetValues(file);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            File file = await _context.Files.FindAsync(id);
            _context.Remove(file);
            await _context.SaveChangesAsync();
        }
    }
}
