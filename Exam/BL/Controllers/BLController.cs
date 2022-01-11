using System.Collections.Generic;
using BL.Infrastructure;
using BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BLController : ControllerBase
    {
        
        [HttpPost]
        [Route("PostFighters")]
        public List<Round> Post(Data fighters)
            => Log.GetLog(fighters);
    }
}