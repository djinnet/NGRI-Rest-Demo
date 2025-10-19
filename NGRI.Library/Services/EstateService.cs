using Microsoft.EntityFrameworkCore;
using NGRI.Library.Model;
using NGRI.Webapi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using NGRI.Library.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NGRI.Library.Services
{
    // This service is used to manage the CRUD async operations for the NGRI.Library.Models.Estate model with NGRIWebapiContext dependency injection.
    public class EstateService : IEstateService
    {
        private readonly NGRIWebapiContext _context;
        private readonly ILogger<EstateService> _logger;

        public EstateService(NGRIWebapiContext context, ILogger<EstateService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // This method is used to get all the estates from the database.
        public async Task<List<Estate>> GetAllEstates()
        {
            try
            {
                return await _context.Estates.Include(i => i.ConditionReports).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        // This method is used to get an estate by its id.
        public async Task<Estate> GetEstateById(int id)
        {
            try
            {
                return await _context.Estates.FindAsync(id);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                throw;
            }
        }

        // This method is used to add an estate to the database.
        public async Task<Estate> AddEstate(Estate estate)
        {
            try
            {
                _context.Estates.Add(estate);
                await _context.SaveChangesAsync();
                return estate;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error adding estate: {e.Message}");
                throw;
            }
        }

        // This method is used to update an estate in the database.
        public async Task<Estate> UpdateEstate(Estate estate)
        {
            try
            {
                _context.Estates.Update(estate);
                await _context.SaveChangesAsync();
                return estate;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error updating estate: {e.Message}");
                throw;
            }
            
        }

        // This method is used to delete an estate from the database.
        public async Task<Estate> DeleteEstate(int id)
        {
            try
            {
                var estate = await _context.Estates.FindAsync(id);
                if (estate == null)
                {
                    return null;
                }
                _context.Estates.Remove(estate);
                await _context.SaveChangesAsync();
                return estate;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error deleting estate: {e.Message}");
                throw;
            }
            
        }

        // This method is used to create if not exists in the database otherwise update an estate in the database.
        public async Task<Estate> CreateIfExistsOrUpdateEstate(Estate estate)
        {
            try
            {
                var estateInDb = await _context.Estates.FindAsync(estate.Id);
                if (estateInDb == null)
                {
                    _context.Estates.Add(estate);
                }
                else
                {
                    _context.Estates.Update(estate);
                }
                await _context.SaveChangesAsync();
                return estateInDb ?? estate;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error creating or updating estate: {e.Message}");
                throw;
            }
        }

        public async Task<bool> EstateExists(int id) => await _context.Estates.AnyAsync(e => e.Id == id);
    }
}
