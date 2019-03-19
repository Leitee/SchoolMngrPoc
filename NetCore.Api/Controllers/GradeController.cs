using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.Core.Bases;
using NetCore.ServiceData.Services.Contracts;
using NetCore.ServiceData.Services.Dtos;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GradeController : ApiController
    {
        private readonly IGradeSvc _gradeSvc;

        public GradeController(ILogger<GradeController> logger, 
            IGradeSvc gradeSvc) : base(logger)
        {
            _gradeSvc = gradeSvc;
        }

        // GET api/values
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<ActionResult<BLListResponse<GradeDto>>> Get()
        {
            return await _gradeSvc.GetAllAsync();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "getPais")]
        public async Task<ActionResult<BLSingleResponse<GradeDto>>> Get(int id)
        {
            return await _gradeSvc.GetByIdAsync(id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] object obj)
        {
            if (ModelState.IsValid)
            {
                //save data
                return new CreatedAtRouteResult("getPais", new { id = obj }, obj);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
