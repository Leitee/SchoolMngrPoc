using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetCore.WebApi.Controllers.Api;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest.TestController
{
    public class GradeTestController : IClassFixture<TestDbContextMocker>
    {
        private readonly GradesController _controller;

        public GradeTestController(TestDbContextMocker mocker)
        {
            IGradeSvc gradeSvc = new GradeSvc(mocker.UoW, null);
            
            _controller = new GradesController(null, gradeSvc);
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
