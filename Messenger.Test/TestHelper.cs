using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Domain;
using Messenger.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Messenger.Infrastructure.Repository;

namespace Messenger.Test
{
    class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);

            // Delete existing db before creating a new one
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public GroupRepository GroupRepository
        {
            get
            {
                return new GroupRepository(_context);
            }
        }

        public GroupMembershipRepository GroupMembershipRepository
        {
            get
            {
                return new GroupMembershipRepository(_context);
            }
        }

        public FileRepository FileRepository
        {
            get
            {
                return new FileRepository(_context);
            }
        }
    }
}
