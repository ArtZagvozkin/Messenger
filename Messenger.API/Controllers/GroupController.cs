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
    public class GroupController : ControllerBase
    {
        private readonly Context _context;
        private readonly GroupRepository _groupRepository;

        public GroupController(Context context)
        {
            _context = context;
            _groupRepository = new GroupRepository(_context);
        }

        // GET: api/Group
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _groupRepository.GetAllAsync();
        }

        // GET: api/Group/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        // PUT: api/Group/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(Guid id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            await _groupRepository.UpdateAsync(group);

            return NoContent();
        }

        // POST: api/Group
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group group)
        {
            await _groupRepository.AddAsync(group);

            return CreatedAtAction("GetGroup", new { id = group.Id }, group);
        }

        // DELETE: api/Group/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group == null)
            {
                return NotFound();
            }

            await _groupRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool GroupExists(Guid id)
        {
            return _context.Groups.Any(e => e.Id == id);
        }
    }
}
