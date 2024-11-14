using CarRentingSystemMVC.Data.Models;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Repositories;
using sib_api_v3_sdk.Model;

namespace CarRentingAPI.Controllers
{
    [Route("odata/[controller]")]
    [ApiController]
    public class ReportsController : ODataController
    {
        private readonly IReportRepository _reportRepository;

        public ReportsController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        // GET: odata/Reports
        [EnableQuery]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReportsDTO>>> GetReports()
        {
            return Ok(await _reportRepository.GetReportsAsync());
        }

        // GET: odata/Reports/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Reports>> GetReport(int id)
        {
            var reports = await _reportRepository.GetReportByIdAsync(id);
            if (reports == null)
            {
                return BadRequest();
            }

            return Ok(reports);
        }

        // POST: odata/Reports
        [HttpPost]
        public async Task<ActionResult<Reports>> PostReport([FromBody] Reports reports)
        {
            await _reportRepository.SaveReportAsync(reports);
            return CreatedAtAction(nameof(GetReport), new { id = reports.Id }, reports);
        }

        // PUT: odata/Reports/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReport(int id, [FromBody] Reports reports)
        {
            if (id != reports.Id)
            {
                return BadRequest();
            }

            try
            {
                await _reportRepository.UpdateReportAsync(reports);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ReportExists(id))
                {
                    return BadRequest();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: odata/Reports/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReport(int id)
        {
            var reports = await _reportRepository.GetReportByIdAsync(id);
            if (reports == null)
            {
                return BadRequest();
            }

            await _reportRepository.DeleteReportAsync(reports);
            return NoContent();
        }
        private async Task<bool> ReportExists(int id)
        {
            var reports = await _reportRepository.GetReportByIdAsync(id);
            return reports != null;
        }

    }
}
