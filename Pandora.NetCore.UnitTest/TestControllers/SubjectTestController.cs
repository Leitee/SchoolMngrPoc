using Microsoft.AspNetCore.Mvc;
using Pandora.NetCore.WebApi.Controllers.Api;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
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
            var response = await _controller.EnrollStudent(new SubjectDto(), new StudentDto()) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }
    }
}
