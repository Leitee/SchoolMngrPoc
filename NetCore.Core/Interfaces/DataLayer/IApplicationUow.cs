using System;
using System.Threading.Tasks;

namespace NetCore.Core.Interfaces
{
    public interface IApplicationUow : IDisposable
    {
        bool Commit();
        Task<int> CommitAsync();
    }
}
