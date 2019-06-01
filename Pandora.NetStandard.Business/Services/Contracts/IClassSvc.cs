using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IClassSvc : IBasicCrudOperations<ClassDto>
    {
        Task<BLListResponse<ClassDto>> GetClassesByGradeId(int gradeId);
        Task<BLSingleResponse<bool>> DeleteAsync(int classId);
    }
}
