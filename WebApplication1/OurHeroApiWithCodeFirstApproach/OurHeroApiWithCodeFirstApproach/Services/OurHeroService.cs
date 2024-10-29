using Microsoft.EntityFrameworkCore;
using OurHeroApiWithCodeFirstApproach.Entity;
using OurHeroApiWithCodeFirstApproach.Models;


namespace OurHeroApiWithCodeFirstApproach.Services
{
    public class OurHeroService: IOurHeroService
    {
        private readonly OurHeroDbContext _db;
        public OurHeroService(OurHeroDbContext db)
        {
            _db = db;
        }
        public async Task<List<OurHeroModel>> GetAllHeros(bool? isActive)
        {
            if (isActive == null) { return await _db.OurHeros.ToListAsync(); }

            return await _db.OurHeros.Where(obj => obj.IsActive == isActive).ToListAsync();
        }

        public async Task<OurHeroModel?> GetHerosByID(int id)
        {
            return await _db.OurHeros.FirstOrDefaultAsync(hero => hero.Id == id);
        }

        public async Task<OurHeroModel?> AddOurHero(AddUpdateOurHero obj)
        {
            var addHero = new OurHeroModel()
            {
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                IsActive = obj.isActive,
            };

            _db.OurHeros.Add(addHero);
            var result = await _db.SaveChangesAsync();
            return result >= 0 ? addHero : null;
        }

        public async Task<OurHero?> UpdateOurHero(int id, AddUpdateOurHero obj)
        {
            var hero = await _db.OurHeros.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.IsActive = obj.isActive;

                var result = await _db.SaveChangesAsync();
                return result >= 0 ? hero : null;
            }
            return null;
        }

        public async Task<bool> DeleteHerosByID(int id)
        {
            var hero = await _db.OurHeros.FirstOrDefaultAsync(index => index.Id == id);
            if (hero != null)
            {
                _db.OurHeros.Remove(hero);
                var result = await _db.SaveChangesAsync();
                return result >= 0;
            }
            return false;
        }



    }
}
