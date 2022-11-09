using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZWalks.Dto;
using NZWalks.Infrastructure.Contracts;
using NZWalks.Service.Contracts;

namespace NZWalks.Service.Service
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }
        public async Task<ResponseDto> GetAllRegions()
        {
            try
            {
                var regionRepo = await _regionRepository.GetAllRegions();
                List<Region> regionList = new List<Region>();
                foreach (var region in regionRepo)
                {
                    Region regionData = new Region
                    {
                        Id = region.Id,
                        Name = region.Name,
                        Code = region.Code,
                        Area = region.Area,
                        Lat = region.Lat,
                        Long = region.Long,
                        Population = region.Population,

                    };
                    regionList.Add(regionData);              
                }   
                return new ResponseDto{StatusCode=200, Response = regionList};
            }
            catch
            {
                return new ResponseDto { StatusCode = 500 };
            }
        }
    }
}