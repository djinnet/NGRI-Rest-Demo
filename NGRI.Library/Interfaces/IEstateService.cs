using NGRI.Library.Model;

namespace NGRI.Library.Interfaces
{
    // this is the interface for EstateService class that will be used by the EstateController to interact with the database async
    public interface IEstateService
    {
        Task<Estate> GetEstateById(int id);
        Task<List<Estate>> GetAllEstates();
        Task<Estate> AddEstate(Estate estate);
        Task<Estate> UpdateEstate(Estate estate);
        Task<Estate> DeleteEstate(int id);
        Task<Estate> CreateIfExistsOrUpdateEstate(Estate estate);
        Task<bool> EstateExists(int id);
    }
}