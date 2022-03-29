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
    public class EstatesController : ControllerBase
    {
        private readonly IEstateService _estateService;

        public EstatesController(IEstateService service)
        {
            _estateService = service;
        }

        // GET: api/Estates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estate>>> GetEstate()
        {
            return await _estateService.GetAllEstates();
        }

        // GET: api/Estates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estate>> GetEstate(int id)
        {
            var estate = await _estateService.GetEstateById(id);

            if (estate == null)
            {
                return NotFound();
            }

            return estate;
        }

        // POST: api/Estates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estate>> PostEstate(Estate estate)
        {
            var result = await _estateService.CreateIfExistsOrUpdateEstate(estate);

            return CreatedAtAction("GetEstate", new { id = result.Id }, result);
        }

        // DELETE: api/Estates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstate(int id)
        {
            var estate = await _estateService.DeleteEstate(id);
            if (estate == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
