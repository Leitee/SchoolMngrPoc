using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Core.Interfaces
{
    public interface IApplicationUow : IDisposable
    {
        bool Commit();
        Task<int> CommitAsync();
    }
}
