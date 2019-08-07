﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Api.Controllers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.Scenarios
{
    public class SubjectTestController : IClassFixture<HostFixture>
    {
        private readonly SubjectsController _controller;

        public SubjectTestController(ILogger logger, ISubjectSvc subjectSvc)
        {
            _controller = new SubjectsController(logger, subjectSvc);
        }

        [Fact(DisplayName = "Retriving all existing subjects")]
        public async Task TestGetAllGrades()
        {
            var response = await _controller.Get() as ObjectResult;
            var value = response.Value as BLListResponse<SubjectDto>;

            Assert.False(value.HasError);
        }

        [Fact(DisplayName = "Enroll an student")]
        public async Task TestEnrollStudent()
        {
            var subjectId = 1;
            var userId = 101;

            var response = await _controller.EnrollStudent(subjectId, userId) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }

        [Fact(DisplayName = "Save student exams")]
        public async Task TestSaveExams()
        {
            var subjectId = 1;
            var student = new StudentDto()
            {
                Id = 11111111,
                Exams = new List<ExamDto>
            {
                new ExamDto { Score=10, ExamType = NetStandard.Model.Enums.ExamTypeEnum.FIRST },
                new ExamDto { Score=5, ExamType = NetStandard.Model.Enums.ExamTypeEnum.SECOND }
            }
            };

            var response = await _controller.SaveExamsBySubject(subjectId, student) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }
    }
}