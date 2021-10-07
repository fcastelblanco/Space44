using Fc.DomainServices.Definitions;
using Fc.Entities.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ISourceService _sourceService;

        public MovieController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return Ok("Welcome !");
        }

        [HttpGet]
        public Task<IEnumerable<Movie>> Get()
        {
            return _sourceService.Get();
        }

        [HttpGet("{address}")]
        public Task<IEnumerable<Movie>> Get(string address)
        {
            return _sourceService.Get(address);
        }
    }
}
