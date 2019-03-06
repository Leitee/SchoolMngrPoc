using NetCore.Model.Entities;
using System;
using System.Threading.Tasks;

namespace NetCore.Core.Interfaces
{
    public interface IApplicationUow : IDisposable
    {
        bool Commit();
        Task<int> CommitAsync();

        //Model Repositories
        IRepository<Grade> Grades { get; }
        IRepository<Class> Classes { get; }
    }
}
