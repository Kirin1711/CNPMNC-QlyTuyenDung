using jobconnect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace jobconnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsApiController : ControllerBase
    {
        private readonly RecruitmentManagementContext _context;

        public JobsApiController(RecruitmentManagementContext context)
        {
            _context = context;
        }

        // GET: api/JobApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Job>>> GetJobs()
        {
            return await _context.Jobs.ToListAsync();
        }

        // GET: api/JobApi/5
        [HttpGet("{JobId}")]
        public async Task<ActionResult<Job>> GetJob(int JobId)
        {
            var job = await _context.Jobs.FindAsync(JobId);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        // POST: api/JobApi
        [HttpPost]
        public async Task<ActionResult<Job>> PostJob(Job job)
        {
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetJob), new { JobId = job.JobId }, job);
        }

        // PUT: api/JobApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int JobId, Job job)
        {
            if (JobId != job.JobId)
            {
                return BadRequest();
            }

            _context.Entry(job).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/JobApi/5
        [HttpDelete("{JobId}")]
        public async Task<IActionResult> DeleteJob(int JobId)
        {
            var job = await _context.Jobs.FindAsync(JobId);
            if (job == null)
            {
                return NotFound();
            }

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
