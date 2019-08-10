using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.UnitTest.Fixtures;
using Pandora.NetStandard.Api.Controllers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.Scenarios
{
    public class GradeTestController : TestScenarioBase<GradesController>
    {
        public GradeTestController(HostFixture hostFixture) : base(hostFixture) { }

        [Fact(DisplayName = "Retriving all existing grades")]
        public async Task TestGetAllGrades()
        {
            var response = await Controller.Get() as ObjectResult;
            var value = response.Value as BLListResponse<GradeDto>;

            Assert.False(value.HasError);
        }

        protected override GradesController GetControllerInstance()
        {
            var logger = GetContainerInstance<ILogger>();
            var gradeSvc = GetContainerInstance<IGradeSvc>();
            return new GradesController(logger, gradeSvc);
        }
    }
}
