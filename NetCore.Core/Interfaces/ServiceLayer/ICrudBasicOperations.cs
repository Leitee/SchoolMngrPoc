using NetCore.Core.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Core.Interfaces
{
    public interface ICrudBasicOperations<TDto>
    {
        Task<BLListResponse<TDto>> GetAllAsync();
        Task<BLSingleResponse<TDto>> GetByIdAsync(int pId);
        Task<BLSingleResponse<TDto>> CreateAsync(TDto pDto);
        Task<BLSingleResponse<bool>> UpdateAsync(TDto pDto);
        Task<BLSingleResponse<bool>> DeleteAsync(TDto pDto);
    }
}
