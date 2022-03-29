using Microsoft.EntityFrameworkCore;
using NGRI.Library.Model;
using NGRI.Webapi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using NGRI.Library.Interfaces;
using System.Threading.Tasks;

namespace NGRI.Library.Services
{
    // This service is used to manage the CRUD async operations for the NGRI.Library.Models.Estate model with NGRIWebapiContext dependency injection.
    public class EstateService : IEstateService
    {
        private readonly NGRIWebapiContext _context;

        public EstateService(NGRIWebapiContext context)
        {
            _context = context;
        }

        // This method is used to get all the estates from the database.
        public async Task<List<Estate>> GetAllEstates()
        {
            return await _context.Estates.ToListAsync();
        }

        // This method is used to get an estate by its id.
        public async Task<Estate> GetEstateById(int id)
        {
            return await _context.Estates.FindAsync(id);
        }

        // This method is used to add an estate to the database.
        public async Task<Estate> AddEstate(Estate estate)
        {
            _context.Estates.Add(estate);
            await _context.SaveChangesAsync();
            return estate;
        }

        // This method is used to update an estate in the database.
        public async Task<Estate> UpdateEstate(Estate estate)
        {
            _context.Estates.Update(estate);
            await _context.SaveChangesAsync();
            return estate;
        }

        // This method is used to delete an estate from the database.
        public async Task<Estate> DeleteEstate(int id)
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

        // This method is used to create if not exists in the database otherwise update an estate in the database.
        public async Task<Estate> CreateIfExistsOrUpdateEstate(Estate estate)
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

        public async Task<bool> EstateExists(int id) => await _context.Estates.AnyAsync(e => e.Id == id);
    }
}
