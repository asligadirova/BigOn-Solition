using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigOn.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrendsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("from get");
        }
        [HttpPost]
        public IActionResult Create()
        {
            return Ok("from create");
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return Ok("from edit");
        }
        [HttpDelete]
        public IActionResult Remove()
        {
            return Ok("from remove");
        }
    }
}
