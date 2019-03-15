using NetCore.Core.Bases;
using NetCore.Core.Interfaces;
using System;

namespace NetCore.ServiceData.Services
{
    public abstract class BaseService
    {
        protected IApplicationUow Uow { get; set; }

        protected void HandleSVCException<T>(ref BLResponse<T> pResponse, Exception pEx)
        {
            pResponse.Errors.Add("Error at Business Service");
            pResponse.Errors.Add(pEx.Message);
            if (pEx.InnerException != null)
                pResponse.Errors.Add(pEx.InnerException.Message);
        }

        protected void HandleSVCException<T>(ref BLResponse<T> pResponse, params string[] pErrors)
        {
            pResponse.Errors.Add("Error at Business Service");
            pResponse.Errors.AddRange(pErrors);
        }
    }
}
