using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZWalks.Dto
{
    public class ResponseDto
    {
        public int StatusCode { get; set; }
        public dynamic Response { get; set; }
    }
}