using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pandora.NetCore.WebApi.Controllers;
using Pandora.NetStandard.Business.Dtos;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Data.Dals;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest
{
    public class GradeControllerUnitTest : IDisposable
    {
        private readonly GradesController _controller;

        public GradeControllerUnitTest(IServiceCollection services)
        {
            services.AddDbContext<SchoolDbContext>(builder =>
            {
                builder.UseInMemoryDatabase("Test");
            });
        }

        [Fact]
        public async Task TestGetAllGrades()
        {
            var response = await _controller.Get() as BLListResponse<GradeDto>;

            Assert.False(response.HasErrors);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
