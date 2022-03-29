using Microsoft.EntityFrameworkCore;
using NGRI.Library.Interfaces;
using NGRI.Library.Model;
using NGRI.Webapi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGRI.Library.Services
{
    public class ConditionReportService : IConditionReportService
    {
        private readonly NGRIWebapiContext _context;

        public ConditionReportService(NGRIWebapiContext context)
        {
            _context = context;
        }

        public async Task<ConditionReport> AddConditionReport(ConditionReport conditionReport)
        {
            _context.ConditionReports.Add(conditionReport);
            await _context.SaveChangesAsync();
            return conditionReport;
        }

        public async Task<bool> ConditionReportExists(int id)
        {
            return await _context.ConditionReports.AnyAsync(e => e.Id == id);
        }

        public async Task<ConditionReport> CreateIfExistsOrUpdateConditionReport(ConditionReport conditionReport)
        {
            var ConditionReportDb = await _context.ConditionReports.FindAsync(conditionReport.Id);
            if (ConditionReportDb == null)
            {
                _context.ConditionReports.Add(conditionReport);
            }
            else
            {
                _context.ConditionReports.Update(conditionReport);
            }
            await _context.SaveChangesAsync();
            return ConditionReportDb ?? conditionReport;
        }

        public async Task<ConditionReport> DeleteConditionReport(int id)
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

        public async Task<List<ConditionReport>> GetAllConditionReports()
        {
            return await _context.ConditionReports.ToListAsync();
        }

        public async Task<ConditionReport> GetConditionReport(int id)
        {
            return await _context.ConditionReports.FindAsync(id);
        }

        public async Task<ConditionReport> UpdateConditionReport(ConditionReport conditionReport)
        {
            _context.ConditionReports.Update(conditionReport);
            await _context.SaveChangesAsync();
            return conditionReport;
        }
    }
}
