using NGRI.Library.Model;

namespace NGRI.Frontend.HttpClient
{
    public interface ICustomHttpClient
    {
        Task<bool> CreateEstateAsync(Estate estate);
        Task<bool> CreateReportAsync(ConditionReport report);
        Task<bool> DeleteEstateAsync(int id);
        Task<bool> DeleteReportAsync(int id);
        Task<Estate?> GetEstateAsync(int id);
        Task<Estate[]?> GetEstatesAsync();
        Task<ConditionReport?> GetReportAsync(int id);
        Task<ConditionReport[]?> GetReportsFromEstateID(int id);
        Task<bool> UpdateEstateAsync(Estate estate);
        Task<bool> UpdateReportAsync(ConditionReport report);
    }
}