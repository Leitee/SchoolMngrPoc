using NetCore.Core.Bases;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.Core.Interfaces
{
    public interface ICrudBasicOperations<TDto>
    {
        Task<BLResponse<List<TDto>>> GetAllAsync();
        Task<BLResponse<TDto>> GetByIdAsync(int pId);
        Task<BLResponse<TDto>> CreateAsync(TDto pDto);
        Task<BLResponse<bool>> UpdateAsync(TDto pDto);
        Task<BLResponse<bool>> DeleteAsync(TDto pDto);
    }
}
