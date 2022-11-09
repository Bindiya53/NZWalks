using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZWalks.NZWalks.Infrastructure.Entities;

namespace NZWalks.Infrastructure.Contracts
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllRegions();
    }
}