using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Route("api/v1/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GradesController : ApiBaseController
    {
        private readonly IGradeSvc _gradeSvc;

        public GradesController(ILogger<GradesController> logger, 
            IGradeSvc gradeSvc) : base(logger)
        {
            _gradeSvc = gradeSvc;
        }

        // GET api/v1/grades
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        public async Task<IActionResult> Get()
        {
            var response = await _gradeSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        // GET api/v1/grades/5
        [HttpGet("{id}", Name = "getGrade")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _gradeSvc.GetByIdAsync(id);
            return response.ToHttpResponse();
        }

        // POST api/v1/grades
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GradeDto pGradeObj)
        {
            if (ModelState.IsValid)
            {
                var response = await _gradeSvc.CreateAsync(pGradeObj);
                return CreatedAtAction(nameof(GetById), new { pGradeObj.Id } , pGradeObj);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        // PUT api/v1/grades/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/v1/grades/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
