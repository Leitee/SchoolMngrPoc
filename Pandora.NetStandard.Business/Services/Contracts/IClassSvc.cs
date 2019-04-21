using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface IClassSvc : IBasicCrudOperations<ClassDto>
    {
        Task<BLSingleResponse<bool>> DeleteAsync(int classId);
    }
}
