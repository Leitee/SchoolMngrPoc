using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetCore.WebApi.Controllers.Api;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.Scenarios
{
    public class GradeTestController : IClassFixture<HostFixture>
    {
        private readonly GradesController _controller;

        public GradeTestController(ILogger logger, IGradeSvc gradeSvc)
        {
            _controller = new GradesController(logger, gradeSvc);
        }

        [Fact(DisplayName = "Retriving all existing grades")]
        public async Task TestGetAllGrades()
        {
            var response = await _controller.Get() as ObjectResult;
            var value = response.Value as BLListResponse<GradeDto>;

            Assert.False(value.HasError);
        }
    }
}
