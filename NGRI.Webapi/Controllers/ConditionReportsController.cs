#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGRI.Library.Interfaces;
using NGRI.Library.Model;
using NGRI.Webapi.Data;

namespace NGRI.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionReportsController : ControllerBase
    {
        private readonly IConditionReportService _conditionReportService;

        public ConditionReportsController(IConditionReportService service)
        {
            _conditionReportService = service;
        }

        // GET: api/ConditionReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReport>>> GetConditionReport()
        {
            return await _conditionReportService.GetAllConditionReports();
        }

        // GET: api/ConditionReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReport>> GetConditionReport(int id)
        {
            var conditionReport = await _conditionReportService.GetConditionReport(id);

            if (conditionReport == null)
            {
                return NotFound();
            }

            return conditionReport;
        }

        // POST: api/ConditionReports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ConditionReport>> PostConditionReport(ConditionReport conditionReport)
        {
            var result = await _conditionReportService.CreateIfExistsOrUpdateConditionReport(conditionReport);

            return CreatedAtAction("GetConditionReport", new { id = result.Id }, result);
        }

        // DELETE: api/ConditionReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            var conditionReport = await _conditionReportService.DeleteConditionReport(id);
            if (conditionReport == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
