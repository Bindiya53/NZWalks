using Microsoft.EntityFrameworkCore;
using NZWalks.Infrastructure.Contracts;
using NZWalks.NZWalks.Infrastructure.Entities;

namespace NZWalks.Infrastructure.Repository
{

    public class RegionRepository : IRegionRepository
    {
        private readonly NzwalksDbContext _nzwalkDbContext;
        public RegionRepository(NzwalksDbContext nzwalkDbContext)
        {
            _nzwalkDbContext = nzwalkDbContext;
        }
        public async Task<List<Region>> GetAllRegions()
        {
            try
            {
                return await _nzwalkDbContext.Regions.ToListAsync();      
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}