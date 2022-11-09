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
                regionRepo.ToList().ForEach(regionRepo =>
                
                {
                    var regionDto = new Region()
                    {
                        Id = regionRepo.Id,
                        Name = regionRepo.Name,
                        Code = regionRepo.Code,
                        Area = regionRepo.Area,
                        Lat = regionRepo.Lat,
                        Long = regionRepo.Long,
                        Population = regionRepo.Population,
                    };
                    regionList.Add(regionDto);              
                });
                return new ResponseDto{StatusCode=200, Response = regionList};
            }
            catch
            {
                return new ResponseDto { StatusCode = 500 };
            }
        }
    }
}