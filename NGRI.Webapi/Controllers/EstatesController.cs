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
     * This is the controller for the Estate entity.
     */
    [Route("api/[controller]")]
    [ApiController]
    public class EstatesController : ControllerBase
    {
        private readonly IEstateService _estateService;
        private readonly ILogger<EstatesController> logger;
        
        public EstatesController(IEstateService service, ILogger<EstatesController> logger)
        {
            _estateService = service;
            this.logger = logger;
        }

        // GET: api/Estates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estate>>> GetEstate()
        {
            try
            {
                return await _estateService.GetAllEstates();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        // GET: api/Estates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> GetEstate(int id)
        {
            try
            {
                var estate = await _estateService.GetEstateById(id);

                if (estate == null)
                {
                    return NotFound();
                }

                return estate;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            
        }

        // POST: api/Estates
        [HttpPost]
        public async Task<ActionResult<Estate>> PostEstate(Estate estate)
        {
            try
            {
                var result = await _estateService.CreateIfExistsOrUpdateEstate(estate);

                return CreatedAtAction("GetEstate", new { id = result.Id }, result);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/Estates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            try
            {
                var estate = await _estateService.DeleteEstate(id);
                if (estate == null)
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
