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
    public class FileController : ControllerBase
    {
        private readonly Context _context;
        private readonly FileRepository _fileRepository;

        public FileController(Context context)
        {
            _context = context;
            _fileRepository = new FileRepository(_context);
        }

        // GET: api/File
        [HttpGet]
        public async Task<ActionResult<IEnumerable<File>>> GetFiles()
        {
            return await _fileRepository.GetAllAsync();
        }

        // GET: api/File/5
        [HttpGet("{id}")]
        public async Task<ActionResult<File>> GetFile(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);

            if (file == null)
            {
                return NotFound();
            }

            return file;
        }

        // PUT: api/File/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFile(Guid id, File file)
        {
            if (id != file.Id)
            {
                return BadRequest();
            }

            await _fileRepository.UpdateAsync(file);

            return NoContent();
        }

        // POST: api/File
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<File>> PostFile(File file)
        {
            await _fileRepository.AddAsync(file);

            return CreatedAtAction("GetFile", new { id = file.Id }, file);
        }

        // DELETE: api/File/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            var file = await _fileRepository.GetByIdAsync(id);
            if (file == null)
            {
                return NotFound();
            }

            await _fileRepository.DeleteAsync(id);

            return NoContent();
        }

        private bool FileExists(Guid id)
        {
            return _context.Files.Any(e => e.Id == id);
        }
    }
}
