using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetCore.WebApi.Controllers.Api
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SubjectsController : ApiBaseController
    {
        private readonly ISubjectSvc _subjectSvc;


        public SubjectsController(ILogger<SubjectsController> logger,
            ISubjectSvc subjectSvc)
            : base(logger)
        {
            _subjectSvc = subjectSvc;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _subjectSvc.GetAllAsync();
            return response.ToHttpResponse();
        }

        [HttpGet("{id}", Name = "getSubject")]
        public async Task<IActionResult> Get(int? id)
        {
            if (ModelState.IsValid && id.HasValue)
            {
                var response = await _subjectSvc.GetByIdAsync(id.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetByTeacher/{teacherId}")]
        public async Task<IActionResult> GetByTeacher(int? teacherId)
        {
            if (ModelState.IsValid && teacherId.HasValue)
            {
                var response = await _subjectSvc.GetByUserIdAsync<TeacherDto>(teacherId.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpGet("GetByStudent/{studentId}")]
        public async Task<IActionResult> GetByStudent(int? studentId)
        {
            if (ModelState.IsValid && studentId.HasValue)
            {
                var response = await _subjectSvc.GetByUserIdAsync<StudentDto>(studentId.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
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

        [HttpPut("EnrollStudent/{subjectId}")]
        public async Task<IActionResult> EnrollStudent(int subjectId, [FromBody] int? userId)
        {
            if (ModelState.IsValid && userId.HasValue)
            {
                var response = await _subjectSvc.EnrollStudentAsync(subjectId, userId.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("SaveAttends/{subjectId}")]
        public async Task<IActionResult> SaveAttendsBySubject(int subjectId, IList<StudentDto> studentDtos)
        {
            if (ModelState.IsValid && studentDtos.Count > 0)
            {
                var response = await _subjectSvc.SaveAttendsAsync(subjectId, studentDtos);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("SaveExams/{subjectId}")]
        public async Task<IActionResult> SaveExamsBySubject(int subjectId, IList<StudentDto> studentDtos)
        {
            if (ModelState.IsValid && studentDtos.Count > 0)
            {
                var response = await _subjectSvc.SaveExamResultAsync(subjectId, studentDtos);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("TryEnroll/{subjectId}")]
        public async Task<IActionResult> TryEnroll(int subjectId, [FromBody] int? studentId)
        {
            if (ModelState.IsValid && studentId.HasValue)
            {
                var response = await _subjectSvc.TryEnrollAsync(subjectId, studentId.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }
    }
}