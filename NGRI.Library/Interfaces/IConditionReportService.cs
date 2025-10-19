using NGRI.Library.Model;

namespace NGRI.Library.Interfaces
{
    // This is the interface for ConditionReport class that will be used by the ConditionReportController to interact with the database async
    public interface IConditionReportService
    {
        Task<List<ConditionReport>> GetAllConditionReports();
        Task<ConditionReport> GetConditionReport(int reportid);
        Task<ConditionReport> AddConditionReport(ConditionReport conditionReport);
        Task<ConditionReport> UpdateConditionReport(ConditionReport conditionReport);
        Task<ConditionReport> DeleteConditionReport(int reportid);

        // This is a special method that will be used to get the condition reports for a specific estate.
        Task<List<ConditionReport>> GetReportsFromEstateID(int estateid);
        
        Task<ConditionReport> CreateIfExistsOrUpdateConditionReport(ConditionReport conditionReport);
        Task<bool> ConditionReportExists(int reportid);
    }
}