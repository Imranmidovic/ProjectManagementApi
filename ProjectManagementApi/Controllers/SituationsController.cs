using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagementApi.Classes;
using ProjectManagementApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SituationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Situation>>> GetSituations()
        {
            return await _context.Situations.ToListAsync();
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situation>> GetSituation(int id)
        {
            var project = await _context.Situations.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }

            return project;
        }

        // PUT: api/Projects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituation(int id, Situation project)
        {
            if (id != project.ID)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituationExists(id))
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


        // POST: api/Projects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Situation>> PostSituation(Situation project)
        {
            _context.Situations.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituation", new { id = project.ID }, project);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSituation(int id)
        {
            var project = await _context.Situations.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Situations.Remove(project);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SituationExists(int id)
        {
            return _context.Situations.Any(e => e.ID == id);
        }
    }
}
