using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Base;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
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
                var response = await _subjectSvc.GetByTeacherIdAsync(teacherId.Value);
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

        [HttpPut("{subjectId}/EnrollStudent")]
        public async Task<IActionResult> EnrollStudent(StudentDto studentDto, int? subjectId)
        {
            if (ModelState.IsValid && subjectId.HasValue)
            {
                var response = await _subjectSvc.EnrollStudentAsync(studentDto, subjectId.Value);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{subjectId}/SaveExams")]
        public async Task<IActionResult> SaveExams(IList<ExamDto> examDtos, int subjectId)
        {
            if (ModelState.IsValid && examDtos[0].SubjectId == subjectId)
            {
                var response = await _subjectSvc.SaveExamResultAsync(examDtos);
                return response.ToHttpResponse();
            }

            return BadRequest(ModelState);
        }
    }
}