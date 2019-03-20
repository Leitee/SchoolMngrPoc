using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.Core.Bases;
using NetCore.ServiceData.Dtos;
using NetCore.ServiceData.Services.Contracts;
using System.Threading.Tasks;

namespace NetCore.Api.Controllers
{
    [Route("api/v1/[controller]")]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
        public async Task<IActionResult> Get()
        {
            var response = await _gradeSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "getPais")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _gradeSvc.GetByIdAsync(id);
            return response.ToHttpResponse();
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
