using Pandora.NetStdLibrary.Base.Interfaces;
using Pandora.NetStdLibrary.Base.Utils;
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
