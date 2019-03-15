using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using NetCore.ServiceData.Services.Contracts;
using NetCore.ServiceData.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.ServiceData.Services
{
    public class GradesSvc : BaseService, IGradeSvc
    {
        public Task<BLResponse<GradeDto>> CreateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<bool>> DeleteAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<List<GradeDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<GradeDto>> GetByIdAsync(int pId)
        {
            throw new NotImplementedException();
        }

        public Task<BLResponse<bool>> UpdateAsync(GradeDto pDto)
        {
            throw new NotImplementedException();
        }
    }
}
