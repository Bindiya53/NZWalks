using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Dto;
using NZWalks.Service.Contracts;

namespace ZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        [HttpGet]
        [Route("GetAllRegions")]
        public async Task<ActionResult<Region>> GetAllRegions()
        {
            var result = await _regionService.GetAllRegions();
            return Ok(result);
        }
    }
}