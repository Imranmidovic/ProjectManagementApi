using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Classes;
using ProjectManagementApi.Database;

namespace ProjectManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SubProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubProject>>> GetSubProjects()
        {
            return await _context.SubProjects.ToListAsync();
        }
        // GET: api/SubProjects/projectID/5 fali neki response da znamo dal je ovo uspesno odradjeno
        [HttpGet("projectID/{id}")]
        public async Task<IEnumerable<SubProject>> GetSubProjectsByProjectId(int id)
        {
            var subProjects = _context.SubProjects.ToList().Where(s => s.Fk == id);
            return subProjects;
        }

        // GET: api/SubProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubProject>> GetSubProject(int id)
        {
            var subProject = await _context.SubProjects.FindAsync(id);

            if (subProject == null)
            {
                return NotFound();
            }

            return subProject;
        }

        // PUT: api/SubProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubProject(int id, SubProject subProject)
        {
            if (id != subProject.ID)
            {
                return BadRequest();
            }

            _context.Entry(subProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SubProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubProject>> PostSubProject(SubProject subProject)
        {
            _context.SubProjects.Add(subProject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubProject", new { id = subProject.ID }, subProject);
        }

        // DELETE: api/SubProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubProject(int id)
        {
            var subProject = await _context.SubProjects.FindAsync(id);
            if (subProject == null)
            {
                return NotFound();
            }

            _context.SubProjects.Remove(subProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubProjectExists(int id)
        {
            return _context.SubProjects.Any(e => e.ID == id);
        }
    }
}
