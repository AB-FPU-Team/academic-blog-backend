using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Academic_Blog.Domain;
using Academic_Blog.Domain.Models;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Academic_Blog.Services.Interfaces;
using Microsoft.AspNetCore.OData.Query;
using Academic_Blog.Validatiors;

namespace Academic_Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ODataController
    {
        private readonly ILogger<ReportsController> _logger;
        private readonly IReportService _reportService;

        public ReportsController(ILogger<ReportsController> logger , IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        // GET: api/Reports
        [HttpGet]
        [EnableQuery(PageSize = 10)]
        [CustomAuthorize(Enums.RoleEnum.Admin)]
        public async Task<IActionResult> GetReports()
        {
           var result = await _reportService.GetReports();
           return Ok(result);
        }
        /*
        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(Guid id)
        {
          if (_context.Reports == null)
          {
              return NotFound();
          }
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        // PUT: api/Reports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(Guid id, Report report)
        {
            if (id != report.Id)
            {
                return BadRequest();
            }

            _context.Entry(report).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportExists(id))
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

        // POST: api/Reports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Report>> PostReport(Report report)
        {
          if (_context.Reports == null)
          {
              return Problem("Entity set 'AcademicBlogContext.Reports'  is null.");
          }
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReport", new { id = report.Id }, report);
        }

        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(Guid id)
        {
            if (_context.Reports == null)
            {
                return NotFound();
            }
            var report = await _context.Reports.FindAsync(id);
            if (report == null)
            {
                return NotFound();
            }

            _context.Reports.Remove(report);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReportExists(Guid id)
        {
            return (_context.Reports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
*/
    }
}
