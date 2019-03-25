using Microsoft.AspNetCore.Mvc;
using Pandora.NetCore.WebApi.Controllers;
using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.Core.Bases;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pandora.NetCore.UnitTest
{
    public class GradeControllerUnitTest : IDisposable
    {
        private readonly GradeController _controller;

        public GradeControllerUnitTest(GradeController controller)
        {
            _controller = controller;
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
