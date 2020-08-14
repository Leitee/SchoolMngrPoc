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
    public class ClassesController : ApiBaseController
    {
        private readonly IClassSvc _classSvc;

        public ClassesController(IClassSvc classSvc, ILogger logger) : base(logger)
        {
            _classSvc = classSvc;
        }

        [HttpGet("GetByGrade/{id}")]
        public async Task<IActionResult> GetByGrade(int? id)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                var response = await _classSvc.GetClassesByGradeId(id.Value);
                return response.ToHttpResponse();                
            }

            return BadRequest(ModelState);
        }

        [HttpGet()]
        public async Task<IActionResult> Get()
        {
            var response = await _classSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                var response = await _classSvc.GetByIdAsync(id.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ClassDto pClass, int pId)
        {
            if (pId != pClass.Id)
            {
                return BadRequest();
            }


            return NoContent();
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ClassDto pClass)
        {
            if (ModelState.IsValid)
            {
                var response = await _classSvc.CreateAsync(pClass);
                return CreatedAtAction(nameof(Get), new { pClass.Id }, response.Data);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var resul = await _classSvc.GetByIdAsync(id);
            if (resul == null)
            {
                return NotFound();
            }

            var response = await _classSvc.DeleteAsync(resul.Data);
            return response.ToHttpResponse();
        }

    }
}
