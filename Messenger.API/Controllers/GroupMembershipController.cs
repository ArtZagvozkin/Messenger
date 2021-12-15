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
    public class GroupMembershipController : ControllerBase
    {
        private readonly Context _context;
        private readonly GroupMembershipRepository _groupMembershipRepository;

        public GroupMembershipController(Context context)
        {
            _context = context;
            _groupMembershipRepository = new GroupMembershipRepository(_context);
        }

        // GET: api/GroupMembership
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupMembership>>> GetGroupMemberships()
        {
            return await _groupMembershipRepository.GetAllAsync();
        }

        // GET: api/GroupMembership/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupMembership>> GetGroupMembership(Guid id)
        {
            var groupMembership = await _groupMembershipRepository.GetByIdAsync(id);

            if (groupMembership == null)
            {
                return NotFound();
            }

            return groupMembership;
        }

        // PUT: api/GroupMembership/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupMembership(Guid id, GroupMembership groupMembership)
        {
            if (id != groupMembership.Id)
            {
                return BadRequest();
            }

            await _groupMembershipRepository.UpdateAsync(groupMembership);

            return NoContent();
        }

        // POST: api/GroupMembership
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GroupMembership>> PostGroupMembership(GroupMembership groupMembership)
        {
            await _groupMembershipRepository.AddAsync(groupMembership);

            return CreatedAtAction("GetGroupMembership", new { id = groupMembership.Id }, groupMembership);
        }

        // DELETE: api/GroupMembership/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupMembership(Guid id)
        {
            var groupMembership = await _groupMembershipRepository.GetByIdAsync(id);
            if (groupMembership == null)
            {
                return NotFound();
            }

            await _groupMembershipRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool GroupMembershipExists(Guid id)
        {
            return _context.GroupMemberships.Any(e => e.Id == id);
        }
    }
}
