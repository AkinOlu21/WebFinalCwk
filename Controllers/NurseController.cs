using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
    private readonly HospitalContext _context;

    private readonly ILogger<NurseController> loggers;

   

    public IActionResult LoggerAction()
    {
        loggers.LogInformation("Logger was called.");
        return Ok();
    }

 [HttpGet("errorproneaction")]
    public IActionResult ErrorProneAction()
    {
        try
        {
            
            throw new InvalidOperationException("This is an exception!");
        }
        catch (Exception ex)
        {
            loggers.LogError(ex, "An error occurred!!!");
            return StatusCode(500, "Internal server error");
        }
    }

        public NurseController(HospitalContext context, ILogger<NurseController> logger)
        {
            _context = context;
            loggers = logger;
        }

        // GET: api/Nurse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nurse>>> GetNurses()
        {
            return await _context.Nurses.ToListAsync();
        }

        // GET: api/Nurse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nurse>> GetNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);

            if (nurse == null)
            {
                return NotFound();
            }

            return nurse;
        }

        // PUT: api/Nurse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNurse(int id, Nurse nurse)
        {
            if (id != nurse.NurseId)
            {
                return BadRequest();
            }

            _context.Entry(nurse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NurseExists(id))
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

        // POST: api/Nurse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nurse>> PostNurse(Nurse nurse)
        {
            _context.Nurses.Add(nurse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNurse", new { id = nurse.NurseId }, nurse);
        }

        // DELETE: api/Nurse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNurse(int id)
        {
            var nurse = await _context.Nurses.FindAsync(id);
            if (nurse == null)
            {
                return NotFound();
            }

            _context.Nurses.Remove(nurse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NurseExists(int id)
        {
            return _context.Nurses.Any(e => e.NurseId == id);
        }
    }
}
