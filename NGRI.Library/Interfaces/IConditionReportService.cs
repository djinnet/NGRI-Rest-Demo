using NGRI.Library.Model;

namespace NGRI.Library.Interfaces
{
    // this is the interface for ConditionReport class that will be used by the ConditionReportController to interact with the database async
    public interface IConditionReportService
    {
        Task<List<ConditionReport>> GetAllConditionReports();
        Task<ConditionReport> GetConditionReport(int id);
        Task<ConditionReport> AddConditionReport(ConditionReport conditionReport);
        Task<ConditionReport> UpdateConditionReport(ConditionReport conditionReport);
        Task<ConditionReport> DeleteConditionReport(int id);
        Task<ConditionReport> CreateIfExistsOrUpdateConditionReport(ConditionReport conditionReport);
        Task<bool> ConditionReportExists(int id);
    }
}