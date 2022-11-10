using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NZWalks.NZWalks.Infrastructure.Data;

namespace NZWalks.Service.Contracts
{
    public interface IJwtTokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}