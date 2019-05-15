using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Business.States;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using Pandora.NetStandard.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class SubjectSvc : BaseService<Subject, SubjectDto>, ISubjectSvc
    {
        private readonly IStudentStateSvc _studentStateSvc;
        public SubjectSvc(IApplicationUow applicationUow, ILogger<SubjectSvc> logger,
            IStudentStateSvc studentStateSvc)
            : base(applicationUow, logger, new SubjectToDtoMapper())
        {
            _studentStateSvc = studentStateSvc;
        }

        public async Task<BLSingleResponse<SubjectDto>> CreateAsync(SubjectDto pDto)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Subject>().InsertAsync(pDto);
                if (await _uow.CommitAsync())
                {
                    response.Data = _mapper.MapEntity(entityResult);
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLListResponse<SubjectDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<bool>> SaveSubjectExams(SubjectDto pSubject)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                await _uow.GetRepo<Subject>().UpdateAsync(pSubject);
                if (await _uow.CommitAsync())
                {
                    response.Data = true;
                }
                else
                {
                    HandleSVCException(response, "This action couldn't be performed.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<SubjectDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<SubjectDto>();

            try
            {
                var entityResult = await _uow.GetRepo<Subject>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entityResult);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(SubjectDto pDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BLSingleResponse<bool>> EnrollStudent(SubjectDto subjectDto, StudentDto studentDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                StateManager stateManager = await StateManager.GetStateManagerAsync(_studentStateSvc, studentDto, subjectDto);
                response.Data = await stateManager.EnrollAsync(studentDto, subjectDto);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}
