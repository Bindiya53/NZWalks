using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZWalks.Dto;

namespace NZWalks.Service.Contracts
{
    public interface IRegionService
    {
        Task<ResponseDto> GetAllRegions();
    }
}