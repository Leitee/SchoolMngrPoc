using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface ISubjectSvc : IBasicCrudOperations<SubjectDto>
    {
        Task<BLSingleResponse<SubjectDto>> SubscribeStudent(SubjectDto pSubjectDto = null);
    }
}
