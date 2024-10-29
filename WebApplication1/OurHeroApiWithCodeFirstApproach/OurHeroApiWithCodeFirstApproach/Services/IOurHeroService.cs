using OurHeroApiWithCodeFirstApproach.Models;
;

namespace OurHeroApiWithCodeFirstApproach.Services
{
    public interface IOurHeroService
    {
        Task<List<OurHeroModel>> GetAllHeros(bool? isActive);
        Task<OurHeroModel?> GetHerosByID(int id);
        Task<OurHeroModel?> AddOurHero(AddUpdateOurHero obj);
        Task<OurHeroModel?> UpdateOurHero(int id, AddUpdateOurHero obj);
        Task<bool> DeleteHerosByID(int id);

    }
}
