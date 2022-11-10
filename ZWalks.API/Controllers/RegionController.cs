using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Dto;
using NZWalks.Service.Contracts;

namespace ZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        [HttpGet]
        [Route("GetAllRegions")]
        [Authorize]
        public async Task<ActionResult<Region>> GetAllRegions()
        {
            var result = await _regionService.GetAllRegions();
            return Ok(result);
        }
    }
}