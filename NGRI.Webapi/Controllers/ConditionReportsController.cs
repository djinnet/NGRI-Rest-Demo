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
using Microsoft.Extensions.Logging;

namespace NGRI.Webapi.Controllers
{
    /*
     * This is the controller for condition report entity.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionReportsController : ControllerBase
    {
        private readonly IConditionReportService _conditionReportService;
        private readonly ILogger<ConditionReportsController> logger;

        public ConditionReportsController(IConditionReportService service, ILogger<ConditionReportsController> logger)
        {
            this.logger = logger;
            _conditionReportService = service;
        }

        // GET: api/ConditionReports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConditionReport>>> GetConditionReport()
        {
            try
            {
                return await _conditionReportService.GetAllConditionReports();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        // GET: api/ConditionReports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionReport>> GetConditionReport(int id)
        {
            try
            {
                var conditionReport = await _conditionReportService.GetConditionReport(id);

                if (conditionReport == null)
                {
                    return NotFound();
                }

                return conditionReport;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        // Get: api/GetReportsFromEstateID/5
        [HttpGet("GetReportsFromEstateID/{id}")]
        public async Task<ActionResult<IEnumerable<ConditionReport>>> GetReportsFromEstateID(int id)
        {
            try
            {
                var conditionReports = await _conditionReportService.GetReportsFromEstateID(id);

                if (conditionReports == null)
                {
                    return NotFound();
                }

                return conditionReports;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        // POST: api/ConditionReports
        [HttpPost]
        public async Task<ActionResult<ConditionReport>> PostConditionReport(ConditionReport conditionReport)
        {
            try
            {
                var result = await _conditionReportService.CreateIfExistsOrUpdateConditionReport(conditionReport);

                return CreatedAtAction("GetConditionReport", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
        }

        // DELETE: api/ConditionReports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConditionReport(int id)
        {
            try
            {
                var conditionReport = await _conditionReportService.DeleteConditionReport(id);
                if (conditionReport == null)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }
    }
}
