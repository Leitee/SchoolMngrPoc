using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Route("api/v1/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GradesController : ApiBaseController
    {
        private readonly IClassSvc _classSvc;
        private readonly IGradeSvc _gradeSvc;

        public GradesController(ILogger<GradesController> logger,
            IClassSvc classSvc,
            IGradeSvc gradeSvc) : base(logger)
        {
            _classSvc = classSvc;
            _gradeSvc = gradeSvc;
        }

        // GET api/v1/grades
        [HttpGet]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 00, Location = ResponseCacheLocation.Any)]//TODO:ver cache
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
            return NoContent();
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

        #region class
        // GET: api/v1/grades/5/classes
        [HttpGet("{id}/classes")]
        public async Task<IActionResult> GetClassesByGrade(int id)
        {
            var response = await _classSvc.GetClassesByGradeId(id);
            return response.ToHttpResponse();
        }

        // GET: api/v1/grades/classes
        [HttpGet("classes")]
        public async Task<IActionResult> GetClasses()
        {
            var response = await _classSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        // GET: api/v1/grades/classes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass(int id)
        {
            var response = await _classSvc.GetByIdAsync(id);
            return response.ToHttpResponse();
        }

        // PUT: api/v1/grades/classes/5
        [HttpPut("classes/{id}")]
        public async Task<IActionResult> PutClass([FromBody] ClassDto pClass, int pId)
        {
            if (pId != pClass.Id)
            {
                return BadRequest();
            }


            return NoContent();
        }

        // POST: api/v1/grades/5/classes
        [HttpPost("{id}/classes")]
        public async Task<IActionResult> PostClass([FromBody] ClassDto pClass, int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _classSvc.CreateAsync(pClass);
                return CreatedAtAction(nameof(GetById), new { pClass.Id }, response.Data);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/v1/grades/classes/5
        [HttpDelete("classes/{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var resul = await _classSvc.GetByIdAsync(id);
            if (resul == null)
            {
                return NotFound();
            }

            var response = await _classSvc.DeleteAsync(resul.Data);
            return response.ToHttpResponse();
        }

        #endregion
    }
}
