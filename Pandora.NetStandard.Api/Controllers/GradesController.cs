using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStdLibrary.Base.Base;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GradesController : ApiBaseController
    {
        private readonly IGradeSvc _gradeSvc;

        public GradesController(ILogger logger,
            IGradeSvc gradeSvc) : base(logger)
        {
            _gradeSvc = gradeSvc;
        }

        // GET api/v1/grades
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 3600, Location = ResponseCacheLocation.Any)]//TODO:ver cache
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
                return CreatedAtAction(nameof(GetById), new { pGradeObj.Id }, response.Data);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        // PUT api/v1/grades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] GradeDto pGrade, int pId)
        {
            if (ModelState.IsValid && pGrade.Id == pId)
            {
                var response = await _gradeSvc.UpdateAsync(pGrade);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        // DELETE api/v1/grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resul = await _gradeSvc.GetByIdAsync(id);
            if (resul == null)
            {
                return NotFound();
            }

            var response = await _gradeSvc.DeleteAsync(resul.Data);
            return response.ToHttpResponse();
        }


    }
}
