using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Util;
using Pandora.NetStandard.Model.Dtos;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : ApiBaseController
    {
        private readonly IStudentSvc _studentSvc;

        public StudentsController(ILogger<StudentsController> logger, IStudentSvc studentSvc) 
            : base(logger)
        {
            _studentSvc = studentSvc;
        }

        [HttpGet("{id}", Name = "getStudent")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _studentSvc.GetByIdAsync(id);
            return response.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentDto pStudent)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentSvc.CreateAsync(pStudent);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetExamsBySubject/{id}")]
        public async Task<IActionResult> GetExamsBySubject(int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentSvc.GetStudentsExamsBySubjectId(id);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetAttendsBySubject/{id}")]
        public async Task<IActionResult> GetAttendsBySubject(int id)
        {
            if (ModelState.IsValid)
            {
                var response = await _studentSvc.GetStudentsAttendsBySubjectId(id);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }
    }
}