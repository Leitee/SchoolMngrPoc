using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Model.Dtos;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubjectsController : ApiBaseController
    {
        private readonly ISubjectSvc _subjectSvc;

        public SubjectsController(ILogger<SubjectsController> logger, ISubjectSvc subjectSvc) 
            : base(logger)
        {
            _subjectSvc = subjectSvc;
        }

        [HttpGet("{id}", Name = "getSubject")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _subjectSvc.GetByIdAsync(id);
            return response.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubjectDto subjectDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _subjectSvc.CreateAsync(subjectDto);
                return CreatedAtAction("getStudent", new { subjectDto.Id }, response.Data);//return 201 created and its data entity 
            }

            return BadRequest(ModelState);
        }
    }
}