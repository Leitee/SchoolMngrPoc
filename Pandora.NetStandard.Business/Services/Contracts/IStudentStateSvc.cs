using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IStudentStateSvc : IBasicCrudOperations<StudentStateDto>
    {
        Task<BLSingleResponse<StudentStateDto>> GetLastValidStateAsync(int studentId, int subjectId);
    }
}
