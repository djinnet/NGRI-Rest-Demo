using Microsoft.EntityFrameworkCore;
using NGRI.Library.Interfaces;
using NGRI.Library.Model;
using NGRI.Webapi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace NGRI.Library.Services
{
    public class ConditionReportService : IConditionReportService
    {
        private readonly NGRIWebapiContext _context;
        private readonly ILogger<ConditionReportService> logger;

        public ConditionReportService(NGRIWebapiContext context, ILogger<ConditionReportService> logger)
        {
            this.logger = logger;
            _context = context;
        }

        public async Task<ConditionReport> AddConditionReport(ConditionReport conditionReport)
        {
            try
            {
                _context.ConditionReports.Add(conditionReport);
                await _context.SaveChangesAsync();
                return conditionReport;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<bool> ConditionReportExists(int id) => await _context.ConditionReports.AnyAsync(e => e.Id == id);

        public async Task<ConditionReport> CreateIfExistsOrUpdateConditionReport(ConditionReport conditionReport)
        {
            try
            {
                var ConditionReportDb = await _context.ConditionReports.FindAsync(conditionReport.Id);
                if (ConditionReportDb == null)
                {
                    _context.ConditionReports.Add(conditionReport);
                    _context.Estates.Attach(conditionReport.Estate);
                }
                else
                {
                    _context.ConditionReports.Update(conditionReport);
                }
                await _context.SaveChangesAsync();
                return ConditionReportDb ?? conditionReport;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ConditionReport> DeleteConditionReport(int id)
        {
            try
            {
                var conditionReport = await _context.ConditionReports.FindAsync(id);
                if (conditionReport == null)
                {
                    return null;
                }

                _context.ConditionReports.Remove(conditionReport);
                await _context.SaveChangesAsync();
                return conditionReport;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<ConditionReport>> GetAllConditionReports()
        {
            try
            {
                return await _context.ConditionReports.ToListAsync();
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ConditionReport> GetConditionReport(int id)
        {
            try
            {
                return await _context.ConditionReports.FindAsync(id);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<List<ConditionReport>> GetReportsFromEstateID(int id)
        {
            try
            {
                //get estate from id
                var estate = await _context.Estates.FindAsync(id);
                //get all reports from estate
                var reports = await _context.ConditionReports.Where(r => r.Estate == estate).ToListAsync();
                //return reports
                return reports;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }

        public async Task<ConditionReport> UpdateConditionReport(ConditionReport conditionReport)
        {
            try
            {
                _context.ConditionReports.Update(conditionReport);
                await _context.SaveChangesAsync();
                return conditionReport;
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                throw;
            }
        }
    }
}
