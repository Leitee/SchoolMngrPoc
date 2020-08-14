using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pandora.NetCore.UnitTest.Fixtures;
using Pandora.NetStandard.Api.Controllers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStdLibrary.Base.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.Scenarios
{
    public class SubjectTestController : TestScenarioBase<SubjectsController>
    {
        public SubjectTestController(HostFixture hostFixture) : base(hostFixture)
        {
        }

        protected override SubjectsController GetControllerInstance()
        {
            var logger = GetContainerInstance<ILogger>();
            var sbjSvc = GetContainerInstance<ISubjectSvc>();

            return new SubjectsController(logger, sbjSvc);
        }

        [Fact(DisplayName = "Retriving all existing subjects using http request")]
        public async Task TestGetAllGradesFromControllerInstance()
        {
            var httpResp = await GetServer().CreateRequest("api/v1/subjects").GetAsync();
            httpResp.EnsureSuccessStatusCode();

            var subjResp = JsonConvert.DeserializeObject<BLListResponse<SubjectDto>>
                                (await httpResp.Content.ReadAsStringAsync());

            subjResp.HasError.Should().BeFalse();
            subjResp.Data.Count().Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "Retriving all existing subjects using controller instance")]
        public async Task TestGetAllGradesFromHttpReq()
        {
            var response = await Controller.Get() as ObjectResult;
            var value = response.Value.As<BLListResponse<SubjectDto>>();

            value.Should().NotBeNull();
        }

        [Fact(DisplayName = "Enroll an student")]
        public async Task TestEnrollStudent()
        {
            var subjectId = 1;
            var userId = 101;

            var response = await Controller.EnrollStudent(subjectId, userId) as ObjectResult;
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

            var response = await Controller.SaveExamsBySubject(subjectId, student) as ObjectResult;
            var value = response.Value as BLSingleResponse<bool>;

            Assert.True(value.Data);
        }
    }
}
