using Microsoft.AspNetCore.Mvc;
using Pandora.NetCore.WebApi.Controllers.Api;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.TestControllers
{
    public class SubjectTestController : IClassFixture<TestDbContextMocker>
    {
        private readonly SubjectsController _controller;

        public SubjectTestController(TestDbContextMocker mocker)
        {
            IStudentStateSvc stateSvc = new StudentStateSvc(mocker.UoW, null);
            ISubjectSvc subjectSvc = new SubjectSvc(mocker.UoW, null, stateSvc);

            _controller = new SubjectsController(null, subjectSvc);
        }

        [Fact(DisplayName = "Enroll an student")]
        public async Task TestEnrollStudent()
        {
            var response = await _controller.EnrollStudent(new StudentDto(), 1) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }

        [Fact(DisplayName = "Save student exams")]
        public async Task TestSaveExams()
        {
            var response = await _controller.SaveExams(new List<ExamDto>(), 1) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }
    }
}
