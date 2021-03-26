/*****************************************************************
 * Name:    MetricsController.cs                                 *
 * By:      TeamPenguins                                         *
 * Purpose: Controller to manipulate the api using HTTP methods  *
 ****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Models.Entities;
using Api.Services;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : ControllerBase
    {
        private readonly MetricsDBContext _context;     //Handler for the external database context
        
        /// Name:       Constructor
        /// Params:     context, passes database to controller
        /// Purpose:    Instantiates a new api handler and passes the database to it.
        public MetricsController(MetricsDBContext context)
        {
            _context = context;
        }

        /// Name:    GetMetrics
        /// Purpose: Uses HTTP GET to return a json representation of the database.
        /// Returns: x:<Task<ActionResult<IEnumberable<Metrics>>>, Asynchronously grabs data and returns it as a list
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metrics>>> GetMetrics()
        {
            return await _context.Metrics.ToListAsync();
        }

        /// Name:       GetMetrics
        /// Params:      id:int, the user id to return
        /// Purpose:    Returns a specific user as JSON
        /// Returns:    x:Task<ActionResult<IEnumerable<Metrics>>>, Ansynchronously return a single user
        /// Error:      User ID not found
        [HttpGet("{id}")]
        public async Task<ActionResult<Metrics>> GetMetrics(int id)
        {
            var metrics = await _context.Metrics.FindAsync(id);

            if (metrics == null)
            {
                return NotFound();
            }

            return metrics;
        }

       

        /// Name:       PutMetrics
        /// Params:     id:int, the user id to return; metrics:Metrics, the metrics
        /// Purpose:    Returns a specific user as JSON
        /// Returns:    x:Task<ActionResult<IEnumerable<Metrics>>>, Ansynchronously return a single user
        /// Error:      User ID not found
        /// Note:       To protect from overposting attacks, enable the specific properties you want to bind to, for
        ///             more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetrics(int id, Metrics metrics)
        {
            if (id != metrics.UserId)
            {
                return BadRequest();
            }

            _context.Entry(metrics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricsExists(id))
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
        
        /// Name:       PostMetrics
        /// Params:     metrics:Metrics, 
        /// Purpose:    Pushes JSON to the database
        /// Returns:    x:Task<ActionResult<<Metrics>>, Ansynchronously replace the database
        /// Note:       To protect from overposting attacks, enable the specific properties you want to bind to, for
        ///             more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Metrics>> PostMetrics(Metrics metrics)
        {
            _context.Metrics.Add(metrics);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetMetrics", new { id = metrics.UserId }, metrics);
        }

        
        /// Name:       DeleteMetrics
        /// Params:     id:int, id to be deleted
        /// Purpose:    Delete a specific user 
        /// Returns:    x:Task<ActionResult<Metrics>>, asynchronously deletes a user from the database
        /// Error:      User ID not found
        /// Note:       To protect from overposting attacks, enable the specific properties you want to bind to, for
        ///             more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpDelete("{id}")]
        public async Task<ActionResult<Metrics>> DeleteMetrics(int id)
        {
            var metrics = await _context.Metrics.FindAsync(id);
            if (metrics == null)
            {
                return NotFound();
            }

            _context.Metrics.Remove(metrics);
            await _context.SaveChangesAsync();

            return metrics;
        }

        /// Name:       MetricsExists
        /// Params:     id:int, the id of the metric to check
        /// Purpose:    Checks the Database for a metric
        /// Returns:    x:bool, Returns True if the metric exists; false otherwise
        /// Note:       the metric to test should be an extra flag, UserId should not be hardcoded, if possible Ie -> ( int id, var table)
        private bool MetricsExists(int id)
        {
            return _context.Metrics.Any(e => e.UserId == id);
        }
    }
}
