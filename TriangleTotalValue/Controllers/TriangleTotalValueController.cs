using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TriangleTotalValue.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriangleTotalValue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TriangleTotalValueController : Controller
    {
        private readonly ILogger<TriangleTotalValueController> _logger;

        public TriangleTotalValueController(ILogger<TriangleTotalValueController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "TriangleTotalValue")]
        public IActionResult TriangleTotalValue([FromBody] string txtContent)
        {
            Triangle triangle = new Triangle(txtContent, _logger);
            return Ok(triangle.totalValue);
        }
    }
}

