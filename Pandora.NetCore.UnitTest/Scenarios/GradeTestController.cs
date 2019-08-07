using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Api.Controllers;
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

        public GradeTestController(HostFixture hostFixture)
        {
            var logger = hostFixture.Server.Host.Services.GetService(typeof(ILogger));
            var gradeSvc = hostFixture.Server.Host.Services.GetService(typeof(IGradeSvc));
            //_controller = new GradesController(logger, gradeSvc);
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
