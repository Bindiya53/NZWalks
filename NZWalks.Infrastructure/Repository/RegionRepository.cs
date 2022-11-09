using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                var result = await _nzwalkDbContext.Regions.ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}