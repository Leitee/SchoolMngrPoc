using Microsoft.Extensions.DependencyInjection;
using Pandora.NetCore.WebApi.Controllers.Api;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Business.Services;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest
{
    public class GradeControllerUnitTest : IClassFixture<DbContextMocker>
    {
        private readonly GradesController _controller;

        public GradeControllerUnitTest(DbContextMocker mocker)
        {

            //services.AddDbContext<UnitTestDbContext>(builder =>
            //{
            //    builder.UseInMemoryDatabase("Test");
            //});
            IGradeSvc gradeSvc = new GradeSvc(mocker.GetApplicationUoW("GradeTestDB"));

            _controller = new GradesController(null, gradeSvc);
        }

        [Fact]
        public async Task TestGetAllGrades()
        {
            var response = await _controller.Get() as BLListResponse<GradeDto>;

            Assert.False(response.HasError);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
